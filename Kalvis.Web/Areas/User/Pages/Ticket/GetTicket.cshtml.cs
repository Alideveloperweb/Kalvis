using Kalvis.Contract.TicketViewModel;
using Kalvis.Contract.TicketViewModel.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.User.Pages.Ticket
{
    public class GetTicketModel : PageModel
    {
        #region Constracture
        private readonly ITicketApplication _TicketApp;
        public GetTicketModel(ITicketApplication TicketApp)
        {
            this._TicketApp = TicketApp;
        }
        #endregion

        public GetTicketItem Ticket { get; set; }
        public void OnGet(int id)
        {
            long UserId = long.Parse(User.FindFirst("userid").Value);
            Ticket = _TicketApp.GetTicketById(id, UserId);
        }
    }
}
