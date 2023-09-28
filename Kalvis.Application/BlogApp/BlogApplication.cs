using Kalvis.Common.Application;
using Kalvis.Contract.BlogViewModel;
using Kalvis.Contract.BlogViewModel.Interface;
using Kalvis.Domain.BlogEntities;
using Kalvis.Domain.BlogEntities.Interface;
using Kalvis.Domain.EducationEntities.CategoryEntities.Interface;
using System;
using System.Collections.Generic;

namespace Kalvis.Application.BlogApp
{
    public class BlogApplication : IBlogApplication
    {
        #region Constracture
        private readonly IBlogRepository _BlogRepp;
        private readonly ICategoryRepository _CategoryRepp;
        public BlogApplication(IBlogRepository BlogRepp,
            ICategoryRepository CategoryRepp)
        {
            this._BlogRepp = BlogRepp;
            this._CategoryRepp = CategoryRepp;
        }
        #endregion

        public OperationResult CreateBlog(CreateBlogItem CreateBlog)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("بلاگ");

            if (_BlogRepp.Exist(x => x.BlogTitle == CreateBlog.BlogTitle))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("عنوان"));

            string BlogImage = "";
            string EnCategoryName = _CategoryRepp
                .FindNameCategoryById(CreateBlog.CategoryId);

            BlogImage = CreateBlog.Uploder.
                Uplode(Router.RouteImageBlog + EnCategoryName);

            if (String.IsNullOrWhiteSpace(BlogImage))
                return operationResult.Failed(Operation.ErrorUplod, message.ErrorUplodeImage());

            Blog blog = new(CreateBlog.BlogTitle, BlogImage, CreateBlog.CategoryId,
                CreateBlog.BlogDescription, CreateBlog.Tags,
                CreateBlog.IsComment, CreateBlog.IsActive);

            bool Create = _BlogRepp.Create(blog);
            if (!Create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());

            bool Save = _BlogRepp.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Create());

        }

        public EditBlogItem FindBlogForEdit(int BlogId)
        {
            return _BlogRepp.FindBlogForEdit(BlogId);
        }

        public List<GetAllBlogItem> GetAllBlog(bool IsRemove, bool IsActive)
        {
            return _BlogRepp.GetAllBlog(IsRemove, IsActive);
        }

        public List<GetAllBlogItem> GetAllBlog(bool IsRemove)
        {
            return _BlogRepp.GetAllBlog(IsRemove);
        }


        public OperationResult EditBlog(EditBlogItem EditBlog)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("بلاگ");

            if (_BlogRepp.Exist(x =>
            x.Id != EditBlog.BlogId &&
            x.BlogTitle == EditBlog.BlogTitle))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("عنوان"));
            Blog Blog = _BlogRepp.Get(EditBlog.BlogId);

            string BlogImage = EditBlog.Uploder != null
                ? "" : Blog.BlogImage;

            if (Blog == null)
                return operationResult.Failed(Operation.Nullabel, message.Nullabele());

            string EnCategoryName = "";
            if (EditBlog.Uploder != null)
            {
                EnCategoryName = _CategoryRepp
                .FindNameCategoryById(EditBlog.CategoryId);

                Uploder.RemoveFile(Blog.BlogImage, Router.RouteImageBlog
                 + EnCategoryName);


                if (Blog.CategoryId != EditBlog.CategoryId)
                    EnCategoryName = _CategoryRepp
                .FindNameCategoryById(EditBlog.CategoryId);


                BlogImage = EditBlog.Uploder.
                     Uplode(Router.RouteImageBlog + EnCategoryName);
            }

            if (Blog.CategoryId != EditBlog.CategoryId)
            {
                string OldRoute = _CategoryRepp
               .FindNameCategoryById(Blog.CategoryId);

                string NewRoute = _CategoryRepp
               .FindNameCategoryById(EditBlog.CategoryId);

                Uploder.MoveFile(Router.RouteImageBlog + NewRoute
                    , Router.RouteImageBlog + OldRoute, Blog.BlogImage);
            }

            if (String.IsNullOrWhiteSpace(BlogImage))
                return operationResult.Failed(Operation.ErrorUplod, message.ErrorUplodeImage());

            Blog.Edit(EditBlog.BlogTitle, BlogImage, EditBlog.CategoryId,
                EditBlog.BlogDes, EditBlog.Tags,
                EditBlog.IsComment, EditBlog.IsActive);

            bool Update = _BlogRepp.Update(Blog);
            if (!Update)
                return operationResult.Failed(Operation.Error, message.ErrorUpdate());

            bool Save = _BlogRepp.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Update());

        }

        public RemoveBlogItem FindBlogForRemove(int BlogId)
        {
            return _BlogRepp.FindBlogForRemove(BlogId);
        }

        public OperationResult RemoveBlog(RemoveBlogItem RemoveBlog)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("بلاگ");

            Blog blog = _BlogRepp.Get(RemoveBlog.BlogId);

            if (blog == null)
                return operationResult.Failed(Operation.Nullabel, message.Nullabele());

            blog.Remove();

            bool Remove = _BlogRepp.Update(blog);
            if (!Remove)
                return operationResult.Failed(Operation.Error, message.ErrorRemove());

            bool Save = _BlogRepp.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Remove());

        }

        public List<GetAllBlogQueryItem> GetAllBlogQuery(bool IsRemove, bool IsActive)
        {
            return _BlogRepp.GetAllBlogQuery(IsRemove, IsActive);
        }

        public GetBlogItem GetBlog(int BlogID)
        {
            return _BlogRepp.GetBlog(BlogID);
        }
    }
}
