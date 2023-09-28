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
    [PermissionCheack(CheackPermission.CreateCourse)]
    public class CreateModel : PageModel
    {
        #region Constracture
        private readonly ICourseApplication _CourseApp;
        private readonly ITeacherApplication _TeacherApp;
        private readonly ICategoryApplication _CategoryApp;
        public CreateModel(ICourseApplication CourseApp,
            ICategoryApplication CategoryApp,
            ITeacherApplication TeacherApp)
        {
            this._CourseApp = CourseApp;
            this._CategoryApp = CategoryApp;
            this._TeacherApp = TeacherApp;
        }
        #endregion

        [BindProperty]
        public CreateCourseItem CreateCourse { get; set; }
        public void OnGet()
        {
            CreateCourse = new();

            CreateCourse.getAllCategoryItem =
                _CategoryApp.GetAllCategory(0, false);

            CreateCourse.getAllTeacherItem =
                _TeacherApp.GetAllTeacher();

        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CreateCourse.getAllCategoryItem =
                     _CategoryApp.GetAllCategory(0, false);

                CreateCourse.getAllTeacherItem =
                    _TeacherApp.GetAllTeacher();

                return Page();
            }

            OperationResult operationResult =
                _CourseApp.CreateCourse(CreateCourse);

            TempData["OperationResult"] =
                Newtonsoft.Json.JsonConvert.SerializeObject
                (operationResult);

            if (operationResult.Code != Operation.Success)
            {
                CreateCourse.getAllCategoryItem =
                   _CategoryApp.GetAllCategory(0, false);

                CreateCourse.getAllTeacherItem =
                    _TeacherApp.GetAllTeacher();
                return Page();
            }

            return RedirectToPage("./Index");
        }

    }
}
