
using Kalvis.Contract.TicketViewModel;
using Kalvis.Contract.TicketViewModel.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Kalvis.Web.Areas.Admin.Pages.Ticket
{
    public class IndexModel : PageModel
    {
        #region Constracture
        private readonly ITicketApplication _TicketApp;
        public IndexModel(ITicketApplication TicketApp)
        {
            this._TicketApp = TicketApp;
        }
        #endregion

        public List<GetAllTicketForAdminItem> Ticket { get; set; }
        public void OnGet()
        {
            Ticket = _TicketApp.GetAllTicketForAdmin(false);
        }
    }
}
