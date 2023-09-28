using Kalvis.Common.Application;
using System.Collections.Generic;

namespace Kalvis.Contract.CommentViewModel.CourseCommentViewModel.Interface
{
    public interface ICourseCommentApplication
    {
        List<GetAllCourseCommetItem> GetAllCourseComment(bool IsRemove);
        GetCourseCommentItem GetCommentById(long CommentId);
        OperationResult AcceptComment(GetCourseCommentItem GetComment);
        OperationResult EditComment(GetCourseCommentItem GetComment);
        List<GetAllCommentQueryItem> GetAllComment(long CourseID);
        OperationResult CreateComment(CreateCommentAndAnswerItem Create);
        OperationResult CreateAnswer(CreateCommentAndAnswerItem Create);
    }
}
