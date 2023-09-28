
namespace Kalvis.Contract.CourseViewModel
{
    public class GetAllEpisodeForCourse
    {
        public long EpisodeID { get; set; }
        public string EpisodeTitle { get; set; }
        public TimeSpan EpisodeTime { get; set; }
        public string EpisodeLink { get; set; }
        public bool IsFree { get; set; }
    }
}
