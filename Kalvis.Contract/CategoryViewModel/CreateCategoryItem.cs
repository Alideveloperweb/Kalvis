using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Contract.CategoryViewModel
{
    public class CreateCategoryItem
    {
        public string FaCategoryName { get; set; }
        
        public string EnCategoryName { get; set; }
        
        public List<int> SubId  { get; set; }
        public List<GetAllCategoryItem> GetAllCategoryItems { get; set; }
    }
}

















