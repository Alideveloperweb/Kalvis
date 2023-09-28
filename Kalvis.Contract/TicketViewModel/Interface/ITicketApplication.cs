using Kalvis.Common.Application;

namespace Kalvis.Contract.TicketViewModel.Interface
{
    public interface ITicketApplication
    {
        List<GetAllTicketItem> GetAllTicket(bool Isremove, long Userid);
        GetTicketItem GetTicketById(int TicketId, long UserId);
        GetTicketItem GetTicketById(int TicketId);
        OperationResult CreateTicket(CreateTicketItem Ticket);
        List<GetAllTicketForAdminItem> GetAllTicketForAdmin(bool IsRemove);
        List<GetAnswerItem> GetAllAnswer(int TicketID);
        OperationResult CreateAnswer(CreateAnswerItem createAnswer);
    }
}
