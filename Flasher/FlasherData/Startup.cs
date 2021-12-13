using FlasherData.Context;
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
            // SQLite database connection
            services.AddDbContext<FlasherContext>(options => options.UseSqlite(Configuration.GetConnectionString("FlasherDb")));            
        }
    }
}
