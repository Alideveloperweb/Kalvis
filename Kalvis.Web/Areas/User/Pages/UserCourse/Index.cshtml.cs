using Kalvis.Contract.UserViewModel;
using Kalvis.Contract.UserViewModel.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Kalvis.Web.Areas.User.Pages.UserCourse
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

        public List<UserCourseItem> UserCourse { get; set; }
        public void OnGet()
        {
            long userid = long.Parse(User.FindFirst("userid").Value);
            UserCourse = _UserApp.GetAllUserCourse(userid);
        }
    }
}
