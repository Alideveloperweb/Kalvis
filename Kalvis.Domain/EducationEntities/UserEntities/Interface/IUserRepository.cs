using Kalvi.Common.Domain;
using Kalvis.Contract.CategoryViewModel;
using Kalvis.Contract.UserViewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
