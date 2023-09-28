using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kalvis.Contract.NotificationViewModel.Interface;
using Kalvis.Contract.UserViewModel;
using Kalvis.Contract.UserViewModel.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.User.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        #region Constracture
        private readonly IUserApplication _UserApp;
        private readonly INotificationApplication _NotificationApp;
        public IndexModel(IUserApplication UserApp,
            INotificationApplication NotificationApp)
        {
            this._UserApp = UserApp;
            this._NotificationApp = NotificationApp;
        }
        #endregion

        public AccountDetailItem AccountDetail { get; set; }
        public void OnGet()
        {
            long UserId = long.Parse(User.FindFirst("userid").Value);
            AccountDetail = _UserApp.AccountDetail(UserId);

            AccountDetail.GetAllNotification = 
                _NotificationApp.GetAllNotification(false);
        }
    }
}
