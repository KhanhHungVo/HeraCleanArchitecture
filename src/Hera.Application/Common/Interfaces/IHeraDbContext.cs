using Hera.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hera.Application.Common.Interfaces
{
    public interface IHeraDbContext
    {
        DbSet<User> Users { get;}
        DbSet<UserFavorite> UserFavorites { get;}
        DbSet<CryptoCoin> CryptoCoins { get; }
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}