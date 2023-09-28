using Kalvis.Common.Domain;
using Kalvis.Contract.PermissionViewModel;

namespace Kalvis.Domain.PermissionEntities.Interface
{
    public interface IRolePermissionRepository
        : IRepositoryBase<int, RolePermission>
    {
        List<GetAllPermissionItem> GetAllPermission(int RoleID);
        List<int> GetAllRoleForPermission(int PermissionID);
    }
}
