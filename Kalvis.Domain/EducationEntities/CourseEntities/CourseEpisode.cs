
using Kalvi.Common.Domain;
using System;

namespace Kalvi.Domain.EducationEntities.CourseEntities
{
    public class CourseEpisode : EntityBase<long>
    {

        public long CourseId { get; private set; }
        public string EpisodeTitle { get; private set; }
        public TimeSpan EpisodeTime { get; private set; }
        public string LinkEpisode { get; private set; }
        public bool IsFree { get; private set; }


        #region Create
        public CourseEpisode(long CourseId, string EpisodeTitle,
             TimeSpan EpisodeTime, string LinkEpisode, bool IsFree)
        {
            this.CourseId = CourseId;
            this.EpisodeTitle = EpisodeTitle;
            this.EpisodeTime = EpisodeTime;
            this.LinkEpisode = LinkEpisode;
            this.IsFree = IsFree;
        }
        #endregion

        #region Edit
        public void Edit(long CourseId, string EpisodeTitle,
     TimeSpan EpisodeTime, string LinkEpisode, bool IsFree)
        {
            this.CourseId = CourseId;
            this.EpisodeTitle = EpisodeTitle;
            this.EpisodeTime = EpisodeTime;
            this.LinkEpisode = LinkEpisode;
            this.IsFree = IsFree;
            this.LastUpdate = DateTime.Now;
        }
        #endregion

        #region Relation
        public Course Course { get; private set; }

        #endregion


    }
}
