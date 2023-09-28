using Kalvis.Application.TeacherApp;
using Kalvis.Application.AccountApp;
using Kalvis.Application.UserApp;
using Kalvis.Contract.AccountViewModel.Interface;
using Kalvis.Contract.TeacherViewModel.Interface;
using Kalvis.Contract.UserViewModel.Interface;
using Kalvis.Domain.EducationEntities.TeacherEntities.Interface;
using Kalvis.Domain.EducationEntities.UserEntities.Interface;
using Kalvis.EFCore.Repository.TeacherRepository;
using Kalvis.EFCore.Repository.UserRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Kalvis.Configuration.UserConfig
{
    public static class UserConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserApplication, UserApplication>();
            //---------------------------------------------------
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<ITeacherApplication, TeacherApplication>();
            //----------------------------------------------------
            services.AddTransient<IAccountApplication, AccountApplication>();
        }
    }
}
