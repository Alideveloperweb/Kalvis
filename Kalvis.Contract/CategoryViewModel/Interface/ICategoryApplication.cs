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
        List<GetAllCategoryItem> getAllCategory(int categoryId ,bool isRemove);

        OperationResult CreateCategory(CreateCategoryItem createCategory);
    }
}
