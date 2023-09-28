using Kalvis.Common.Application;
using Kalvis.Contract.UserViewModel;
using Kalvis.Contract.UserViewModel.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.User.Pages.ChangePassword
{
    [Authorize]
    public class IndexModel : PageModel
    {
        #region Constracture
        private readonly IUserApplication _UserApp;
        public IndexModel(IUserApplication UserApp)
        {
            this._UserApp = UserApp;
        }
        #endregion

        [BindProperty]
        public EditPasswordItem Password { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            long UserId = long.Parse(User.FindFirst("userid").Value);
            Password.Userid = UserId;

            OperationResult operationResult =
                _UserApp.ChangePassword(Password);

            TempData["OperationResult"] =
                    Newtonsoft.Json.JsonConvert.SerializeObject
                    (operationResult);

            return Page();
        }

    }
}
