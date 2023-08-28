using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kalvis.Contract.CategoryViewModel
{
    public class RemoveCategoryItem
    {
        public int CategoryId { get; set; }

        [Display(Name = "نام فارسی")]
        public string FaCategoryName { get; set; }

        [Display(Name = "نام انگلیسی")]
        public string EnCategoryName { get; set; }
    }
}
