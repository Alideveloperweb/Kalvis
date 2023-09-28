
namespace Kalvis.Contract.TicketViewModel
{
    public class GetAllTicketForAdminItem
    {
        public int TicketId { get; set; }
        public long UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string TicketTitle { get; set; }
        public string CreateDate { get; set; }
    }
}
