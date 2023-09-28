
namespace Kalvis.Contract.CommentViewModel.CourseCommentViewModel
{
    public class GetAllAnswerForCommentQueryItem
    {
        public long UserID { get; set; }
        public string AnswerText { get; set; }
        public long CommentID { get; set; }
        public string FullName { get; set; }
    }
}
