using FlasherData.Context;
using FlasherData.Repositories;
using FlasherData.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// SQLite database connection
builder.Services.AddDbContext<FlasherContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("FlasherDb")));

// Dependency Injection
builder.Services.AddScoped<IFlashcardRepository, FlashcardRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cross Origin RequestS (CORS) policies
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "AllowSpecifiedOrigins",
//                      builder =>
//                      {
//                          builder.WithOrigins("http://localhost:65059", "https://localhost:44398")
//                          .WithMethods("GET", "POST", "PUT");
//                      });
//});
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "AllowCors", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowCors");

app.Run();
