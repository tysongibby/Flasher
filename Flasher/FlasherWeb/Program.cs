using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using FlasherWeb.Services;
using FlasherWeb.Services.Interfaces;

namespace FlasherWeb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
           
            builder.Services.AddScoped(api => new HttpClient { BaseAddress = new Uri(builder.Configuration["api_base_url"]) });
            builder.Services.AddHttpClient<IFlashCardService, FlashCardService>(fcs => fcs.BaseAddress = new Uri(builder.Configuration["api_base_url"]));
            builder.Services.AddHttpClient<ISubjectService, SubjectService>(sss => sss.BaseAddress = new Uri(builder.Configuration["api_base_url"]));
            builder.Services.AddHttpClient<ICategoryService, CategoryService>(ss => ss.BaseAddress = new Uri(builder.Configuration["api_base_url"]));

            await builder.Build().RunAsync();
        }
    }
}
