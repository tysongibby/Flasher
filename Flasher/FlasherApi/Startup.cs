using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flasher.Server.Data;
using Flasher.Server.Data.Repositories;
using Flasher.Server.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlasherApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string AllowSpecificOrigins = "_allowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            // Swagger service
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FlasherApi", Version = "v1" });
            });

            // SQLite service
            services.AddDbContext<FlasherContext>(options => options.UseSqlite(Configuration.GetConnectionString("FlasherDb")));

            // Dependency Injection
            services.AddScoped<IFlashCardRepository, FlashCardRepository>();

            // Cross Origin Requests (CORS)
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:65059",
                                                          "https://localhost:44398");
                                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlasherApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // CORS
            app.UseCors(AllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // TODO: Swagger - remove before production release - for dev only
            app.UseDeveloperExceptionPage();

        }
    }
}
