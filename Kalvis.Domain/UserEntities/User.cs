
using Kalvis.Common.Application;
using Kalvis.Common.Domain;
using Kalvis.Domain.EducationEntities.CommentEntities;
using Kalvis.Domain.EducationEntities.CourseEntities;
using Kalvis.Domain.EducationEntities.TeacherEntities;
using Kalvis.Domain.OrderEntities.CourseOrderEntities;
using Kalvis.Domain.PermissionEntities;
using Kalvis.Domain.TicketEntities;
using System.Collections.Generic;

namespace Kalvis.Domain.UserEntities
{
    public class User : EntityBase<long>
    {
        #region Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Avatar { get; private set; }
        public string Password { get; private set; }
        public string ActiveCode { get; private set; }
        public bool IsActive { get; private set; }
        public int Wallet { get; private set; }
        #endregion

        #region ChangePassword
        public void ChangePassword(string Password)
        {
            this.Password = Password;
        }
        #endregion

        #region Create
        public User(string UserName, string Email, string Phone,
             string Password)
        {

            this.UserName = UserName;
            this.Email = Email;
            this.Phone = Phone;
            this.Password = Password;
            this.ActiveCode = Generator.Generator_Code(10);
            this.IsActive = false;
            this.Wallet = 0;

        }
        #endregion

        #region Edit
        public void Edit(string FirstName, string LastName,
     string UserName, string Email, string Phone,
     string Avatar, string Password, string ActiveCode,
     bool IsActive, int Wallet)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.Email = Email;
            this.Phone = Phone;
            this.Avatar = Avatar;
            this.Password = Password;
            this.ActiveCode = ActiveCode;
            this.IsActive = IsActive;
            this.Wallet = Wallet;

        }
        #endregion

        #region EditForUser
        public void EditForUser(string FirstName, string LastName,
                          string UserName, string Email, string Avatar)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.Email = Email;
            this.Avatar = Avatar;
        }
        #endregion

        #region Edit User For Admin
        public void EditUserForAdmin(string FirstName, string LastName,
     string UserName, string Email, string Phone,
     string Password, bool IsActive, bool IsRemove)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.Email = Email;
            this.Phone = Phone;
            this.IsRemove = IsRemove;
            this.Password = Password;
            this.IsActive = IsActive;

        }
        #endregion

        #region ActiveAccount
        public void ActiveAccount()
        {
            this.IsActive = true;
        }
        #endregion

        #region Comssion
        public void Comssion(int Wallet)
        {
            this.Wallet = Wallet;
        }
        #endregion

        #region Remove
        public void Remove()
        {
            this.IsRemove = true;
        }
        #endregion

        #region Restore
        public void Restore()
        {
            this.IsRemove = false;
        }
        #endregion

        #region Relation
        public List<Teacher> Teachers { get; set; }
        public List<CourseComment> CourseComments { get; set; }
        public List<Course> Courses { get; set; }
        public List<UserCourse> UserCourses { get; private set; }
        public List<CourseOrders> CourseOrders { get; private set; }
        public List<Ticket> Tickets { get; private set; }
        public List<AnswerComment> AnswerComments { get; private set; }
        public List<UserRole> UserRoles { get; private set; }
        #endregion

    }
}
