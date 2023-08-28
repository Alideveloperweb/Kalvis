using Kalvis.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Contract.CategoryViewModel.Interface
{
    public interface ICategoryApplication
    {
        List<GetAllCategoryItem> GetAllCategory(int categoryId ,bool isRemove);

        OperationResult CreateCategory(CreateCategoryItem createCategoryItem);
        
        OperationResult EditCategory(EditCategoryItem editCategoryItem);
        
        OperationResult RemoveCategory(RemoveCategoryItem removeCategoryItem);
        
        OperationResult RestoreCategory(RestoreCategoryItem restoryCategoryItem);
        

        //-------------

        EditCategoryItem FindCategoryForEdit(int categoryId);

        RemoveCategoryItem FindCategoryForRemove(int categoryId);

        RestoreCategoryItem FindCategoryForRestore(int categoryId);
    
    }
}
