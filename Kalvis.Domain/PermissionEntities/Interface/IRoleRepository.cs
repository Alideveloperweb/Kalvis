using Kalvis.Common.Domain;
using Kalvis.Contract.PermissionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Domain.PermissionEntities.Interface
{
    public interface IRoleRepository : IRepositoryBase<int, Role>
    {
        List<GetAllRoleItem> GetAllRole(bool IsRemove);
        UpdateRoleItem FindRoleByID(int RoleID);
    }
}
