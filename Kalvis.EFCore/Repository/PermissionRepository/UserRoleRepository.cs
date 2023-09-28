
using Kalvis.Common.Application;
using Kalvis.Contract.PermissionViewModel;
using Kalvis.Domain.PermissionEntities;
using Kalvis.Domain.PermissionEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;


namespace Kalvis.EfCore.Repository.PermissionRepository
{
    public class UserRoleRepository : RepositoryBase<int, UserRole>
        , IUserRoleRepository
    {

        #region Constracture
        private readonly ApplicationContext _context;
        public UserRoleRepository(ApplicationContext context)
            : base(context)
        {
            this._context = context;
        }

        #endregion

        public List<FindUserRoleItem> FindRoleForUser(long UserID)
        {
            return _context.userRoles
                .Where(x => x.UserID == UserID)
                .Select(x => new FindUserRoleItem
                {
                    RoleID = x.RoleID,

                })
                .ToList();
        }

        public List<int> GetAllUserRole(long UserID)
        {
            return _context.userRoles
                .Where(x => x.UserID == UserID)
                .Select(x => x.RoleID).ToList();
        }
    }
}
