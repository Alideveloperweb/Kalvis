
namespace Kalvis.Contract.DisCountViewModel.CourseDisCountViewModel
{
    public class GetAllCourseDisCountItem
    {
        public int CourseDisCountID { get; set; }
        public string Code { get; set; }
        public byte Value { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? MaxUserCount { get; set; }
    }
}
