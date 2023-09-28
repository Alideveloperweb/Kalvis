
namespace Kalvis.Contract.CommentViewModel.CourseCommentViewModel
{
    public class CreateCommentAndAnswerItem
    {
        public long CourseID { get; set; }
        public long UserID { get; set; }
        public long CommentID { get; set; }
        public string Text { get; set; }
    }
}
