using Kalvis.Domain.EducationEntities.CourseEntities.Interface;
using Kalvis.Domain.EducationEntities.CourseEntities;
using Kalvis.Common.Application;
using Kalvis.EFCore.ApplicationContexts;

namespace Kalvis.EFCore.Repository.CourseRepository
{

    public class UserCourseRepository
        : RepositoryBase<long, UserCourse>, IUserCourseRepository
    {
        #region Constracture
        private readonly ApplicationContext _context;
        public UserCourseRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }
        #endregion
    }
}
