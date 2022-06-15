using Hera.Application.Common.Interfaces;
using Hera.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hera.Infrastructure
{
    public static class DatabaseMigration
    {
        public static void InitializeDatabase(this IApplicationBuilder app){
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<HeraDbContext>().Database.Migrate();
            }
        }
    }
}