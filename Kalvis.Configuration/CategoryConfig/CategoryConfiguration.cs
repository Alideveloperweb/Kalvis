using Kalvi.Contract.CategoryViewmodel.Interface;
using Kalvi.Domain.EducationEntities.CategoryEntities.Interface;
using Kalvis.Application.CategoryApp;
using Kalvis.Contract.CategoryViewModel.Interface;
using Kalvis.EFCore.Repository.CaategoryRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Configuration.CategoryConfig
{
    public static class CategoryConfiguration
    {
        public static void Configure(IServiceCollection services )
        {
            services.AddTransient<ICategoryRepository,CategoryRepository>();
            services.AddTransient<ICategoryApplication, CategoryApplication>();

            #region Sub Category

            services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();

            #endregion
        }
    }
}
