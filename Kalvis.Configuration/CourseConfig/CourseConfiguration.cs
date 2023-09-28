using Kalvis.Application.CourseApp;
using Kalvis.Contract.CourseEpisodeViewModel.Interface;
using Kalvis.Contract.CourseViewModel.Interface;
using Kalvis.Domain.EducationEntities.CourseEntities.Interface;
using Kalvis.EFCore.Repository.CourseRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Kalvis.Configuration.CourseConfig
{
    public static class CourseConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseApplication, CourseApplication>();

            //-----------------Course Episode----------------------------
            services.AddTransient<ICourseEpisodeRepository, CourseEpisodeRepository>();
            services.AddTransient<ICourseEpisodeApplication, CourseEpisodeApplication>();
            services.AddTransient<IUserCourseRepository, UserCourseRepository>();

        }
    }
}
