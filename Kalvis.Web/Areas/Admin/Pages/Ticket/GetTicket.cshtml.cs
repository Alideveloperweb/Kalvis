using Kalvis.Common.Application;
using Kalvis.Contract.TicketViewModel;
using Kalvis.Contract.TicketViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.Ticket
{
    public class GetTicketModel : PageModel
    {
        #region Constracture
        private readonly ITicketApplication _TicketApp;
        public GetTicketModel(ITicketApplication TicketApp)
        {
            _TicketApp = TicketApp;
        }
        #endregion

        [BindProperty]
        public GetTicketAndCreateAnswerItem GetTicket { get; set; }

        public void OnGet(int id)
        {
            GetTicket = new();
            GetTicket.GetTicket = _TicketApp.GetTicketById(id);
            GetTicket.GetAllAnswer = _TicketApp.GetAllAnswer(id);
        }

        public IActionResult OnPost()
        {
            OperationResult operationResult =
                _TicketApp.CreateAnswer(GetTicket.CreateAnswer);

            TempData["OperationResult"] =
                Newtonsoft.Json.JsonConvert.SerializeObject(operationResult);

            return RedirectToPage("./Index");
        }

    }
}
