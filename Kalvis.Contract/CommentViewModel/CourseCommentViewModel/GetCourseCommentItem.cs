using Kalvis.Common.Application;
using System.ComponentModel.DataAnnotations;

namespace Kalvis.Contract.CommentViewModel.CourseCommentViewModel
{
    public class GetCourseCommentItem
    {
        public long CommentId { get; set; }

        [Required(ErrorMessage = RequiredMessage.Required)]
        public string CommentText { get; set; }
    }
}
