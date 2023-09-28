

using Kalvis.Application.CommentApp;
using Kalvis.Contract.CommentViewModel.CourseCommentViewModel.Interface;
using Kalvis.Domain.EducationEntities.CommentEntities.Interface;
using Kalvis.EfCore.Repository.CommentRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Kalvis.Configuration.CommentConfig
{
    public class CourseCommentConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<ICourseCommentRepository, CourseCommentRepository>();
            services.AddTransient<ICourseAnswerCommentRepository, CourseAnswerCommentRepository>();
            services.AddTransient<ICourseCommentApplication, CourseCommentApplication>();
        }
    }
}
