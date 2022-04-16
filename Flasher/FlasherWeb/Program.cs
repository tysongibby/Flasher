using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Web;
using FlasherWeb.Services;
using FlasherWeb.Services.Interfaces;
using FlasherWeb;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(api => new HttpClient { BaseAddress = new Uri(builder.Configuration["api_base_url"]) });
builder.Services.AddHttpClient<IFlashcardService, FlashcardService>(fcs => fcs.BaseAddress = new Uri(builder.Configuration["api_base_url"]));
builder.Services.AddHttpClient<ISubjectService, SubjectService>(sss => sss.BaseAddress = new Uri(builder.Configuration["api_base_url"]));
builder.Services.AddHttpClient<ICategoryService, CategoryService>(ss => ss.BaseAddress = new Uri(builder.Configuration["api_base_url"]));

await builder.Build().RunAsync();

