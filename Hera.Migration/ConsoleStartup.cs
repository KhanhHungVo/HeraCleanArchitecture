using Microsoft.AspNetCore.Hosting;
using Hera.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hera.Migration
{
    public class ConsoleStartup
    {
        public ConsoleStartup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            //.. for test
            Console.WriteLine(Configuration.GetConnectionString("HeraDbContext"));
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HeraDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("HeraDatabase"));

            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }

    }
}
