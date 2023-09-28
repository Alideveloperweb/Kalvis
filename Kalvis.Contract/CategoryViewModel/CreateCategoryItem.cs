using System.ComponentModel.DataAnnotations;

namespace Kalvis.Contract.CategoryViewModel
{
    public class CreateCategoryItem
    {
        [Display(Name = "نام فارسی")]
        public string FaCategoryName { get; set; }

        [Display(Name = "نام انگلیسی")]
        public string EnCategoryName { get; set; }
        
        public List<int> SubId  { get; set; }
        
        [Display(Name ="انتخاب زیر دسته")]
        public List<GetAllCategoryItem> GetAllCategoryItems { get; set; }
    }
}

















