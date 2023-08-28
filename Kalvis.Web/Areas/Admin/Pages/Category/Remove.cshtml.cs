using Kalvis.Common.Application;
using Kalvis.Contract.CategoryViewModel.Interface;
using Kalvis.Contract.CategoryViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.Category
{
    public class RemoveModel : PageModel
    {

        #region Constracture
        private readonly ICategoryApplication _App;
        public RemoveModel(ICategoryApplication App)
        {
            this._App = App;
        }
        #endregion

        [BindProperty]
        public RemoveCategoryItem RemoveCategory { get; set; }
        public IActionResult OnGet(int Id)
        {
            RemoveCategory = _App.FindCategoryForRemove(Id);
            if (RemoveCategory == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {

            OperationResult operationResult = _App.RemoveCategory(RemoveCategory);
            TempData["OperationResult"] = Newtonsoft.Json.JsonConvert.SerializeObject(operationResult);
            if (operationResult.Code != Operation.Success)
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
