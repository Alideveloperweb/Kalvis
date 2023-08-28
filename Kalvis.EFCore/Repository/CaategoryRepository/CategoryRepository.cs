using Kalvi.Domain.EducationEntities.CategoryEntities;
using Kalvi.Domain.EducationEntities.CategoryEntities.Interface;
using Kalvis.Common.Application;
using Kalvis.Contract.CategoryViewModel;
using Kalvis.EFCore.ApplicationContexts;
using System.Linq;
using System.Linq.Expressions;


namespace Kalvis.EFCore.Repository.CaategoryRepository
{
    public class CategoryRepository : RepositoryBase<int, Category>
        , ICategoryRepository
    {
        #region Constract

        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }


        #endregion

        #region GetAllCategory

        public List<GetAllCategoryItem> GetAllCategory(int CategoryId, bool IsRemove)
        {
            return _context.Categories
                  .Where(x => x.Id != CategoryId)
                  .Where(x => x.IsRemove == IsRemove)
                  .Select(x => new GetAllCategoryItem
                  {

                      CategoryId = x.Id,
                      CreateDate = x.CreateDate.ToString(),
                      EnCategoryName = x.EnCategoryName,
                      FaCategoryName = x.FaCategoryName,
                      LastUpdateDate = x.LastUpdate.ToString(),

                  }).OrderByDescending(x => x.CategoryId).ToList();
        }



        #endregion

        #region GetAllSubCategories

        public List<GetAllSubCategory> GetAllSubCategories(int parentId)
        {
            return _context.SubCategories
          .Where(x => x.ParentId == parentId)
          .Select(x => new GetAllSubCategory
          {
              Id = x.Id,
              ParentId = x.ParentId,
              SubCategoryId = x.SubId,
          })
          .ToList();
        }

        #endregion

        #region FindCategoryForEdit

        public EditCategoryItem FindCategoryForEdit(long categoryId)
        {
            return _context.Categories
                   .Where(x => x.Id == categoryId)
                   .Select(x => new EditCategoryItem
                   {

                       CategoryId = x.Id,
                       EnCategoryName = x.EnCategoryName,
                       FaCategoryName = x.FaCategoryName,
                       SubId = _context.SubCategories.Where(x => x.ParentId == categoryId)
                      .Select(x => x.SubId).ToList()
                   }).FirstOrDefault();
        }

        #endregion

        #region FindCategoryForRemove


        public RemoveCategoryItem FindCategoryForRemove(int categoryId)
        {
            return _context.Categories
                .Where(x => x.Id == categoryId)
                .Select(x => new RemoveCategoryItem
                {
                    CategoryId = x.Id,
                    EnCategoryName = x.EnCategoryName,
                    FaCategoryName = x.FaCategoryName

                }).FirstOrDefault();
        }

        #endregion

        #region FindCategoryForRestore

        public RestoreCategoryItem FindCategoryForRestore(int categoryId)
        {
            return _context.Categories
                     .Where(x => x.Id == categoryId)
                     .Select(x => new RestoreCategoryItem
                     {
                         CategoryId = x.Id,
                         EnCategoryName = x.EnCategoryName,
                         FaCategoryName = x.FaCategoryName,
                    
                     }).FirstOrDefault();
        }

        #endregion

        #region FindNameCategoryById

        public string FindNameCategoryById(int categoryId)
        {
            return _context.Categories
                 .FirstOrDefault(x => x.Id == categoryId)
                 .EnCategoryName;
        }

        #endregion

    }
}
