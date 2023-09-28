namespace Kalvis.Contract.OrderViewModel
{
    public class GetOrderItem
    {
        public long OrderID { get; set; }
        public long UserID { get; set; }
        public int TotalSum { get; set; }
        public bool IsPay { get; set; }
        public bool IsCancelled { get; set; }
    }
}
