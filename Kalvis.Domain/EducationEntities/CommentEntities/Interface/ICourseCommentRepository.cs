using Kalvis.Domain.EducationEntities.CommentEntities;
using Kalvis.Common.Domain;
using Kalvis.Contract.CommentViewModel.CourseCommentViewModel;

namespace Kalvis.Domain.EducationEntities.CommentEntities.Interface
{
    public interface ICourseCommentRepository
        : IRepositoryBase<long, CourseComment>
    {
        List<GetAllCourseCommetItem> GetAllCourseComment(bool IsRemove);
        GetCourseCommentItem GetCommentById(long CommentId);
        List<GetAllCommentQueryItem> GetAllComment(long CourseID);
    }
}
