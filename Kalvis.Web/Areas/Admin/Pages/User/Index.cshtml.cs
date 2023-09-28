using Kalvis.Contract.UserViewModel;
using Kalvis.Contract.UserViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Kalvis.Web.Areas.Admin.Pages.User
{
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
        public List<GetAllUserItem> GetAllUser { get; set; }
        public void OnGet()
        {
            GetAllUser = _UserApp.GetAllUsers(false);
        }
    }
}
