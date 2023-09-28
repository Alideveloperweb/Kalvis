using Kalvis.Domain.EducationEntities.CourseEntities.Interface;
using Kalvis.Common.Application;
using Kalvis.Contract.CourseEpisodeViewModel;
using Kalvis.Contract.CourseEpisodeViewModel.Interface;
using Kalvis.Domain.EducationEntities.CourseEntities;

namespace Kalvis.Application.CourseApp
{
    public class CourseEpisodeApplication : ICourseEpisodeApplication
    {
        #region Constracture
        private readonly ICourseEpisodeRepository _EpisodeRep;
        private readonly ICourseRepository _CourseRep;
        public CourseEpisodeApplication(ICourseEpisodeRepository EpisodeRep,
            ICourseRepository CourseRep)
        {
            this._CourseRep = CourseRep;
            this._EpisodeRep = EpisodeRep;
        }
        #endregion


        public OperationResult CreateEpisode(CreateEpisodeItem CreateEpisode)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("قسمت");

            if (_EpisodeRep.Exist(x => x.EpisodeTitle == CreateEpisode.EpisodeTitle))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("عنوان"));

            CourseEpisode courseEpisode = new(CreateEpisode.CourseId,
                CreateEpisode.EpisodeTitle, CreateEpisode.EpisodeTime,
                CreateEpisode.EpisodeLink, CreateEpisode.IsFree);

            bool Create = _EpisodeRep.Create(courseEpisode);
            if (!Create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());

            bool Save = _EpisodeRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Create());
        }

        public DownloadItem Download(long EpisodeID, bool IsAuthenticated, long UserID)
        {
            ApplicationMessage message = new("فایل");
            DownloadItem download = new()
            {
                Allowed = false,
                url = "/",
                Message = "",
            };

            CourseEpisode episode = _EpisodeRep.Get(EpisodeID);
            if (episode == null)
            {
                download.Message = message.Nullabele();
                return download;
            }

            if (IsAuthenticated && episode != null)
            {
                if (episode.IsFree)
                {
                    download.url = episode.LinkEpisode ?? "/";
                    download.Allowed = true;
                }
                else
                {
                    if (_CourseRep.Buyer(UserID, episode.CourseId))
                    {
                        download.url = episode.LinkEpisode ?? "/";
                        download.Allowed = true;
                    }
                }
            }

            return download;

        }

        public OperationResult EditEpisode(EditEpisodeItem EditEpisode)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("قسمت");

            if (_EpisodeRep.Exist(x =>
            x.Id != EditEpisode.EpisodeId &&
            x.EpisodeTitle == EditEpisode.EpisodeTitle))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("عنوان"));

            CourseEpisode courseEpisode = _EpisodeRep.Get(EditEpisode.EpisodeId);

            if (courseEpisode == null)
                return operationResult.Failed(Operation.Nullabel, message.Nullabele());


            courseEpisode.Edit(EditEpisode.CourseId,
                    EditEpisode.EpisodeTitle, EditEpisode.EpisodeTime,
                    EditEpisode.EpisodeLink, EditEpisode.IsFree);

            bool Update = _EpisodeRep.Update(courseEpisode);
            if (!Update)
                return operationResult.Failed(Operation.Error, message.ErrorUpdate());

            bool Save = _EpisodeRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Update());
        }

        public EditEpisodeItem FindEpisodeForEdit(long EpisodeId)
        {
            return _EpisodeRep.FindEpisodeForEdit(EpisodeId);
        }

        public RemoveEpisodeItem FindEpisodeForRemove(long EpisodeId)
        {
            return _EpisodeRep.FindEpisodeForRemove(EpisodeId);
        }

        public List<GetAllEpisodeItem> GetAllEpisode(long CourseId)
        {
            return _EpisodeRep.GetAllEpisode(CourseId);
        }



        public OperationResult RemoveEpisode(RemoveEpisodeItem RemoveEpisode)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("قسمت");

            CourseEpisode courseEpisode =
                _EpisodeRep.Get(RemoveEpisode.EpisodeId);

            if (courseEpisode == null)
                return operationResult.Failed(Operation.Nullabel, message.Nullabele());

            bool Remove = _EpisodeRep.Remove(courseEpisode);
            if (!Remove)
                return operationResult.Failed(Operation.Error, message.ErrorRemove());

            bool Save = _EpisodeRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Remove());

        }
    }
}
