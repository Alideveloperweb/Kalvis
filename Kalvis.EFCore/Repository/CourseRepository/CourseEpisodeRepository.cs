using Kalvis.Domain.EducationEntities.CourseEntities;
using Kalvis.Common.Application;
using Kalvis.Contract.CourseEpisodeViewModel;
using Kalvis.EFCore.ApplicationContexts;
using Kalvis.Domain.EducationEntities.CourseEntities.Interface;

namespace Kalvis.EFCore.Repository.CourseRepository
{
    public class CourseEpisodeRepository : RepositoryBase<long, CourseEpisode>
       , ICourseEpisodeRepository
    {

        #region Constracture
        private readonly ApplicationContext _context;
        public CourseEpisodeRepository(ApplicationContext context)
            : base(context)
        {
            this._context = context;
        }
        #endregion

        public EditEpisodeItem FindEpisodeForEdit(long EpisodeId)
        {
            return _context.CourseEpisodes
                .Where(x => x.Id == EpisodeId)
                .Select(x => new EditEpisodeItem
                {
                    CourseId = x.CourseId,
                    EpisodeId = x.Id,
                    EpisodeLink = x.LinkEpisode,
                    EpisodeTime = x.EpisodeTime,
                    EpisodeTitle = x.EpisodeTitle,
                    IsFree = x.IsFree,
                }).FirstOrDefault();

        }

        public RemoveEpisodeItem FindEpisodeForRemove(long EpisodeId)
        {
            return _context.CourseEpisodes
                 .Where(x => x.Id == EpisodeId)
                 .Select(x => new RemoveEpisodeItem
                 {
                     EpisodeId = x.Id,
                     EpisodeTitle = x.EpisodeTitle,
                     CourseId = x.CourseId,
                 }).FirstOrDefault();
        }

        public List<GetAllEpisodeItem> GetAllEpisode(long CourseId)
        {
            return _context.CourseEpisodes
                 .Where(x => x.CourseId == CourseId)
                 .Select(x => new GetAllEpisodeItem
                 {
                     CourseId = x.CourseId,
                     EpisodeId = x.Id,
                     EpisodeTime = x.EpisodeTime,
                     EpisodeTitle = x.EpisodeTitle,
                     IsFree = x.IsFree,

                 })
                 .ToList();

        }
    }
}
