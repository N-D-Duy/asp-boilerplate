using ASPCleanArchitechture.Domain.DomainServices;
using ASPCleanArchitechture.Domain.Repositories;
using ASPCleanArchitechture.Infrastructure.ORM;
using ASPCleanArchitechture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASPCleanArchitechture.Infrastructure
{
    public static class ConfigService
    {
        public static IServiceCollection AddInfrastructureConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<ITodoRepository, TodoRepository>();
            return services;
        }
    }
}
