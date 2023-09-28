

using Kalvis.Common.Domain;
using Kalvis.Contract.CategoryViewModel;

namespace Kalvis.Domain.EducationEntities.CategoryEntities.Interface
{
    public interface ICategoryRepository : IRepositoryBase<int, Category>
    {
        List<GetAllCategoryItem> GetAllCategory(int categoryId, bool isRemove);
        List<GetAllSubCategory> GetAllSubCategories(int parentId);
        EditCategoryItem FindCategoryForEdit(long categoryId);
        RemoveCategoryItem FindCategoryForRemove(int categoryId);
        RestoreCategoryItem FindCategoryForRestore(int categoryId);
        string FindNameCategoryById(int categoryId);
    }
}
