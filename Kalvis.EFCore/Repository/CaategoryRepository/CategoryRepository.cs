using Kalvi.Domain.EducationEntities.CategoryEntities;
using Kalvi.Domain.EducationEntities.CategoryEntities.Interface;
using Kalvis.Common.Application;
using Kalvis.Contract.CategoryViewModel;
using Kalvis.EFCore.ApplicationContexts;
using System.Linq;
using System.Linq.Expressions;


namespace Kalvis.EFCore.Repository.CaategoryRepository
{
    public class CategoryRepository :RepositoryBase<int,Category>, ICategoryRepository
    {
        #region Constract

        private readonly ApplicationContext _context;
        public CategoryRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }

        #endregion

        #region getAllCategory

        public List<GetAllCategoryItem> getAllCategory(int CategoryId, bool IsRemove)
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


    }
}
