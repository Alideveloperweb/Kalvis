using Kalvis.Contract.CategoryViewModel.Interface;
using Kalvis.Contract.CategoryViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.Category
{
    public class RestoreModel : PageModel
    {
        #region Constract
        private readonly ICategoryApplication _App;

        public RestoreModel(ICategoryApplication App)
        {
            _App = App;
        }


        #endregion

        public List<GetAllCategoryItem> GetAllCategory { get; set; }
        public void OnGet()
        {
            GetAllCategory = _App.GetAllCategory(0, true);
        }
    }
}
