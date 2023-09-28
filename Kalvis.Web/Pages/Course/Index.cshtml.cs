using Kalvis.Common.Application;
using Kalvis.Contract.CommentViewModel.CourseCommentViewModel;
using Kalvis.Contract.CommentViewModel.CourseCommentViewModel.Interface;
using Kalvis.Contract.CourseViewModel;
using Kalvis.Contract.CourseViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Kalvis.Web.Pages.Course
{
    public class IndexModel : PageModel
    {
        #region Constracture
        private readonly ICourseApplication _CourseApp;
        private readonly ICourseCommentApplication _CourseComment;
        public IndexModel(ICourseApplication CourseApp,
            ICourseCommentApplication CourseComment)
        {
            _CourseComment = CourseComment;
            _CourseApp = CourseApp;
        }
        #endregion

        [BindProperty]
        public CreateCommentAndAnswerItem CreateComment { get; set; }
        public GetCourseQueryItem GetCourse { get; set; }
        public List<SimilarQueryItem> ListSimilar { get; set; }
        public IActionResult OnGet(long id)
        {
            GetCourse = _CourseApp.GetCourseQuery(id);
            if (GetCourse == null)
                return RedirectToPage("../Index");

            ListSimilar =
                _CourseApp.ListSimilar(GetCourse.CategoryID, GetCourse.CourseID);
            GetCourse.GetAllComment = _CourseComment.GetAllComment(id);

            if (User.Identity.IsAuthenticated)
            {
                long UserID = long.Parse(User.FindFirst("userid").Value);
                GetCourse.Buyer = _CourseApp.Buyer(UserID, id);
            }
            return Page();
        }

        public IActionResult OnPostCreateComment()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("../Index");

            long UserID = long.Parse(User.FindFirst("userid").Value);
            if (CreateComment.CommentID <= 0)
            {
                CreateComment.UserID = UserID;
                OperationResult operationResult =
                    _CourseComment.CreateComment(CreateComment);
                return RedirectToPage("./index", new { id = CreateComment.CourseID });
            }
            else
            {
                CreateComment.UserID = UserID;
                OperationResult operationResult =
                    _CourseComment.CreateAnswer(CreateComment);
                return RedirectToPage("./index", new { id = CreateComment.CourseID });

            }

        }
    }
}
