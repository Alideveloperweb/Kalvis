using Kalvis.Common.Domain;
using Kalvis.Contract.BlogViewModel;

namespace Kalvis.Domain.BlogEntities.Interface
{
    public interface IBlogRepository : IRepositoryBase<int, Blog>
    {
        List<GetAllBlogItem> GetAllBlog(bool IsRemove, bool IsActive);
        List<GetAllBlogItem> GetAllBlog(bool IsRemove);
        EditBlogItem FindBlogForEdit(int BlogId);
        RemoveBlogItem FindBlogForRemove(int BlogId);
        GetBlogItem GetBlog(int BlogID);
        List<GetAllBlogQueryItem> GetAllBlogQuery(bool IsRemove, bool IsActive);
    }
}