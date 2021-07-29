using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebAPI.Helpers;

namespace WebAPI
{
    public class Startup
    {
        public Startup()
        {
           
        }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
               .AddTransient<LoggerClass>();
           
            services.AddScoped<APIHelper>();
            services.AddScoped<EmployeeHelper>();            
        }
    }
}
