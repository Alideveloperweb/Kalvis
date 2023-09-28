using Kalvis.Common.Domain;
using Kalvis.Domain.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Domain.PermissionEntities
{
    public class UserRole : EntityBase<int>
    {
        public int RoleID { get; private set; }
        public long UserID { get; private set; }

        #region Create
        public UserRole(int RoleID, long UserID)
        {
            this.RoleID = RoleID;
            this.UserID = UserID;
        }
        #endregion

        #region Relation
        public Role Role { get; private set; }
        public User User { get; set; }
        #endregion
    }
}