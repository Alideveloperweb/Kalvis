
using Kalvis.Domain.EducationEntities.CategoryEntities;
using Kalvis.Common.Application;
using Kalvis.EFCore.ApplicationContexts;
using Kalvis.Contract.CategoryViewModel.Interface;


namespace Kalvis.EFCore.Repository.CaategoryRepository
{
    public class SubCategoryRepository:RepositoryBase<int,SubCategory>,
        ISubCategoryRepository
    {

        #region Constractore

        private readonly ApplicationContext _context;
        public SubCategoryRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }
        #endregion
    }
}
