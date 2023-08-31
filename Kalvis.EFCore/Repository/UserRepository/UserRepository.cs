using Kalvis.Common.Application;
using Kalvis.Contract.UserViewmodel;
using Kalvis.Domain.EducationEntities.UserEntities;
using Kalvis.Domain.EducationEntities.UserEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.EFCore.Repository.UserRepository
{
    public class UserRepository : RepositoryBase<long, User>
        , IUserRepository
    {

        #region Constractuor

        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Account Detail

        public AccountDetailItem AccountDetail(long userId)
        {
            AccountDetailItem Account = new();

            Account.AwaitingPayeCount =
               _context.CourseOrders
                .Where(x => !x.IsCancelled)
                .Where(x => !x.Ispaid)
                .Where(x => x.UserId == userId)
                .Count();

            Account.CourseCount = _context.courses
                .Where(x => !x.IsRemove)
                .Count();

            Account.UserCourseCount = _context.UserCourses
                .Where(x => x.UserId == userId).Count();

            Account.WalletBalance = _context.users
                .FirstOrDefault(x => x.Id == userId).Wallet;

            return Account;
        }

        #endregion

        #region Find User For Edit In Admin

        public EditUserForAdminItem FindUserForEditInAdmin(long id)
        {
            return _context.users.Where(u => u.Id == id)
                 .Select(u => new EditUserForAdminItem
                 {
                     Email = u.Email,
                     FirstName = u.FirstName,
                     IsActive = u.IsActive,
                     IsResmove = u.IsRemove,
                     Phone = u.Phone,
                     UserId = u.Id,
                     UserName = u.UserName,
                 }).FirstOrDefault();
        }

        #endregion

        #region Find User By User Name

        public GetUserItem FindUserByUserName(string userName)
        {
            return _context.users
                     .Where(x => x.UserName == userName)
                     .Select(x => new GetUserItem
                     {
                         Email = x.Email,
                         IsActive = x.IsActive,
                         IsRemove = x.IsRemove,
                         Password = x.Password,
                         UserId = x.Id,
                         UserName = x.UserName,
                     }).FirstOrDefault();
        }

        #endregion

        #region Get All User Course

        public List<UserCourseItem> GetAllUserCourse(long iserId)
        {
            return _context.UserCourses
      .Include(x => x.Course)
      .Where(x => x.UserId == iserId)
      .Select(x => new UserCourseItem
      {
          CourseId = x.CourseId,
          CourseImage = Router.RouteImageEducation +
          _context.Categories.
          FirstOrDefault(c => c.Id == x.Course.CategoryId).EnCategoryName
          + "/" + x.Course.CourseImage,
          CourseSummery = x.Course.CourseSummery,
          CourseTitle = x.Course.CourseTitle,

      })
      .ToList();
        }

        #endregion

        #region Get All Users

        public List<GetAllUserItem> GetAllUsers(bool isRemove)
        {
            return _context.users.Where(u => u.IsRemove == isRemove)
                 .Select(u => new GetAllUserItem
                 {
                     CreateDate = ConvertDate.MiladiToShamsi(u.CreateDate),
                     IsActive = u.IsActive,
                     IsRemove = isRemove,
                     UserName = u.UserName,
                     UserId = u.Id,
                     Wallet = u.Wallet,

                 }).OrderByDescending(u => u.UserId).ToList();
        }

        #endregion

        #region Get User By Id

        public UserDetailItem GetUserById(long UserId)
        {
            return _context.users
                    .Where(x => !x.IsRemove)
                    .Where(x => x.IsActive)
                    .Where(x => x.Id == UserId)
                    .Select(x => new UserDetailItem
                       {
                           Email = x.Email,
                           FirstName = x.FirstName,
                           LastName = x.LastName,
                           UserId = x.Id,
                           UserName = x.UserName,
                       }).FirstOrDefault();
        }

        #endregion


    }
}
