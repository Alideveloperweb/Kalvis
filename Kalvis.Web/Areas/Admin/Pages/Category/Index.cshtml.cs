using Kalvis.Contract.CategoryViewModel;
using Kalvis.Contract.CategoryViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.Category
{
    public class IndexModel : PageModel
    {
        #region Constract
        private readonly ICategoryApplication _App;
        public IndexModel(ICategoryApplication App)
        {
            _App = App;
        }

        #endregion

        public List<GetAllCategoryItem> GetAllCategory { get; set; }
        public void OnGet()
        {
            GetAllCategory = _App.getAllCategory(0, false);
        }
    }
}
