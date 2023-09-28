
using Kalvis.Application.PermissionApp;
using Kalvis.Contract.PermissionViewModel.Interfcae;
using Kalvis.Domain.PermissionEntities.Interface;
using Kalvis.EfCore.Repository.PermissionRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Kalvis.Configuration.PermissionConfig
{
    public static class PermissionConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IRolePermissionRepository, RolePermissionRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IPermissionApplication, PermissionApplication>();

        }
    }
}
