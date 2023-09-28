
namespace Kalvis.Contract.DisCountViewModel.CourseDisCountViewModel
{
    public class DisCountOrderItem
    {
        public int DisCountID { get; set; }
        public long OrderID { get; set; }
        public string DisCountCode { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public int UseDisCount { get; set; }

    }
}
