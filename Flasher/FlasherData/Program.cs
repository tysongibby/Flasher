using FlasherData.Context;
using FlasherData.Repositories;
using FlasherData.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FlasherContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("FlasherDb")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
app.Run();