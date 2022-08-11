using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Utilities.OutputFormatter.cs;
using Repository;
using Service;
using Service.Contracts;

namespace ProjectManagement.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });
        }

        public static void ConfigureLoggerManager(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                project => project.MigrationsAssembly("ProjectManagement"))
            );
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
           builder.AddMvcOptions(config => config.OutputFormatters.Add(new CsvOutputFormatter()));

    }
}
