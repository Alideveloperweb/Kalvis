using Kalvis.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Domain.PermissionEntities
{
    public class RolePermission : EntityBase<int>
    {
        public int RoleID { get; private set; }
        public int PermissionID { get; private set; }

        #region Create
        public RolePermission(int RoleID, int PermissionID)
        {
            this.RoleID = RoleID;
            this.PermissionID = PermissionID;
        }
        #endregion

        #region Relation
        public Role Role { get; private set; }
        #endregion

    }
}
