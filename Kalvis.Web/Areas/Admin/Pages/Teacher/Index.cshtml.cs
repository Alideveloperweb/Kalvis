using Kalvis.Common.Application;
using Kalvis.Contract.TeacherViewModel;
using Kalvis.Contract.TeacherViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Kalvis.Web.Areas.Admin.Pages.Teacher
{
    public class IndexModel : PageModel
    {
        #region Constracture
        private readonly ITeacherApplication _TeacherApp;
        public IndexModel(ITeacherApplication TeacherApp)
        {
            this._TeacherApp = TeacherApp;
        }
        #endregion


        public List<GetAllTeacherItem> GetAllTeacher { get; set; }
        public void OnGet()
        {
            GetAllTeacher = _TeacherApp.GetAllTeacher();
        }


        public IActionResult OnGetAddOrRemoveTeacher(long TeacherId)
        {

            return Partial("./AddTeacher", _TeacherApp.FindTeacherById(TeacherId));
        }

        public IActionResult OnPostAddOrRemoveTeacher(UserUpgradeItem upgradeItem)
        {
            OperationResult operationResult =
                _TeacherApp.AddUserForTeacher(upgradeItem);

            return new JsonResult(new JsonMessage
            {
                code = operationResult.Code,
                message = operationResult.Message,
            });

        }

    }
}
