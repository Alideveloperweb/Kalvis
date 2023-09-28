
using Kalvis.Common.Application;
using Kalvis.Contract.PermissionViewModel;
using Kalvis.Contract.PermissionViewModel.Interfcae;
using Kalvis.Domain.PermissionEntities;
using Kalvis.Domain.PermissionEntities.Interface;
using Kalvis.Domain.UserEntities.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Kalvis.Application.PermissionApp
{
    public class PermissionApplication : IPermissionApplication
    {
        #region Constracture
        private readonly IRoleRepository _RoleRep;
        private readonly IRolePermissionRepository _RolePermissionRep;
        private readonly IUserRoleRepository _UserRoleRep;
        private readonly IUserRepository _UserRep;
        public PermissionApplication(
            IRoleRepository RoleRep,
           IRolePermissionRepository RolePermissionRep,
           IUserRoleRepository UserRoleRep, IUserRepository UserRep)
        {
            _RoleRep = RoleRep;
            _RolePermissionRep = RolePermissionRep;
            _UserRoleRep = UserRoleRep;
            _UserRep = UserRep;
        }

        #endregion

        public List<GetAllRoleItem> GetAllRole(bool IsRemove)
        {
            return _RoleRep.GetAllRole(IsRemove);
        }

        public OperationResult CreateRole(CreateRoleItem createRole)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("نقش");

            if (_RoleRep.Exist(x => x.RoleTitle == createRole.RoleTile))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("عنوان"));

            Role role = new(createRole.RoleTile);
            bool Create = _RoleRep.Create(role);
            if (!Create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());

            bool save = _RoleRep.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            CreateOrUpdatePermission(role.Id, createRole.PermissionID);

            return operationResult.Success(Operation.Success, message.Create());

        }

        public void CreateOrUpdatePermission(int RoleID, List<int> PermissionID)
        {
            List<RolePermission> rolePermissions = new();

            List<RolePermission> permision = _RolePermissionRep.GetAll()
                .Where(x => x.RoleID == RoleID).ToList();

            if (permision.Count() > 0)
                _RolePermissionRep.RemoveRange(permision);

            if (PermissionID != null && PermissionID.Count() > 0)
            {
                foreach (var item in PermissionID)
                    rolePermissions.Add(new RolePermission(RoleID, item));
            }


            _RolePermissionRep.CreateRange(rolePermissions);
            _RolePermissionRep.SaveChanges();

        }

        public UpdateRoleItem FindRoleByID(int RoleID)
        {
            return _RoleRep.FindRoleByID(RoleID);
        }

        public List<GetAllPermissionItem> GetAllPermission(int RoleID)
        {
            return _RolePermissionRep.GetAllPermission(RoleID);
        }

        public OperationResult UpdateRole(UpdateRoleItem update)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("نقش");

            if (_RoleRep.Exist(x =>
            x.Id != update.RoleID &&
            x.RoleTitle == update.RoleTitle))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("عنوان"));

            Role role = _RoleRep.Get(update.RoleID);
            role.Edit(update.RoleTitle);
            bool Update = _RoleRep.Update(role);
            if (!Update)
                return operationResult.Failed(Operation.Error, message.ErrorUpdate());

            bool save = _RoleRep.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            CreateOrUpdatePermission(role.Id, update.PermissionID);

            return operationResult.Success(Operation.Success, message.Create());

        }

        public List<FindUserRoleItem> FindRoleForUser(long UserID)
        {
            return _UserRoleRep.FindRoleForUser(UserID);
        }

        public OperationResult UpdateRoleUser(List<AddUserRoleItem> addUserRole, long userid)
        {
            OperationResult operationResult = new();
            List<UserRole> userRoles = new();

            var userrole = _UserRoleRep.GetAll()
                .Where(x => x.UserID == userid).ToList();

            if (userrole.Count() > 0)
                _UserRoleRep.RemoveRange(userrole);

            foreach (var item in addUserRole)
                userRoles.Add(new UserRole(item.RoleID, userid));

            bool Create = _UserRoleRep.CreateRange(userRoles);
            if (!Create)
                return operationResult.Failed(Operation.Error);

            bool save = _UserRoleRep.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error);

            return operationResult.Success(Operation.Success);
        }

        public bool CheckPermission(int PermissionID, long UserID)
        {
            var User = _UserRep.Get(UserID);
            var ListPermission = _RolePermissionRep.GetAllRoleForPermission(PermissionID);
            var ListRole = _UserRoleRep.GetAllUserRole(UserID);

            if (User == null)
                return false;

            if (!User.IsActive || User.IsRemove)
                return false;

            if (!ListRole.Any())
                return false;

            return ListPermission.Any(x => ListRole.Contains(x));
        }
    }
}
