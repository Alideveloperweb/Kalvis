using Kalvis.Application.BlogApp;
using Kalvis.Contract.BlogViewModel.Interface;
using Kalvis.Domain.BlogEntities.Interface;
using Kalvis.EfCore.Repository.BlogRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Kalvis.Configuration.BlogConfig
{
    public static class BlogConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IBlogApplication, BlogApplication>();
        }
    }
}
