
using Kalvis.Contract.CourseEpisodeViewModel;
using Kalvis.Contract.CourseEpisodeViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Pages.Course
{
    public class DownloadModel : PageModel
    {
        #region Constracture
        private readonly ICourseEpisodeApplication _EpisodeApp;
        public DownloadModel(ICourseEpisodeApplication EpisodeApp)
        {
            _EpisodeApp = EpisodeApp;
        }
        #endregion
        public IActionResult OnGet(long id)
        {
            long userid = long.Parse(User.FindFirst("userid").Value);
            bool IsAuthenticated = User.Identity.IsAuthenticated;

            DownloadItem download =
                _EpisodeApp.Download(id, IsAuthenticated, userid);

            if (download.Allowed)
                return Redirect(download.url);

            return Redirect(download.url);
        }
    }
}
