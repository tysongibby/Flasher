using FlasherData.Context;
using FlasherData.Repositories;
using FlasherData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlasherData
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            // SQLite connection and database context
            services.AddDbContext<FlasherContext>(options => options.UseSqlite(Configuration.GetConnectionString("FlasherDb")));

            // Dependency Injection
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
