using Kalvis.Application.PermissionApp;
using Kalvis.Common.Application;
using Kalvis.Common.Security;
using Kalvis.Contract.CategoryViewModel.Interface;
using Kalvis.Contract.CourseViewModel;
using Kalvis.Contract.CourseViewModel.Interface;
using Kalvis.Contract.TeacherViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.Course
{
    [PermissionCheack(CheackPermission.EditCourse)]
    public class EditModel : PageModel
    {
        #region Constracture
        private readonly ICourseApplication _CourseApp;
        private readonly ITeacherApplication _TeacherApp;
        private readonly ICategoryApplication _CategoryApp;
        public EditModel(ICourseApplication CourseApp,
            ICategoryApplication CategoryApp,
            ITeacherApplication TeacherApp)
        {
            this._CourseApp = CourseApp;
            this._CategoryApp = CategoryApp;
            this._TeacherApp = TeacherApp;
        }
        #endregion

        [BindProperty]
        public EditCourseItem EditCourse { get; set; }
        public void OnGet(long Id)
        {
            EditCourse = new();
            EditCourse = _CourseApp.FindCourseForEdit(Id);

            EditCourse.getAllCategoryItem =
                _CategoryApp.GetAllCategory(0, false);

            EditCourse.getAllTeacherItem =
                _TeacherApp.GetAllTeacher();

        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                EditCourse = _CourseApp.FindCourseForEdit(EditCourse.CourseId);

                EditCourse.getAllCategoryItem =
                    _CategoryApp.GetAllCategory(0, false);

                EditCourse.getAllTeacherItem =
                    _TeacherApp.GetAllTeacher();

                return Page();
            }
            OperationResult operationResult =
                _CourseApp.EditCourse(EditCourse);

            TempData["OperationResult"] = Newtonsoft.Json.JsonConvert.SerializeObject(operationResult);
            if (operationResult.Code != Operation.Success)
            {
                EditCourse = _CourseApp.FindCourseForEdit(EditCourse.CourseId);

                EditCourse.getAllCategoryItem =
                    _CategoryApp.GetAllCategory(0, false);

                EditCourse.getAllTeacherItem =
                    _TeacherApp.GetAllTeacher();

                return Page();
            }

            return RedirectToPage("./Index");
        }

    }
}
