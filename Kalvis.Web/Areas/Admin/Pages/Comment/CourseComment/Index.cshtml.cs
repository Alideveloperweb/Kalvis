using Kalvis.Contract.CommentViewModel.CourseCommentViewModel;
using Kalvis.Contract.CommentViewModel.CourseCommentViewModel.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Kalvis.Web.Areas.Admin.Pages.Comment.CourseComment
{
    public class IndexModel : PageModel
    {
        #region Constracture
        private readonly ICourseCommentApplication _CommentApp;
        public IndexModel(ICourseCommentApplication CommentApp)
        {
            this._CommentApp = CommentApp;
        }
        #endregion

        public List<GetAllCourseCommetItem> GetAllComment { get; set; }
        public void OnGet()
        {
            GetAllComment = _CommentApp.GetAllCourseComment(false);
        }
    }
}
