using Kalvis.Common.Enum;

namespace Kalvis.Contract.CourseViewModel
{
    public class GetAllCourseItem
    {
        public long CourseId { get; set; }
        public string CourseTitle { get; set; }
        public int CoursePrice { get; set; }
        public string CourseImage { get; set; }
        public CourseLevel CourseLevel { get; set; }

    }
}
