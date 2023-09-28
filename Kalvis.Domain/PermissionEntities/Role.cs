using Kalvis.Common.Domain;

namespace Kalvis.Domain.PermissionEntities
{
    public class Role : EntityBase<int>
    {
        public string RoleTitle { get; private set; }


        #region Create
        public Role(string RoleTitle)
        {
            this.RoleTitle = RoleTitle;
        }
        #endregion

        #region Edit
        public void Edit(string RoleTitle)
        {
            this.RoleTitle = RoleTitle;
        }
        #endregion

        #region Relation
        public List<RolePermission> RolePermissions { get; private set; }
        public List<UserRole> UserRoles { get; private set; }
        #endregion
    }
}
