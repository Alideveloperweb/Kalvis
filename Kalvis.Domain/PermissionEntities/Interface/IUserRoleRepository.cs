using Kalvis.Common.Domain;
using Kalvis.Contract.PermissionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Domain.PermissionEntities.Interface
{
    public interface IUserRoleRepository
       : IRepositoryBase<int, UserRole>
    {
        List<FindUserRoleItem> FindRoleForUser(long UserID);
        List<int> GetAllUserRole(long UserID);
    }
}