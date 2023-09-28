using Kalvis.Common.Application;

namespace Kalvis.Contract.PermissionViewModel.Interfcae
{
    public interface IPermissionApplication
    {
        List<GetAllRoleItem> GetAllRole(bool IsRemove);
        OperationResult CreateRole(CreateRoleItem createRole);
        UpdateRoleItem FindRoleByID(int RoleID);
        List<GetAllPermissionItem> GetAllPermission(int RoleID);
        OperationResult UpdateRole(UpdateRoleItem update);
        List<FindUserRoleItem> FindRoleForUser(long UserID);
        OperationResult UpdateRoleUser(List<AddUserRoleItem> addUserRole, long userid);
        bool CheckPermission(int PermissionID, long UserID);
    }
}
