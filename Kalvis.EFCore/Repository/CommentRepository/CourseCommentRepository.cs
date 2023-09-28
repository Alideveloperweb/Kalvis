using Kalvis.Common.Application;
using Kalvis.Contract.CommentViewModel;
using Kalvis.Contract.CommentViewModel.CourseCommentViewModel;
using Kalvis.Domain.EducationEntities.CommentEntities;
using Kalvis.Domain.EducationEntities.CommentEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;
using Microsoft.EntityFrameworkCore;

namespace Kalvis.EfCore.Repository.CommentRepository
{
    public class CourseCommentRepository : RepositoryBase<long, CourseComment> , ICourseCommentRepository
    {
        #region Constracture
        private readonly ApplicationContext _context;
        public CourseCommentRepository(ApplicationContext context)
            : base(context)
        {
            this._context = context;
        }

        #endregion
        public List<GetAllCourseCommetItem> GetAllCourseComment(bool IsRemove)
        {
            return (from com in _context.CourseComments
                    join user in _context.users on com.UserId equals user.Id
                    join course in _context.courses on com.CourseId equals course.Id
                    where (com.IsRemove == IsRemove)
                    select new GetAllCourseCommetItem
                    {
                        CommentId = com.Id,
                        CourseTitle = course.CourseTitle,
                        CreateDate = ConvertDate.MiladiToShamsi(com.CreateDate),
                        Email = user.Email,
                        IsActive = com.IsActive,
                        UserName = user.UserName,

                    })
                    .OrderBy(x => x.IsActive)
                    .ToList();
        }

        public GetCourseCommentItem GetCommentById(long CommentId)
        {
            return _context.CourseComments
                .Where(x => x.Id == CommentId)
                .Select(x => new GetCourseCommentItem
                {
                    CommentId = x.Id,
                    CommentText = x.CommentText,
                }).FirstOrDefault();
        }


        public List<GetAllCommentQueryItem> GetAllComment(long CourseID)
        {
            return _context.CourseComments
                 .Include(x => x.User)
                 .Where(x => x.IsActive)
                 .Where(x => x.CourseId == CourseID)
                 .Select(x => new GetAllCommentQueryItem
                 {
                     CommentID = x.Id,
                     CommentText = x.CommentText,
                     CourseID = x.CourseId,
                     FullName = x.User.FirstName + " " + x.User.LastName,
                     IsActive = x.IsActive,
                     UserID = x.UserId,
                     GetAllAnswer = _context.AnswerComments
                     .Include(x => x.User)
                     .Where(a => a.CommentID == x.Id)
                     .Select(a => new GetAllAnswerForCommentQueryItem
                     {
                         AnswerText = a.AnswerText,
                         CommentID = a.CommentID,
                         FullName = a.User.FirstName + " " + a.User.LastName,
                         UserID = a.UserID,

                     })
                     .ToList(),
                 })
                 .ToList();
        }
    }
}
