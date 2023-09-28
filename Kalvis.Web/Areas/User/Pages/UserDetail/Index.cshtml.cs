using Kalvis.Common.Application;
using Kalvis.Contract.UserViewModel;
using Kalvis.Contract.UserViewModel.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.User.Pages.UserDetail
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
        public UserDetailItem Detail { get; set; }
        public void OnGet()
        {
            long UserId = long.Parse(User.FindFirst("userid").Value);
            Detail = _UserApp.GetUserById(UserId);

        }

        public IActionResult OnPost()
        {
            long UserId = long.Parse(User.FindFirst("userid").Value);
            Detail.UserId = UserId;

            OperationResult operationResult =
                _UserApp.EditUser(Detail);

            TempData["OperationResult"] =
           Newtonsoft.Json.JsonConvert.SerializeObject
           (operationResult);

            return Page();
        }

    }
}
