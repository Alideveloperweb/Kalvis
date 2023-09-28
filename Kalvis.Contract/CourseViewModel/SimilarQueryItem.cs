
namespace Kalvis.Contract.CourseViewModel
{
    public class SimilarQueryItem
    {
        public long CourseID { get; set; }
        public string CourseTitle { get; set; }
        public string CourseImage { get; set; }
        public int CoursePrice { get; set; }
        public int UserCourseCount { get; set; }
        public int EpisodeCount { get; set; }
        public string CategoryName { get; set; }
        public string TeacherName { get; set; }
    }
}
