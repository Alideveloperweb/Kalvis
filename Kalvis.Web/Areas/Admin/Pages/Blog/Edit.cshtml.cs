using Kalvis.Common.Application;
using Kalvis.Contract.BlogViewModel;
using Kalvis.Contract.BlogViewModel.Interface;
using Kalvis.Contract.CategoryViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.Blog
{
    public class EditModel : PageModel
    {
        #region Constracture
        private readonly IBlogApplication _BlogApp;
        private readonly ICategoryApplication _CategoryApp;

        public EditModel(IBlogApplication BlogApp,
            ICategoryApplication CategoryApp)
        {
            this._BlogApp = BlogApp;
            this._CategoryApp = CategoryApp;
        }

        #endregion

        [BindProperty]
        public EditBlogItem EditBlog { get; set; }
        public IActionResult OnGet(int id)
        {
            EditBlog = _BlogApp.FindBlogForEdit(id);

            if (EditBlog == null)
            {
                ApplicationMessage message = new("بلاگ");
                OperationResult operationResult = new()
                {
                    Code = Operation.Nullabel,
                    IsSuccess = false,
                    Message = message.Nullabele(),
                };
                TempData["OperationResult"] = Newtonsoft.Json.JsonConvert.SerializeObject(operationResult);

                return RedirectToPage("./index");
            }

            EditBlog.GetAllCategory =
                _CategoryApp.GetAllCategory(0, false);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                EditBlog.GetAllCategory =
             _CategoryApp.GetAllCategory(0, false);
                return Page();
            }


            OperationResult operationResult =
                _BlogApp.EditBlog(EditBlog);

            TempData["OperationResult"] =
                Newtonsoft.Json.JsonConvert
                .SerializeObject(operationResult);

            if (operationResult.Code != Operation.Success)
            {
                EditBlog.GetAllCategory =
                  _CategoryApp.GetAllCategory(0, false);
                return Page();
            }

            return RedirectToPage("./Index");

        }
    }
}
