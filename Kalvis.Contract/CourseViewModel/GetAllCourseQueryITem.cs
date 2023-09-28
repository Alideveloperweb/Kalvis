

namespace Kalvis.Contract.CourseViewModel
{
    public class GetAllCourseQueryITem
    {
        public long CourseID { get; set; }
        public string CourseImage { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCategoryName { get; set; }
        public string TeacherImage { get; set; }
        public string TeacherName { get; set; }
        public int EpisodeCount { get; set; }
        public int CoursePrice { get; set; }
        public int UserCourseCount { get; set; }
    }
}
