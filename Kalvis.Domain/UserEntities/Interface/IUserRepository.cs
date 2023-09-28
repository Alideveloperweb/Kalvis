using Kalvis.Common.Domain;
using Kalvis.Contract.UserViewModel;


namespace Kalvis.Domain.UserEntities.Interface
{
    public interface IUserRepository : IRepositoryBase<long, User>
    {
        List<GetAllUserItem> getAllUsers(bool IsRemove);
        EditUserForAdminItem FindUserForEditInAdmin(long Userid);
        GetUserItem FindUserByUserName(string UserName);
        AccountDetailItem AccountDetail(long UserId);
        List<UserCourseItem> GetAllUserCourse(long UserId);
        UserDetailItem GetUserById(long UserId);
    }
}
