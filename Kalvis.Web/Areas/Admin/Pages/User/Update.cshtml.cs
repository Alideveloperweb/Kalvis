using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kalvis.Contract.UserViewModel;
using Kalvis.Contract.UserViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.User
{
    public class UpdateModel : PageModel
    {
        #region Constracture
        private readonly IUserApplication _UserApp;
        public UpdateModel(IUserApplication UserApp)
        {
            this._UserApp = UserApp;
        }
        #endregion

        [BindProperty]
        public EditUserForAdminItem EditUser { get; set; }

        public void OnGet(long id)
        {
            EditUser = _UserApp.FindUserForEditInAdmin(id);
        }

        public IActionResult OnPost()
        {

            var b = _UserApp.EditUserForAdmin(EditUser);
            return RedirectToPage("./Index");
        }
    }
}
