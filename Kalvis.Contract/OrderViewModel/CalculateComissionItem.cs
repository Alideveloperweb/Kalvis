
namespace Kalvis.Contract.OrderViewModel
{
    public class CalculateComissionItem
    {
        public byte Comission { get; set; }
        public long OrderID { get; set; }
        public long CourseID { get; set; }
        public string DisCountCode { get; set; }
        public byte? DiscountPercent { get; set; }
        public long UserID { get; set; }
        public int CoursePrice { get; set; }
    }
}
