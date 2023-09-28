
using Kalvis.Common.Application;
using Kalvis.Common.Security;
using Kalvis.Contract.PermissionViewModel;
using Kalvis.Contract.PermissionViewModel.Interfcae;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Kalvis.Web.Areas.Admin.Pages.Permission
{
    public class CreateModel : PageModel
    {
        #region Constracture
        private readonly IPermissionApplication _PermissionApp;
        public CreateModel(IPermissionApplication PermissionApp)
        {
            _PermissionApp = PermissionApp;
        }
        #endregion

        public List<permission> permissions { get; set; }
        public void OnGet()
        {
            permission permission = new();

            permissions = permission.GetAllPermission();
        }

        public IActionResult OnPost(CreateRoleItem createRole)
        {
            OperationResult operationResult =
                _PermissionApp.CreateRole(createRole);

            return RedirectToPage("./index");

        }

    }
}
