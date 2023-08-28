using Kalvis.Common.Application;
using Kalvis.Contract.CategoryViewModel.Interface;
using Kalvis.Contract.CategoryViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.Category
{
    public class RestoreCategoryModel : PageModel
    {

        #region Constracture
        private readonly ICategoryApplication _App;
        public RestoreCategoryModel(ICategoryApplication App)
        {
            this._App = App;
        }
        #endregion

        [BindProperty]
        public RestoreCategoryItem RestoreCategory { get; set; }
        public IActionResult OnGet(int Id)
        {
            RestoreCategory = _App.FindCategoryForRestore(Id);
            if (RestoreCategory == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {

            OperationResult operationResult = _App.RestoreCategory(RestoreCategory);
            TempData["OperationResult"] = Newtonsoft.Json.JsonConvert.SerializeObject(operationResult);
            if (operationResult.Code != Operation.Success)
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
