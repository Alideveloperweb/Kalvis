using Kalvis.Common.Application;
using Kalvis.Contract.PermissionViewModel;
using Kalvis.Domain.PermissionEntities;
using Kalvis.Domain.PermissionEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;


namespace Kalvis.EfCore.Repository.PermissionRepository
{
    public class RolePermissionRepository : RepositoryBase<int, RolePermission>
      , IRolePermissionRepository
    {
        #region Constracture
        private readonly ApplicationContext _context;
        public RolePermissionRepository(ApplicationContext context)
            : base(context)
        {
            this._context = context;
        }
        #endregion

        public List<GetAllPermissionItem> GetAllPermission(int RoleID)
        {
            return _context.RolePermissions
                .Where(x => x.RoleID == RoleID)
                .Select(x => new GetAllPermissionItem
                {
                    PermissionID = x.PermissionID,
                    RoleID = x.RoleID,
                    RPID = x.Id,
                })
                .ToList();
        }

        public List<int> GetAllRoleForPermission(int PermissionID)
        {
            return _context.RolePermissions
                .Where(x => x.PermissionID == PermissionID)
                .Select(x => x.RoleID).ToList();
        }

    }
}
