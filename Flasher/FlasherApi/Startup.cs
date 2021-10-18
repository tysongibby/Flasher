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
using FlasherApi.Data;
using FlasherApi.Data.Repositories;
using FlasherApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using FlasherApi.Data.Dtos;

namespace FlasherApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //readonly string AllowSpecifiedOrigins = "AllowSpecifiedOrigins";
        readonly string AllowAllPolicy = "AllowCors";        

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

            // Cross Origin RequestS (CORS) policies
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: AllowSpecifiedOrigins,
            //                      builder =>
            //                      {
            //                          builder.WithOrigins("http://localhost:65059", "https://localhost:44398")
            //                          .WithMethods("GET", "POST", "PUT");
            //                      });
            //});
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: AllowAllPolicy, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
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
            app.UseCors(AllowAllPolicy);

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
