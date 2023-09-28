using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kalvis.Common.Application;
using Kalvis.Contract.BlogViewModel;
using Kalvis.Contract.BlogViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Areas.Admin.Pages.Blog
{
    public class IndexModel : PageModel
    {
        #region Constracture
        private readonly IBlogApplication _BlogApp;
        public IndexModel(IBlogApplication BlogApp)
        {
            this._BlogApp = BlogApp;
        }
        #endregion

        public List<GetAllBlogItem> GetAllBlog { get; set; }
        public void OnGet()
        {
            GetAllBlog = _BlogApp.GetAllBlog(false);
        }


        public IActionResult OnGetRemove(int id)
        {
            return Partial("./Remove", _BlogApp.FindBlogForRemove(id));
        }

        public IActionResult OnPostRemove(RemoveBlogItem RemoveBlog)
        {
            OperationResult operationResult =
                _BlogApp.RemoveBlog(RemoveBlog);

            return new JsonResult(new JsonMessage
            {
                code = operationResult.Code,
                message = operationResult.Message,
            });
        }

    }
}
