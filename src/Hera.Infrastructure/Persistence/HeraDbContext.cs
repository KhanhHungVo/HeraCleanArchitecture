using Hera.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hera.Infrastructure.Persistence
{
    public class HeraDbContext : DbContext
    {

        public HeraDbContext(DbContextOptions<HeraDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}