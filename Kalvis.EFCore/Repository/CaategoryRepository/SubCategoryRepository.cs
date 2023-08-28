using Kalvi.Contract.CategoryViewmodel.Interface;
using Kalvi.Domain.EducationEntities.CategoryEntities;
using Kalvis.Common.Application;
using Kalvis.EFCore.ApplicationContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
