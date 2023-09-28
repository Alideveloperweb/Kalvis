using Kalvis.Application.PermissionApp;
using Kalvis.Common.Application;
using Kalvis.Common.Security;
using Kalvis.Contract.CourseViewModel;
using Kalvis.Contract.CourseViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Kalvis.Web.Areas.Admin.Pages.Course
{
    [PermissionCheack(CheackPermission.GetAllCourse)]
    public class IndexModel : PageModel
    {
        #region Constracture
        private readonly ICourseApplication _courseApp;
        public IndexModel(ICourseApplication courseApp)
        {
            this._courseApp = courseApp;
        }
        #endregion

        public List<GetAllCourseItem> getAllCourse { get; set; }
        public void OnGet()
        {
            getAllCourse = _courseApp.getAllCourse(false);
        }

        public IActionResult OnGetRemoveCourse(long id)
        {
            return Partial("./Remove", _courseApp.FindCourseForRemove(id));
        }

        public IActionResult OnPostRemoveCourse(RemoveCourseItem removeCourse)
        {
            OperationResult operationResult = _courseApp.RemoveCourse(removeCourse);
            return new JsonResult(new JsonMessage
            {
                code = operationResult.Code,
                message = operationResult.Message,
            });
        }

    }
}
