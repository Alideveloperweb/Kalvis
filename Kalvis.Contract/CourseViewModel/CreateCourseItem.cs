using Kalvis.Common.Application;
using Kalvis.Common.Enum;
using Kalvis.Contract.CategoryViewModel;
using Kalvis.Contract.TeacherViewModel;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Kalvis.Contract.CourseViewModel
{
    public class CreateCourseItem
    {
        [Required(ErrorMessage = RequiredMessage.Required)]
        [Display(Name = "عنوان دوره")]
        public string CourseTitle { get; set; }

        [Display(Name = "خلاصه")]
        public string CourseSummery { get; set; }

        [Display(Name = " قیمت")]
        public int CoursePrice { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = RequiredMessage.Required)]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = RequiredMessage.Required)]
        [Display(Name = "دسته بندی دوره")]
        public int CourseCategoryId { get; set; }

        public string CourseImage { get; set; }

        [Required(ErrorMessage = RequiredMessage.Required)]
        [Display(Name = "مدرس دوره")]
        public long UserId { get; set; }

        [Display(Name = "پورسانت مدرس")]
        public byte Percentage { get; set; }

        [Display(Name = "آپلودتصویر")]
        [Required(ErrorMessage = RequiredMessage.Required)]
        public IFormFile Uploder { get; set; }

        [Display(Name = "سطح دوره")]
        public CourseLevel courseLevel { get; set; }

        [Display(Name = "زبان دوره")]
        public Language Language { get; set; }

        [Display(Name = "برچسب ها")]
        public string Tags { get; set; }

        [Display(Name = "وضعیت کامنت")]
        public bool ActiveComment { get; set; }

        [Display(Name = "وضعیت پرسش و پاسخ")]
        public bool ActiveFaq { get; set; }

        public List<GetAllTeacherItem> getAllTeacherItem { get; set; }
        public List<GetAllCategoryItem> getAllCategoryItem { get; set; }

    }

}
