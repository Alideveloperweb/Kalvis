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

        public CategoryApplication(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        #endregion

        public List<GetAllCategoryItem> getAllCategory(int categoryId, bool isRemove)
        {
            return _categoryRepository.getAllCategory(categoryId, isRemove);
        }

        public OperationResult CreateCategory(CreateCategoryItem createCategory)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("دسته بندی");

            if (_categoryRepository.Exist(x => x.FaCategoryName == createCategory.FaCategoryName || x.EnCategoryName == createCategory.EnCategoryName))
                return operationResult.Failed(Operation.Dublicade,message.Dublicate());

            Category category = new(createCategory.FaCategoryName, createCategory.EnCategoryName);

            bool create = _categoryRepository.Create(category);
            if (!create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());

            bool save = _categoryRepository.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Create());

        }

    }
}
