﻿
using System;

namespace Kalvis.Contract.CourseEpisodeViewModel
{
    public class GetAllEpisodeItem
    {
        public long EpisodeId { get; set; }
        public string EpisodeTitle { get; set; }
        public TimeSpan EpisodeTime { get; set; }
        public bool IsFree { get; set; }
        public long CourseId { get; set; }
    }
}
