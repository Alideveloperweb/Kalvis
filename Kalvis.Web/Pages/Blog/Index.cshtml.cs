
using Kalvis.Contract.BlogViewModel;
using Kalvis.Contract.BlogViewModel.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Pages.Blog
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

        public GetBlogItem GetBlog { get; set; }
        public void OnGet(int id)
        {
            GetBlog = _BlogApp.GetBlog(id);
        }
    }
}
