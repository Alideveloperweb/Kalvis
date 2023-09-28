using Kalvis.Common.Application;
using Kalvis.Contract.DisCount.CourseDisCountViewModel.Interface;
using Kalvis.Contract.DisCountViewModel.CourseDisCountViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.DisCount.CourseDisCount
{
    public class IndexModel : PageModel
    {
        #region Constracture
        private readonly ICourseDisCountApplication _DisCountApp;
        public IndexModel(ICourseDisCountApplication DisCountApp)
        {
            this._DisCountApp = DisCountApp;
        }
        #endregion

        public List<GetAllCourseDisCountItem> GetAllDisCount { get; set; }
        public void OnGet()
        {
            GetAllDisCount =
                _DisCountApp.GetAllCourseDiscount(false);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }

        public IActionResult OnPostCreate(CreateCourseDisCountItem Discount)
        {
            OperationResult operationResult =
             _DisCountApp.CreateCourseDisCount(Discount);

            return new JsonResult(new JsonMessage
            {
                code = operationResult.Code,
                message = operationResult.Message,
            });
        }

        public IActionResult OnGetEdit(int id)
        {
            return Partial("./Edit", _DisCountApp.FindDisCountForEdit(id));
        }

        public IActionResult OnPostEdit(EditCourseDisCountItem Discount)
        {
            OperationResult operationResult =
             _DisCountApp.EditCourseDisCount(Discount);

            return new JsonResult(new JsonMessage
            {
                code = operationResult.Code,
                message = operationResult.Message,
            });
        }
    }
}
