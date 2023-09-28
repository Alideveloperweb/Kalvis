using Kalvis.Contract.PermissionViewModel;
using Kalvis.Domain.PermissionEntities.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Kalvis.Web.Areas.Admin.Pages.Permission
{
    public class IndexModel : PageModel
    {
        #region Constracture
        private readonly IRoleRepository _RoleRep;
        public IndexModel(IRoleRepository RoleRep)
        {
            this._RoleRep = RoleRep;
        }
        #endregion
        public List<GetAllRoleItem> Role { get; set; }
        public void OnGet()
        {
            Role = _RoleRep.GetAllRole(false);
        }
    }
}
