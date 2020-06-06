using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Vuttr.API.Data.Context;
using Vuttr.API.Data.Repository;
using Vuttr.API.Domain.Repository;
using Vuttr.API.LoggerService;

namespace Vuttr.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<AppDbContext>(options =>
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                string connectionString;

                if (env == "Development")
                {
                    connectionString = configuration.GetConnectionString("sqlConnection");
                }
                else
                {
                    var connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
                    connectionUrl = connectionUrl.Replace("postgres://", string.Empty);
                    var pgUserPass = connectionUrl.Split("@")[0];
                    var pgHostPortDb = connectionUrl.Split("@")[1];
                    var pgHostPort = pgHostPortDb.Split("/")[0];
                    var pgDb = pgHostPortDb.Split("/")[1];
                    var pgUser = pgUserPass.Split(":")[0];
                    var pgPass = pgUserPass.Split(":")[1];
                    var pgHost = pgHostPort.Split(":")[0];
                    var pgPort = pgHostPort.Split(":")[1];
                    connectionString =
                        $"Host={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb}";
                }
                options.UseNpgsql(connectionString);
            });
        
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Vuttr API", 
                    Version = "v1",
                    Description = "Vuttr API by Felipe Kosouski",
                    Contact = new OpenApiContact
                    {
                        Name = "Felipe Kosouski",
                        Email = "felipe.kosouski@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/felipe-kosouski/"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; 
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); 
                options.IncludeXmlComments(xmlPath);
            });
        }
    }
}