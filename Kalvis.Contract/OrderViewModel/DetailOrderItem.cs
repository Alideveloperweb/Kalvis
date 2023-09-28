
namespace Kalvis.Contract.OrderViewModel
{
    public class DetailOrderItem
    {
        public long DetailID { get; set; }
        public long OrderID { get; set; }
        public long CourseID { get; set; }
        public long UserID { get; set; }
        public int Price { get; set; }
        public string CourseTitle { get; set; }
        public string CourseImage { get; set; }
    }
}
