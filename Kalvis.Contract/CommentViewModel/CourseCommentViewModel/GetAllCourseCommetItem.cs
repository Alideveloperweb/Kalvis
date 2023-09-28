
namespace Kalvis.Contract.CommentViewModel.CourseCommentViewModel
{
    public class GetAllCourseCommetItem
    {
        public long CommentId { get; set; }
        public string UserName { get; set; }
        public string CreateDate { get; set; }
        public string Email { get; set; }
        public string CourseTitle { get; set; }
        public bool IsActive { get; set; }
    }
}
