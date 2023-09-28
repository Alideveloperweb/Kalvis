using System;

namespace Kalvis.Contract.CourseEpisodeViewModel
{
    public class CreateEpisodeItem
    {
        public long CourseId { get; set; }
        public string EpisodeTitle { get; set; }
        public TimeSpan EpisodeTime { get; set; }
        public string EpisodeLink { get; set; }
        public bool IsFree { get; set; }
    }
}
