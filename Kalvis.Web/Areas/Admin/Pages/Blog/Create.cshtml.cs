using Kalvis.Common.Application;
using Kalvis.Contract.BlogViewModel;
using Kalvis.Contract.BlogViewModel.Interface;
using Kalvis.Contract.CategoryViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.Blog
{
    public class CreateModel : PageModel
    {
        #region Constracture
        private readonly IBlogApplication _BlogApp;
        private readonly ICategoryApplication _CategoryApp;

        public CreateModel(IBlogApplication BlogApp,
            ICategoryApplication CategoryApp)
        {
            this._BlogApp = BlogApp;
            this._CategoryApp = CategoryApp;
        }

        #endregion

        [BindProperty]
        public CreateBlogItem CreateBlog { get; set; }
        public void OnGet()
        {
            CreateBlog = new();
            CreateBlog.GetAllCategory =
                _CategoryApp.GetAllCategory(0, false);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            OperationResult operationResult =
                _BlogApp.CreateBlog(CreateBlog);

            TempData["OperationResult"] =
                Newtonsoft.Json.JsonConvert
                .SerializeObject(operationResult);

            if (operationResult.Code != Operation.Success)
            {
                CreateBlog.GetAllCategory =
                  _CategoryApp.GetAllCategory(0, false);

                return Page();
            }

            return RedirectToPage("./Index");

        }
    }
}
