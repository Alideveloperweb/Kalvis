using Kalvis.Common.Application;
using Kalvis.Contract.CourseEpisodeViewModel;
using Kalvis.Contract.CourseEpisodeViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Kalvis.Web.Areas.Admin.Pages.Episode
{
    public class IndexModel : PageModel
    {
        #region Constracture
        private readonly ICourseEpisodeApplication _EpisodeApp;
        public IndexModel(ICourseEpisodeApplication EpisodeApp)
        {
            this._EpisodeApp = EpisodeApp;
        }
        #endregion

        public List<GetAllEpisodeItem> GetAllEpisode { get; set; }
        public void OnGet(long id)
        {
            GetAllEpisode = _EpisodeApp.GetAllEpisode(id);
            TempData["CourseId"] = id;
        }


        public IActionResult OnGetCreateEpisode(long Id)
        {
            CreateEpisodeItem createEpisode = new();
            createEpisode.CourseId = Id;
            return Partial("./CreateEpisode", createEpisode);
        }

        public IActionResult OnPostCreateEpisode(CreateEpisodeItem createEpisode)
        {
            OperationResult operationResult =
                _EpisodeApp.CreateEpisode(createEpisode);

            return new JsonResult(new JsonMessage
            {
                code = operationResult.Code,
                message = operationResult.Message,
            });
        }

        public IActionResult OnGetEditEpisode(long Id)
        {
            EditEpisodeItem EditEpisode = new();
            EditEpisode = _EpisodeApp.FindEpisodeForEdit(Id);
            return Partial("./EditEpisode", EditEpisode);
        }

        public IActionResult OnPostEditEpisode(EditEpisodeItem EditEpisode)
        {
            OperationResult operationResult =
                _EpisodeApp.EditEpisode(EditEpisode);

            return new JsonResult(new JsonMessage
            {
                code = operationResult.Code,
                message = operationResult.Message,
            });
        }

        public IActionResult OnGetRemoveEpisode(long Id)
        {
            RemoveEpisodeItem RemoveEpisode = new();
            RemoveEpisode = _EpisodeApp.FindEpisodeForRemove(Id);
            return Partial("./RemoveEpisode", RemoveEpisode);
        }

        public IActionResult OnPostRemoveEpisode(RemoveEpisodeItem RemoveEpisode)
        {
            OperationResult operationResult =
                _EpisodeApp.RemoveEpisode(RemoveEpisode);

            return new JsonResult(new JsonMessage
            {
                code = operationResult.Code,
                message = operationResult.Message,
            });
        }

    }
}
