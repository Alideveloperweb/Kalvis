﻿using Kalvis.Common.Domain;
using Kalvis.Contract.CourseEpisodeViewModel;

namespace Kalvis.Domain.EducationEntities.CourseEntities.Interface
{
    public interface ICourseEpisodeRepository : IRepositoryBase<long, CourseEpisode>
    {
        List<GetAllEpisodeItem> GetAllEpisode(long CourseId);
        EditEpisodeItem FindEpisodeForEdit(long EpisodeId);
        RemoveEpisodeItem FindEpisodeForRemove(long EpisodeId);
    }
}
