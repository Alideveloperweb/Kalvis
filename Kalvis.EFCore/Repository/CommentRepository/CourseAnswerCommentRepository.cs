using Kalvis.Common.Application;
using Kalvis.Domain.EducationEntities.CommentEntities;
using Kalvis.Domain.EducationEntities.CommentEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;

namespace Kalvis.EfCore.Repository.CommentRepository
{
    public class CourseAnswerCommentRepository
        : RepositoryBase<long, AnswerComment>
        , ICourseAnswerCommentRepository
    {
        #region Constracture
        private readonly ApplicationContext _context;
        public CourseAnswerCommentRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }
        #endregion
    }
}
