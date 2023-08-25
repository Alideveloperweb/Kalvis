using Kalvis.EFCore.ApplicationContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Configuration
{
    public class ConnectionConfig
    {
        public  static void Configur(IServiceCollection service,string Connection)
        {
            service.AddDbContext<ApplicationContext>(options=>
            {
                options.UseSqlServer(Connection);
            });
        }
    }
}
