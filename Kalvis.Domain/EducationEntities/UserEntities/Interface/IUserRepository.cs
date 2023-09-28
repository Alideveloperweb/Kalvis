using Kalvis.Common.Domain;
using Kalvis.Contract.UserViewModel;

namespace Kalvis.Domain.EducationEntities.UserEntities.Interface
{
    public interface IUserRepository:IRepositoryBase<long ,User>
    {
        List<GetAllUserItem> GetAllUsers(bool isRemove);
        EditUserForAdminItem FindUserForEditInAdmin(long id);
        GetUserItem FindUserByUserName(string userName);
        AccountDetailItem AccountDetail(long userId);
        List<UserCourseItem> GetAllUserCourse(long userId);
        UserDetailItem GetUserById(long userId);

    }
}
