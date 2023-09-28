using Kalvis.Contract.CategoryViewModel.Interface;
using Kalvis.Domain.EducationEntities.CategoryEntities.Interface;
using Kalvis.Application.CategoryApp;
using Kalvis.Contract.CategoryViewModel.Interface;
using Kalvis.EFCore.Repository.CaategoryRepository;
using Microsoft.Extensions.DependencyInjection;

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
