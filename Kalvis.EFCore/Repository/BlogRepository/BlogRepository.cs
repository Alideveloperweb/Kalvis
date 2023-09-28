using Kalvis.Common.Application;
using Kalvis.Contract.BlogViewModel;
using Kalvis.Domain.BlogEntities;
using Kalvis.Domain.BlogEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;
using Microsoft.EntityFrameworkCore;

namespace Kalvis.EfCore.Repository.BlogRepository
{
    public class BlogRepository : RepositoryBase<int, Blog>
        , IBlogRepository
    {

        #region Constracture
        private readonly ApplicationContext _context;
        public BlogRepository(ApplicationContext context)
            : base(context)
        {
            this._context = context;
        }
        #endregion
        public EditBlogItem FindBlogForEdit(int BlogId)
        {
            return _context.Blogs
                .Where(x => x.Id == BlogId)
                .Select(x => new EditBlogItem
                {
                    BlogDes = x.BlogDescription,
                    BlogId = x.Id,
                    BlogTitle = x.BlogTitle,
                    CategoryId = x.CategoryId,
                    IsActive = x.IsActive,
                    IsComment = x.IsComment,
                    Tags = x.Tags,

                })
                .FirstOrDefault();
        }

        public RemoveBlogItem FindBlogForRemove(int BlogId)
        {
            return _context.Blogs
                .Where(x => x.Id == BlogId)
                .Select(x => new RemoveBlogItem
                {

                    BlogId = x.Id,
                    BlogTitle = x.BlogTitle,
                })
                .FirstOrDefault();
        }

        public List<GetAllBlogItem> GetAllBlog(bool IsRemove, bool IsActive)
        {
            return _context.Blogs
                 .Where(x => x.IsActive == IsActive)
                 .Where(x => x.IsRemove == IsRemove)
                 .Select(x => new GetAllBlogItem
                 {
                     BlogId = x.Id,
                     BlogImage = x.BlogImage,
                     BlogTitle = x.BlogTitle,
                     CreateDate = x.CreateDate.ToString(),
                     LastUpdate = x.LastUpdate.ToString(),
                     IsActive = x.IsActive,
                 })
                 .OrderByDescending(x => x.BlogId)
                 .ToList();
        }

        public List<GetAllBlogItem> GetAllBlog(bool IsRemove)
        {
            return _context.Blogs
                 .Where(x => x.IsRemove == IsRemove)
                 .Select(x => new GetAllBlogItem
                 {
                     BlogId = x.Id,
                     BlogImage = x.BlogImage,
                     BlogTitle = x.BlogTitle,
                     CreateDate = x.CreateDate.ToString(),
                     LastUpdate = x.LastUpdate.ToString(),
                     IsActive = x.IsActive,
                 })
                 .OrderByDescending(x => x.BlogId)
                 .ToList();
        }

        public List<GetAllBlogQueryItem> GetAllBlogQuery(bool IsRemove, bool IsActive)
        {
            return _context.Blogs
                .Include(x => x.category)
                .Where(x => x.IsRemove == IsRemove)
                .Where(x => x.IsActive == IsActive)
                .Select(x => new GetAllBlogQueryItem
                {
                    BlogID = x.Id,
                    BlogImage = Router.RouteImageBlog +
                    x.category.EnCategoryName + "/" + x.BlogImage,

                    BlogTitle = x.BlogTitle,
                    CategoryName = x.category.FaCategoryName,


                })
                .OrderByDescending(x => x.BlogID)
                .ToList();

        }

        public GetBlogItem GetBlog(int BlogID)
        {
            return _context.Blogs
                 .Include(x => x.category)
                 .Where(x => x.IsActive)
                 .Where(x => x.Id == BlogID)
                 .Select(x => new GetBlogItem
                 {
                     BlogDescription = x.BlogDescription,
                     BlogImage = Router.RouteImageBlog +
                     x.category.EnCategoryName + "/" +
                     x.BlogImage,
                     BlogTitle = x.BlogTitle,
                     CategoryName = x.category.FaCategoryName,
                     IsComment = x.IsComment,
                     LastUpdate = x.LastUpdate.MiladiToShamsi(),
                     Tags = x.Tags,

                 })
                 .FirstOrDefault();
        }
    }
}
