using Hera.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hera.Application.Common.Interfaces;
using Hera.Infrastructure.Services.CoinMarketCapAPI;
using Microsoft.Extensions.Logging;

namespace Hera.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,
            IConfiguration configuration, ILogger logger)
        {
            ConfigureDatabases(services, configuration, logger);
            services.AddScoped<IHeraDbContext, HeraDbContext>();
            services.AddScoped<ICoinMarketCapService, CoinMarketCapService>();
            return services;
        }
        private static void ConfigureDatabases(IServiceCollection services, IConfiguration configuration, ILogger logger)
        {
            var connectionString = configuration.GetConnectionString("HeraDatabase");
            logger.LogInformation($"Db connection string : {connectionString}");
            services.AddDbContext<HeraDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
