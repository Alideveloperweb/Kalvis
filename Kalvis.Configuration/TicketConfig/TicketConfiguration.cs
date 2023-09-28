using Kalvis.Application.TicketApp;
using Kalvis.Contract.TicketViewModel.Interface;
using Kalvis.Domain.TicketEntities.Interface;
using Kalvis.EfCore.Repository.TicketRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Kalvi.Configuration.TicketConfig
{
    public static class TicketConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<ITicketApplication, TicketApplication>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
        }
    }
}
