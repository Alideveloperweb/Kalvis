using Kalvis.Common.Application;
using Kalvis.Contract.CategoryViewModel;
using Kalvis.Contract.CategoryViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.Category
{
    public class CreateModel : PageModel
    {
        #region Constracture

        private readonly ICategoryApplication _App;

        public CreateModel(ICategoryApplication App)
        {
            _App = App;
        }



        #endregion

        [BindProperty]
        public CreateCategoryItem CreateItem { get; set; }

        public void OnGet()
        {
            CreateItem = new();
            CreateItem.GetAllCategoryItems = _App.GetAllCategory(0, false);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CreateItem.GetAllCategoryItems = _App.GetAllCategory(0, false);
                return Page();
            }

            OperationResult operationResult = _App.CreateCategory(CreateItem);
            TempData["OperationResult"] = Newtonsoft.Json.JsonConvert.SerializeObject(operationResult);
            if (operationResult.Code != Operation.Success)
            {
                CreateItem.GetAllCategoryItems = _App.GetAllCategory(0, false);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
