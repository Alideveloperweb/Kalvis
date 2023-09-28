using System.Collections.Generic;

namespace Kalvis.Contract.CommentViewModel.CourseCommentViewModel
{
    public class GetAllCommentQueryItem
    {
        public long CommentID { get; set; }
        public long UserID { get; set; }
        public string CommentText { get; set; }
        public long CourseID { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public List<GetAllAnswerForCommentQueryItem> GetAllAnswer { get; set; }
    }
}
