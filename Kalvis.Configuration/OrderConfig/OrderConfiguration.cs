using Kalvis.Application.OrderApp;
using Kalvis.Contract.OrderViewModel.Interface;
using Kalvis.Domain.OrderEntities.CourseOrderEntities.Interface;
using Kalvis.EfCore.Repository.ORderRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Kalvis.Configuration.OrderConfig
{
    public static class OrderConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IOrderApplication, OrderApplication>();
        }
    }
}
