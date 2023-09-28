using Kalvis.Common.Application;

namespace Kalvis.Contract.CourseEpisodeViewModel.Interface
{
    public interface ICourseEpisodeApplication
    {
        List<GetAllEpisodeItem> GetAllEpisode(long CourseId);
        OperationResult CreateEpisode(CreateEpisodeItem CreateEpisode);
        EditEpisodeItem FindEpisodeForEdit(long EpisodeId);
        OperationResult EditEpisode(EditEpisodeItem EditEpisode);
        OperationResult RemoveEpisode(RemoveEpisodeItem RemoveEpisode);
        RemoveEpisodeItem FindEpisodeForRemove(long EpisodeId);
        DownloadItem Download(long EpisodeID, bool IsAuthenticated, long UserID);
    }
}
