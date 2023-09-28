using Kalvis.Common.Application;
using Kalvis.Contract.AccountViewModel;
using Kalvis.Contract.AccountViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Pages.Account
{
    public class RegisterModel : PageModel
    {
        #region Constracture
        private readonly IAccountApplication _AccountApp;
        public RegisterModel(IAccountApplication AccountApp)
        {
            _AccountApp = AccountApp;
        }
        #endregion

        [BindProperty]
        public RegisterItem Register { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            OperationResult operationResult =
                _AccountApp.Register(Register);

            TempData["OperationResult"] =
                Newtonsoft.Json.JsonConvert.SerializeObject(operationResult);

            return RedirectToPage("./Register");
        }

        public IActionResult OnGetActive(string CodeActive, long UserID)
        {

            OperationResult operationResult =
              _AccountApp.ActiveEmail(UserID, CodeActive);

            TempData["OperationResult"] =
                Newtonsoft.Json.JsonConvert.SerializeObject(operationResult);

            return RedirectToPage("./Register");
        }

    }
}
