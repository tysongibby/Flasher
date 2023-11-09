using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FlasherWeb.Services;
using FlasherWeb.Services.Interfaces;
using FlasherWeb;
using FlasherData.DataModels;
using FlasherData.Context;
using FlasherData.Repositories;
using FlasherData.Repositories.Interfaces;
using System.Net.Http;
using System;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Setup API services
builder.Services.AddScoped(api => new HttpClient { BaseAddress = new Uri(builder.Configuration["api_base_url"]) });
builder.Services.AddHttpClient<IFlashcardService, FlashcardService>(fs => fs.BaseAddress = new Uri(builder.Configuration["api_base_url"]));
builder.Services.AddHttpClient<ISubjectService, SubjectService>(ss => ss.BaseAddress = new Uri(builder.Configuration["api_base_url"]));
builder.Services.AddHttpClient<ICategoryService, CategoryService>(cs => cs.BaseAddress = new Uri(builder.Configuration["api_base_url"]));

// Setup database services
builder.Services.AddDbContext<FlasherContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("FlasherDb")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

await builder.Build().RunAsync();

