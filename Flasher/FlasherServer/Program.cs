using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FlasherServer.Data;
using FlasherData.Context;
using FlasherData.Repositories.Interfaces;
using FlasherData.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Blazor services            
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// AutoMapper
// https://medium.com/dotnet-hub/use-automapper-in-asp-net-or-asp-net-core-automapper-getting-started-introduction-dotnet-9cdda3db1feb
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());


// SQLite database connection
builder.Services.AddDbContext<FlasherContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("FlasherDb")));

// Dependency Injection
builder.Services.AddScoped<IFlashcardRepository, FlashcardRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
