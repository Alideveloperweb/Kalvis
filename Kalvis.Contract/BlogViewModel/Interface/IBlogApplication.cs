
using Kalvis.Common.Application;
using System.Collections.Generic;

namespace Kalvis.Contract.BlogViewModel.Interface
{
    public interface IBlogApplication
    {
        List<GetAllBlogItem> GetAllBlog(bool IsRemove, bool IsActive);
        List<GetAllBlogItem> GetAllBlog(bool IsRemove);
        OperationResult CreateBlog(CreateBlogItem CreateBlog);
        EditBlogItem FindBlogForEdit(int BlogId);
        OperationResult EditBlog(EditBlogItem EditBlog);
        RemoveBlogItem FindBlogForRemove(int BlogId);
        OperationResult RemoveBlog(RemoveBlogItem RemoveBlog);
        GetBlogItem GetBlog(int BlogID);
        List<GetAllBlogQueryItem> GetAllBlogQuery(bool IsRemove, bool IsActive);
    }
}
