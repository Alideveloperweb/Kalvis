using Kalvis.Common.Application;
using Kalvis.Contract.TicketViewModel;
using Kalvis.Contract.TicketViewModel.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.User.Pages.Ticket
{
    [Authorize]
    public class IndexModel : PageModel
    {
        #region Constracture
        private readonly ITicketApplication _TicketApp;
        public IndexModel(ITicketApplication TicketApp)
        {
            this._TicketApp = TicketApp;
        }

        #endregion

        [BindProperty]
        public CreateTicketItem Create { get; set; }
        public List<GetAllTicketItem> Ticket { get; set; }
        public void OnGet()
        {
            long UserId = long.Parse(User.FindFirst("userid").Value);
            Ticket = _TicketApp.GetAllTicket(false, UserId);
        }

        public void OnPost()
        {
            long UserId = long.Parse(User.FindFirst("userid").Value);
            Create.UserId = UserId;

            OperationResult operationResult =
                _TicketApp.CreateTicket(Create);

            TempData["OperationResult"] =
                    Newtonsoft.Json.JsonConvert.SerializeObject
                    (operationResult);

            Ticket = _TicketApp.GetAllTicket(false, UserId);
        }
    }
}
