using System.ComponentModel.DataAnnotations;

namespace Kalvis.Common.Enum
{
    public enum CourseLevel
    {
        [Display(Name = "متوسط")]
        medium = 1,
        [Display(Name = "پیشرفته")]
        Advanced = 2,
        [Display(Name = "صفر تا صد")]
        Zero_to_hundred = 3,
    }
}
