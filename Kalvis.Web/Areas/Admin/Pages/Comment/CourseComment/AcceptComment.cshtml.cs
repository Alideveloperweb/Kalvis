using Kalvis.Common.Application;
using Kalvis.Contract.CommentViewModel.CourseCommentViewModel;
using Kalvis.Contract.CommentViewModel.CourseCommentViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.Comment.CourseComment
{

    public class AcceptCommentModel : PageModel
    {
        #region Constracture
        private readonly ICourseCommentApplication _CommentApp;
        public AcceptCommentModel(
            ICourseCommentApplication CommentApp)
        {
            this._CommentApp = CommentApp;
        }

        #endregion

        public GetCourseCommentItem GetComment { get; set; }
        public IActionResult OnGet(long id)
        {
            GetComment = _CommentApp.GetCommentById(id);

            OperationResult operationResult =
          _CommentApp.AcceptComment(GetComment);

            TempData["OperationResult"] = Newtonsoft.Json.JsonConvert.SerializeObject(operationResult);
            if (operationResult.Code != Operation.Success)
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }

    }
}
