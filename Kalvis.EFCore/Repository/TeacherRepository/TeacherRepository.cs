
using Kalvis.Common.Application;
using Kalvis.Contract.TeacherViewModel;
using Kalvis.Domain.EducationEntities.TeacherEntities;
using Kalvis.Domain.EducationEntities.TeacherEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;
using Microsoft.EntityFrameworkCore;

namespace Kalvis.EFCore.Repository.TeacherRepository
{

    public class TeacherRepository : RepositoryBase<int, Teacher>
        , ITeacherRepository
    {
        #region Constracture
        private readonly ApplicationContext _context;
        public TeacherRepository(ApplicationContext context)
            : base(context)
        {
            this._context = context;
        }
        #endregion
        public UserUpgradeItem FindTeacherById(long TeacherId)
        {
            return _context.Teachers
                .Where(x => x.TeacherId == TeacherId)
                .Select(x => new UserUpgradeItem
                {
                    Id = x.Id,
                    TeacherId = x.TeacherId,
                    IsTeacher = x.TeacherId > 0,

                }).FirstOrDefault();
        }

        public List<GetAllTeacherItem> GetAllTeacher()
        {
            return _context.Teachers
                .Include(x => x.user)
                .Select(x => new GetAllTeacherItem
                {
                    CreateDate = x.user.CreateDate.ToString(),
                    IsActive = x.user.IsActive,
                    IsRemove = x.user.IsRemove,
                    TeacherId = x.TeacherId,
                    UserName = x.user.UserName,
                    Wallet = x.user.Wallet,

                }).ToList();
        }

        public List<GetTeacherForCommitionItem> getTeacherForCommition(List<long> TeacherID)
        {
            return _context.users
                  .Where(x => TeacherID.Contains(x.Id))
                  .Select(x => new GetTeacherForCommitionItem
                  {
                      UserID = x.Id,
                      Wallet = x.Wallet,
                  }).ToList();
        }
    }
}
