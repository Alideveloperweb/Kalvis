using Kalvis.Common.Application;
using System.ComponentModel.DataAnnotations;

namespace Kalvis.Contract.DisCountViewModel.CourseDisCountViewModel
{
    public class CreateCourseDisCountItem
    {
        [Display(Name = "کد تخفیف")]
        [Required(ErrorMessage = RequiredMessage.Required)]
        public string Code { get; set; }

        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        public string EndDate { get; set; }

        [Display(Name = "درصدتخفیف")]
        [Required(ErrorMessage = RequiredMessage.Required)]
        public byte Value { get; set; }

        [Display(Name = "تعداداستفاده")]
        public int? MaxUserCount { get; set; }
    }
}
