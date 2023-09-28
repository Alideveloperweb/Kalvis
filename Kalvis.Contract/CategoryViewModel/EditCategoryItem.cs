using Kalvis.Common.Application;
using System.ComponentModel.DataAnnotations;

namespace Kalvis.Contract.CategoryViewModel
{
    public class EditCategoryItem
    {
        public int CategoryId { get; set; }

        [Display(Name = " نام فارسی دسته بندی")]
        [Required(ErrorMessage = RequiredMessage.Required)]
        public string FaCategoryName { get; set; }

        [Display(Name = " نام انگلیسی دسته بندی")]
        [Required(ErrorMessage = RequiredMessage.Required)]
        public string EnCategoryName { get; set; }

        public List<int> SubId { get; set; }

        [Display(Name = "انتخاب زیر دسته")]
        public List<GetAllCategoryItem> GetAllCategoryItems { get; set; }

    }
}
