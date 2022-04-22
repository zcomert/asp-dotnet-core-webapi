using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;

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

    }
}
