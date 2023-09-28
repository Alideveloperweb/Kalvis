using Kalvis.Common.Domain;
using Kalvis.Contract.TicketViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Domain.TicketEntities.Interface
{
    public interface ITicketRepository
          : IRepositoryBase<int, Ticket>
    {
        List<GetAllTicketItem> GetAllTicket(bool Isremove, long Userid);
        GetTicketItem GetTicketById(int TicketId, long UserId);
        GetTicketItem GetTicketById(int TicketId);
        List<GetAllTicketForAdminItem> GetAllTicketForAdmin(bool IsRemove);
        List<GetAnswerItem> GetAllAnswer(int TicketID);
    }
}
