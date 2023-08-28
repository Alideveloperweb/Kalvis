using Kalvis.Common.Application;
using Kalvis.Contract.CategoryViewModel;
using Kalvis.Contract.CategoryViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.Category
{
    public class EditModel : PageModel
    {

        #region Constracture
        private readonly ICategoryApplication _App;
        public EditModel(ICategoryApplication App)
        {
            _App = App;
        }

        #endregion

        [BindProperty]
        public EditCategoryItem editCategorItem { get; set; }

        public void OnGet(int Id)
        {
            editCategorItem = new();
            editCategorItem = _App.FindCategoryForEdit(Id);
            editCategorItem.GetAllCategoryItems = _App.GetAllCategory(Id, false);
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                editCategorItem.GetAllCategoryItems = _App.GetAllCategory(editCategorItem.CategoryId, false);
                return Page();
            }

            OperationResult operationResult = _App.EditCategory(editCategorItem);
            TempData["OperationResult"] = Newtonsoft.Json.JsonConvert.SerializeObject(operationResult);
            if (operationResult.Code != Operation.Success)
            {
                editCategorItem = _App.FindCategoryForEdit(editCategorItem.CategoryId);
                editCategorItem.GetAllCategoryItems = _App.GetAllCategory(editCategorItem.CategoryId, false);
                return Page();
            }

            return RedirectToPage("./Index");

        }
    }
}
