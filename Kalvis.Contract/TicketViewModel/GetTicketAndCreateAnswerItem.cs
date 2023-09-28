
namespace Kalvis.Contract.TicketViewModel
{
    public class GetTicketAndCreateAnswerItem
    {
        public List<GetAnswerItem> GetAllAnswer { get; set; }
        public GetTicketItem GetTicket { get; set; }
        public CreateAnswerItem CreateAnswer { get; set; }
    }
}
