using Kalvis.Common.Enum;
using Kalvis.Contract.CommentViewModel.CourseCommentViewModel;

namespace Kalvis.Contract.CourseViewModel
{
    public class GetCourseQueryItem
    {
        public long CourseID { get; set; }
        public string CourseTitle { get; set; }
        public string CourseSummery { get; set; }
        public string CategoryNames { get; set; }
        public int UserCourseCount { get; set; }
        public string LastUpdate { get; set; }
        public int CoursePrice { get; set; }
        public TimeSpan CourseTime { get; set; }
        public CourseLevel courseLevel { get; set; }
        public Language Language { get; set; }
        public string CourseImage { get; set; }
        public string CourseDesCription { get; set; }
        public string TeacherName { get; set; }
        public int CategoryID { get; set; }
        public bool Buyer { get; set; }
        public List<GetAllEpisodeForCourse> GetAllEpisode { get; set; }
        public List<GetAllCommentQueryItem> GetAllComment { get; set; }
    }
}
