

using Kalvi.Common.Domain;
using Kalvis.Contract.CategoryViewModel;

namespace Kalvi.Domain.EducationEntities.CategoryEntities.Interface
{
    public interface ICategoryRepository : IRepositoryBase<int, Category>
    {
        List<GetAllCategoryItem> getAllCategory(int CategoryId, bool IsRemove);
        //List<GetAllSubCategory> GetAllSubCategories(int Parentid);
        //EditCategorItem FindCategoryForEdit(long Categoryid);
        //RemoveCategoryItem FindCategoryForRemove(int Categoryid);
        //RestoreCategoryItem FindCategoryForRestore(int Categoryid);
        //string FindNameCategoryById(int CategoryId);
    }
}
