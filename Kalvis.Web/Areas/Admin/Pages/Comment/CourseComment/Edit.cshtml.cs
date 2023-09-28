
using Kalvis.Common.Application;
using Kalvis.Contract.CommentViewModel.CourseCommentViewModel;
using Kalvis.Contract.CommentViewModel.CourseCommentViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.Comment.CourseComment
{
    public class EditModel : PageModel
    {
        #region Constracture
        private readonly ICourseCommentApplication _CommentApp;
        public EditModel(ICourseCommentApplication CommentApp)
        {
            this._CommentApp = CommentApp;
        }

        #endregion

        [BindProperty]
        public GetCourseCommentItem GetComment { get; set; }

        public void OnGet(long id)
        {
            GetComment = _CommentApp.GetCommentById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            OperationResult operationResult =
            _CommentApp.EditComment(GetComment);

            TempData["OperationResult"] = Newtonsoft.Json.JsonConvert.SerializeObject(operationResult);
            if (operationResult.Code != Operation.Success)
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }

    }
}
