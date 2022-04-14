using System.Reflection;
using Hera.Application.Common.Interfaces;
using Hera.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hera.Infrastructure.Persistence
{
    public class HeraDbContext : DbContext, IHeraDbContext
    {

        public HeraDbContext(DbContextOptions<HeraDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}