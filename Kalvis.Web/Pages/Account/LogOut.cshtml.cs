
using Kalvis.Common.Application;
using Kalvis.Contract.AccountViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Pages.Account
{
    public class LogOutModel : PageModel
    {
        #region Constracture
        private readonly IAccountApplication _AccountApp;
        public LogOutModel(IAccountApplication AccountApp)
        {
            this._AccountApp = AccountApp;
        }
        #endregion
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                OperationResult operationResult
                 = _AccountApp.LogOut();

                TempData["OperationResult"] =
                    Newtonsoft.Json.JsonConvert.SerializeObject(operationResult);

                return RedirectToPage("./LogIn");
            }
            else
            {
                return RedirectToPage("./LogIn");
            }

        }
    }
}
