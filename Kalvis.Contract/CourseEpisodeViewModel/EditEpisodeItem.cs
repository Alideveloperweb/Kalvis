using System;

namespace Kalvis.Contract.CourseEpisodeViewModel
{
    public class EditEpisodeItem
    {
        public long EpisodeId { get; set; }
        public long CourseId { get; set; }
        public string EpisodeTitle { get; set; }
        public TimeSpan EpisodeTime { get; set; }
        public string EpisodeLink { get; set; }
        public bool IsFree { get; set; }
    }
}
