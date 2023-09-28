using Kalvis.Common.Application;

namespace Kalvis.Contract.UserViewModel.Interface
{
    public interface IUserApplication
    {
        OperationResult CreateUser(CreateUserItem createUser);

        OperationResult EditUserForAdmin(EditUserForAdminItem editUser);

        //-------------------------------

        List<GetAllUserItem> GetAllUsers(bool isRemove);
        EditUserForAdminItem FindUserForEditInAdmin(long userId);
        GetUserItem FindUserByUserName(string userName);
        AccountDetailItem AccountDetail(long userId);
        List<UserCourseItem> GetAllUserCourse(long userId);
        UserDetailItem GetUserById(long userId);
        OperationResult EditUser(UserDetailItem userDetail);
        OperationResult ChangePassword(EditPasswordItem editPassword);

    }
}
