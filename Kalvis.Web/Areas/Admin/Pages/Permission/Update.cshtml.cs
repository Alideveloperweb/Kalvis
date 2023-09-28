
using Kalvis.Common.Application;
using Kalvis.Common.Security;
using Kalvis.Contract.PermissionViewModel;
using Kalvis.Contract.PermissionViewModel.Interfcae;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Kalvis.Web.Areas.Admin.Pages.Permission
{
    public class UpdateModel : PageModel
    {
        #region Constracture
        private readonly IPermissionApplication _PermissionApp;
        public UpdateModel(IPermissionApplication PermissionApp)
        {
            _PermissionApp = PermissionApp;
        }
        #endregion

        public List<permission> permissions { get; set; }
        public List<GetAllPermissionItem> GetAllPermission { get; set; }

        [BindProperty]
        public UpdateRoleItem UpdateRole { get; set; }
        public void OnGet(int id)
        {
            permission permission = new();
            permissions = permission.GetAllPermission();

            GetAllPermission = _PermissionApp.GetAllPermission(id);
            UpdateRole = _PermissionApp.FindRoleByID(id);
        }

        public IActionResult OnPost(UpdateRoleItem createRole)
        {
            OperationResult operationResult =
                _PermissionApp.UpdateRole(createRole);

            return RedirectToPage("./index");

        }

    }
}
