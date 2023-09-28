using Kalvis.Common.Application;
using Kalvis.Contract.AccountViewModel;
using Kalvis.Contract.AccountViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        #region Constracture
        private readonly IAccountApplication _AccountApp;
        public LoginModel(IAccountApplication AccountApp)
        {
            this._AccountApp = AccountApp;
        }
        #endregion

        [BindProperty]
        public LoginItem login { get; set; }
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToPage("../Index");

            return Page();
        }

        public IActionResult OnPost()
        {
            OperationResult operationResult
                = _AccountApp.Login(login);

            TempData["OperationResult"] =
                Newtonsoft.Json.JsonConvert.SerializeObject(operationResult);

            if (operationResult.Code == Operation.Success)
                TempData["LoginSuccess"]
                    = AccountMassage.LogInUser;

            return Page();

        }

    }
}
