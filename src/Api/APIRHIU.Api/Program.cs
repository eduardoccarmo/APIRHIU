using APIRHIU.Api.Configurations;
using APIRHIU.Core.DomainObjects;
using APIRHIU.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApirhiuContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

DependencyInjection.RegisterServices(builder.Services);

builder.Services.AddControllers()
    .AddJsonOptions(op =>
    {
        op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        op.JsonSerializerOptions.WriteIndented = true;
    });


var appSettings = $"appsettings.{builder.Environment.EnvironmentName}.json";

builder.Configuration.AddJsonFile(appSettings, optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddOptions<AppSettings>()
    .Bind(builder.Configuration.GetSection("ConfiguracoesSistema"));

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

app.Run();
