
using Kalvis.Common.Application;
using Kalvis.Contract.PermissionViewModel;
using Kalvis.Contract.PermissionViewModel.Interfcae;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Kalvis.Web.Areas.Admin.Pages.Permission
{
    public class CreateOrUpdateUserRoleModel : PageModel
    {
        #region Constracture
        private readonly IPermissionApplication _PermissionApp;
        public CreateOrUpdateUserRoleModel(IPermissionApplication PermissionApp)
        {
            this._PermissionApp = PermissionApp;
        }
        #endregion

        public List<FindUserRoleItem> FindRoleUser { get; set; }
        public List<GetAllRoleItem> GetAllRole { get; set; }
        public void OnGet(long id)
        {
            FindRoleUser = _PermissionApp.FindRoleForUser(id);
            GetAllRole = _PermissionApp.GetAllRole(false);
            TempData["userid"] = id;
        }

        public IActionResult OnPost(long UserID, List<int> RoleID)
        {
            List<AddUserRoleItem> addUserRoleItems = new();
            foreach (var item in RoleID)
                addUserRoleItems.Add(new AddUserRoleItem
                {
                    RoleID = item,
                    UserID = UserID,
                });

            OperationResult operationResult =
                _PermissionApp.UpdateRoleUser(addUserRoleItems, UserID);

            return RedirectToPage("./index");

        }

    }
}
