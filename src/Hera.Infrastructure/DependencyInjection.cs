using Hera.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hera.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,
            IConfiguration configuration)
        {
            ConfigureDatabases(services, configuration);
            return services;
        }
        private static void ConfigureDatabases(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("HeraDatabase");

            services.AddDbContext<HeraDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
