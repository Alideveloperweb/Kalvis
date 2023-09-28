using Kalvis.Contract.CategoryViewModel.Interface;
using Kalvis.Domain.EducationEntities.CategoryEntities;
using Kalvis.Domain.EducationEntities.CategoryEntities.Interface;
using Kalvis.Common.Application;
using Kalvis.Contract.CategoryViewModel;
using Kalvis.Contract.CategoryViewModel.Interface;

namespace Kalvis.Application.CategoryApp
{
    public class CategoryApplication : ICategoryApplication
    {
        #region Constractore

        private readonly ICategoryRepository _CategoryRep;
        private readonly ISubCategoryRepository _subRep;
        public CategoryApplication(ICategoryRepository CategoryRep,
            ISubCategoryRepository subRep)
        {
            _CategoryRep = CategoryRep;
            _subRep = subRep;
        }

        #endregion

        #region Create Category

        public OperationResult CreateCategory(CreateCategoryItem createCategor)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("دسته بندی");
            if (_CategoryRep.Exist(x => x.FaCategoryName == createCategor.FaCategoryName)
                || _CategoryRep.Exist(x => x.EnCategoryName == createCategor.EnCategoryName)
                )
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("اصلی"));


            Category category =
                new(createCategor.EnCategoryName, createCategor.FaCategoryName);

            bool create = _CategoryRep.Create(category);
            if (!create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());


            bool save = _CategoryRep.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            AddOrUpdateSubCategory(category.Id, createCategor.SubId);

            return operationResult.Success(Operation.Success, message.Create());

        }


        #endregion

        #region Edit Category

        public OperationResult EditCategory(EditCategoryItem editCategorItem)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("دسته بندی");
            if (
                _CategoryRep.Exist(x => x.Id != editCategorItem.CategoryId
               && (x.FaCategoryName == editCategorItem.FaCategoryName
               || x.EnCategoryName == editCategorItem.EnCategoryName))
               )
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("اصلی"));

            Category category = _CategoryRep.Get(editCategorItem.CategoryId);

            if (category.EnCategoryName != editCategorItem.EnCategoryName)
            {
                Uploder.ChanjeName(Router.RouteImageEducation +
                    category.EnCategoryName, Router.RouteImageEducation +
                    editCategorItem.EnCategoryName);

                Uploder.ChanjeName(Router.RouteImageBlog +
                    category.EnCategoryName, Router.RouteImageBlog +
                    editCategorItem.EnCategoryName);
            }

            category.Edit(editCategorItem.EnCategoryName,
                editCategorItem.FaCategoryName);


            bool Update = _CategoryRep.Update(category);
            if (!Update)
                return operationResult.Failed(Operation.Error, message.ErrorUpdate());


            bool save = _CategoryRep.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            AddOrUpdateSubCategory(category.Id, editCategorItem.SubId);

            return operationResult.Success(Operation.Success, message.Update());

        }


        #endregion

        #region Get All Category

        public List<GetAllCategoryItem> GetAllCategory(int CategoryId, bool IsRemove)
        {
            return _CategoryRep.GetAllCategory(CategoryId, IsRemove);
        }


        #endregion

        #region Add Or Update SubCategory

        public void AddOrUpdateSubCategory(int parentId, List<int> subId)
        {
            List<GetAllSubCategory> getAllSubCategories =
                _CategoryRep.GetAllSubCategories(parentId);
            List<SubCategory> AddSub = new();
            List<SubCategory> RemoveSub = new();

            if (getAllSubCategories.Count > 0)
            {
                foreach (var item in getAllSubCategories)
                {
                    if (subId != null)
                    {
                        if (subId.Contains(item.SubCategoryId))
                        {
                            subId.Remove(item.SubCategoryId);
                        }
                        else
                        {
                            RemoveSub.Add(new SubCategory(item.Id, item.ParentId, item.SubCategoryId));
                        }
                    }
                    else
                    {
                        RemoveSub.Add(new SubCategory(item.Id, item.ParentId, item.SubCategoryId));
                    }


                }
                _subRep.RemoveRange(RemoveSub);

            }

            if (subId != null)
            {
                foreach (var item in subId)
                {
                    if (!getAllSubCategories.Any(x => x.ParentId == parentId
                    && x.Id == item))
                    {
                        AddSub.Add(new SubCategory(0, parentId, item));
                    }
                }
            }
            _subRep.CreateRange(AddSub);
            _subRep.SaveChanges();

        }


        #endregion

        #region Find Category For Edit

        public EditCategoryItem FindCategoryForEdit(int Categoryid)
        {
            return _CategoryRep.FindCategoryForEdit(Categoryid);
        }

        #endregion

        #region Find Category For Remove

        public RemoveCategoryItem FindCategoryForRemove(int Categoryid)
        {
            return _CategoryRep.FindCategoryForRemove(Categoryid);
        }

        #endregion

        #region Remove Category

        public OperationResult RemoveCategory(RemoveCategoryItem removeCategory)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("دسته بندی");

            Category category = _CategoryRep.Get(removeCategory.CategoryId);

            if (category == null)
                return operationResult.Failed(Operation.Nullabel, message.Nullabele());

            category.Remove();

            bool Remove = _CategoryRep.Update(category);
            if (!Remove)
                return operationResult.Failed(Operation.Error, message.ErrorRemove());


            bool save = _CategoryRep.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Remove());

        }


        #endregion

        #region Restore Category

        public OperationResult RestoreCategory(RestoreCategoryItem RestoreCategory)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("دسته بندی");

            Category category = _CategoryRep.Get(RestoreCategory.CategoryId);

            if (category == null)
                return operationResult.Failed(Operation.Nullabel, message.Nullabele());

            category.Restore();

            bool Remove = _CategoryRep.Update(category);
            if (!Remove)
                return operationResult.Failed(Operation.Error, message.ErrorRestore());


            bool save = _CategoryRep.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Restore());
        }


        #endregion

        #region Find Category For Restore

        public RestoreCategoryItem FindCategoryForRestore(int Categoryid)
        {
            return _CategoryRep.FindCategoryForRestore(Categoryid);
        }

        #endregion


    }
}
