using Kalvis.Application.NotificationApp;
using Kalvis.Contract.NotificationViewModel.Interface;
using Kalvis.Domain.NotificationEntities.Interface;
using Kalvis.EfCore.Repository.NotificationRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Kalvis.Configuration.NotificationConfig
{
    public static class NotificationConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<INotificationApplication, NotificationApplication>();
        }
    }
}
