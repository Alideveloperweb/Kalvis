using Kalvis.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Contract.UserViewmodel.Interface
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
        List<UserCourseItem> GetAllUserCourse(bool userId);
        UserDetailItem GetUserById(long userId);
        OperationResult EgitUser(UserDetailItem userDetail);
        OperationResult ChangePassword(EditPasswordItem editPassword);

    }
}
