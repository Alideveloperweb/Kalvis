using Kalvis.Application.DisCount;
using Kalvis.Contract.DisCount.CourseDisCountViewModel.Interface;
using Kalvis.Domain.DiscountEntities.CourseDisCountEntities.Interface;
using Kalvis.EfCore.Repository.DisCount;
using Microsoft.Extensions.DependencyInjection;

namespace Kalvis.Configuration.DisCountConfig
{
    public static class CourseDisCountConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<ICourseDisCountRepository, CourseDisCountRepository>();
            services.AddTransient<ICourseDisCountApplication, CourseDisCountApplication>();

        }
    }
}
