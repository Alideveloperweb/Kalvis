using Kalvi.Contract.CategoryViewmodel.Interface;
using Kalvi.Domain.EducationEntities.CategoryEntities;
using Kalvi.Domain.EducationEntities.CategoryEntities.Interface;
using Kalvis.Common.Application;
using Kalvis.Contract.CategoryViewModel;
using Kalvis.Contract.CategoryViewModel.Interface;

namespace Kalvis.Application.CategoryApp
{
    public class CategoryApplication : ICategoryApplication
    {
        #region Constractore

        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subRepository;

        public CategoryApplication(ICategoryRepository categoryRepository
             , ISubCategoryRepository subRepository)
        {
            _categoryRepository = categoryRepository;
            _subRepository = subRepository;
        }


        #endregion

        #region GetAllCategory

        public List<GetAllCategoryItem> GetAllCategory(int categoryId, bool isRemove)
        {
            return _categoryRepository.GetAllCategory(categoryId, isRemove);
        }

        #endregion

        #region CreateCategory

        public OperationResult CreateCategory(CreateCategoryItem createCategory)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("دسته بندی");

            if (_categoryRepository.Exist(x => x.FaCategoryName == createCategory.FaCategoryName)
            || _categoryRepository.Exist(x => x.EnCategoryName == createCategory.EnCategoryName))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate());

            Category category = new(createCategory.FaCategoryName, createCategory.EnCategoryName);

            bool create = _categoryRepository.Create(category);
            if (!create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());

            bool save = _categoryRepository.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Create());

        }



        #endregion

        #region EditCategory

        public OperationResult EditCategory(EditCategoryItem editCategoryItem)
        {
            throw new NotImplementedException();
        }
        #endregion



        public OperationResult RemoveCategory(RemoveCategoryItem removeCategoryItem)
        {
            throw new NotImplementedException();
        }

        public OperationResult RestoreCategory(RestoreCategoryItem restoryCategoryItem)
        {
            throw new NotImplementedException();
        }

        public EditCategoryItem FindCategoryForEdit(int categoryId)
        {
            throw new NotImplementedException();
        }

        public RemoveCategoryItem FindCategoryForRemove(int categoryId)
        {
            throw new NotImplementedException();
        }

        public RestoreCategoryItem FindCategoryForRestore(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
