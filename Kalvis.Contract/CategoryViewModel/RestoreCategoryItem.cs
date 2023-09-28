using System.ComponentModel.DataAnnotations;

namespace Kalvis.Contract.CategoryViewModel
{
    public class RestoreCategoryItem
    {
        public int CategoryId { get; set; }

        [Display(Name ="نام فارسی")]
        public string FaCategoryName { get; set; }

        [Display(Name = "نام انگلیسی")]
        public string EnCategoryName { get; set; }
    }
}
