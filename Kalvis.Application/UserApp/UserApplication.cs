using Kalvis.Common.Application;
using Kalvis.Contract.UserViewModel.Interface;
using Kalvis.Contract.UserViewModel;
using Kalvis.Common.Security;
using Kalvis.Domain.UserEntities;
using Kalvis.Domain.UserEntities.Interface;

namespace Kalvis.Application.UserApp
{

    public class UserApplication : IUserApplication
    {
        #region Constracture
        private readonly IUserRepository _UserRep;
        public UserApplication(IUserRepository UserRep)
        {
            this._UserRep = UserRep;
        }
        #endregion

        #region Create User

        public OperationResult CreateUser(CreateUserItem createUser)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("کاربر");

            if (_UserRep.Exist(x => x.UserName == createUser.UserName))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("نام کاربری"));

            if (_UserRep.Exist(x => x.Email == createUser.Email))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("ایمیل"));

            if (_UserRep.Exist(x => x.Phone == createUser.Phone))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("تلفن"));

            User user = new(createUser.UserName, createUser.Email, createUser.Phone
                , createUser.Password.EncodePasswordMd5());

            bool create = _UserRep.Create(user);
            if (!create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());

            bool Save = _UserRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Create());

        }


        #endregion

        #region Find User For Edit In Admin

        public EditUserForAdminItem FindUserForEditInAdmin(long Userid)
        {
            return _UserRep.FindUserForEditInAdmin(Userid);
        }

        #endregion

        #region GetAllUsers

        public List<GetAllUserItem> GetAllUsers(bool IsRemove)
        {
            return _UserRep.getAllUsers(IsRemove);
        }

        #endregion

        #region Edit User For Admin

        public OperationResult EditUserForAdmin(EditUserForAdminItem editUser)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("کاربر");

            var user = _UserRep.Get(editUser.UserId);
            if (user == null)
                return operationResult.Failed(Operation.Nullabel, message.Nullabele());

            string Pass = string.IsNullOrWhiteSpace(editUser.Password) ? user.Password :
                editUser.Password.EncodePasswordMd5();

            user.EditUserForAdmin(editUser.FirstName, editUser.LastName,
                editUser.UserName, editUser.Email, editUser.Phone,
                Pass, editUser.IsActive, editUser.IsResmove);

            bool Update = _UserRep.Update(user);
            if (!Update)
                return operationResult.Failed(Operation.Error, message.ErrorUpdate());

            bool save = _UserRep.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Update());

        }


        #endregion

        #region Find User By User Name

        public GetUserItem FindUserByUserName(string UserName)
        {
            return _UserRep.FindUserByUserName(UserName);
        }

        #endregion

        #region Account Detail

        public AccountDetailItem AccountDetail(long UserId)
        {
            return _UserRep.AccountDetail(UserId);
        }

        #endregion

        #region Get All User Course

        public List<UserCourseItem> GetAllUserCourse(long UserId)
        {
            return _UserRep.GetAllUserCourse(UserId);
        }

        #endregion

        #region Get User By Id

        public UserDetailItem GetUserById(long UserId)
        {
            return _UserRep.GetUserById(UserId);
        }

        #endregion

        #region Edit User

        public OperationResult EditUser(UserDetailItem userDetail)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("کاربر");

            User user = _UserRep.Get(userDetail.UserId);

            if (user == null)
                return operationResult.Failed(Operation.Error, message.Nullabele());

            string UserImage = userDetail.Uploder != null
                ? "" : user.Avatar;

            if (userDetail.Uploder != null)
            {

                Uploder.RemoveFile(user.Avatar,
                    Router.RouteImageUser);

                UserImage = userDetail.Uploder.
                     Uplode(Router.RouteImageUser);
            }


            user.EditForUser(userDetail.FirstName, userDetail.LastName,
                userDetail.UserName, userDetail.Email, UserImage);

            bool Update = _UserRep.Update(user);
            if (!Update)
                return operationResult.Failed(Operation.Error, message.ErrorUpdate());

            bool Save = _UserRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Update());

        }


        #endregion

        #region Change Password

        public OperationResult ChangePassword(EditPasswordItem password)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("پسورد");

            User user = _UserRep.Get(password.Userid);
            if (user == null)
                return operationResult.Failed(Operation.Error, message.Nullabele());

            if (user.Password != password.OldPassword.EncodePasswordMd5())
                return operationResult.Failed(Operation.Error, message.ErrorChangePassword());

            user.ChangePassword(password.NewPassword.EncodePasswordMd5());

            bool Update = _UserRep.Update(user);
            if (!Update)
                return operationResult.Failed(Operation.Error, message.ErrorUpdate());

            bool Save = _UserRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Update());

        }

        #endregion

    }
}
