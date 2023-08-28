using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Contract.CategoryViewModel
{
    public class GetAllCategoryItem
    {
        public int CategoryId { get; set; }
        
        public string FaCategoryName { get; set; }
        
        public string EnCategoryName { get; set; }
        
        public string CreateDate { get; set; }
      
        public string LastUpdateDate { get; set; }
    }
}
