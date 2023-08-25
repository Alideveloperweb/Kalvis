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

        [BindProperty]
        public CreateCategoryItem categoryItem { get; set; }

        #endregion
        public void OnGet()
        {
        }

        public void OnPost()
        {
            _App.CreateCategory(categoryItem);
        }
    }
}
