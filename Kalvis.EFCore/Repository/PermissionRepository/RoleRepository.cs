using Kalvis.Common.Application;
using Kalvis.Contract.PermissionViewModel;
using Kalvis.Domain.PermissionEntities;
using Kalvis.Domain.PermissionEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;


namespace Kalvis.EfCore.Repository.PermissionRepository
{
    public class RoleRepository : RepositoryBase<int, Role>,
          IRoleRepository
    {
        #region Constracture
        private readonly ApplicationContext _context;
        public RoleRepository(ApplicationContext context)
            : base(context)
        {
            this._context = context;
        }

        #endregion


        public List<GetAllRoleItem> GetAllRole(bool IsRemove)
        {
            return _context.Roles
                .Where(x => x.IsRemove == IsRemove)
                .Select(x => new GetAllRoleItem
                {
                    RoleID = x.Id,
                    RoleTitle = x.RoleTitle,

                })
                .OrderByDescending(x => x.RoleID)
                .ToList();

        }

        public UpdateRoleItem FindRoleByID(int RoleID)
        {
            return _context.Roles
                .Where(x => x.Id == RoleID)
                .Select(x => new UpdateRoleItem
                {
                    RoleID = x.Id,
                    RoleTitle = x.RoleTitle,

                })
                .FirstOrDefault();
        }
    }
}
