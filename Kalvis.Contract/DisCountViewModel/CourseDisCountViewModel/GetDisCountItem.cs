
namespace Kalvis.Contract.DisCountViewModel.CourseDisCountViewModel
{
    public class GetDisCountItem
    {
        public int DisCountID { get; set; }
        public string DisCountCode { get; set; }
        public byte Persistant { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? UserCount { get; set; }
    }
}
