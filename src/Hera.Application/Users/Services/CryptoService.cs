using AutoMapper;
using Hera.Application.Common.Interfaces;
using Hera.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Hera.Application.Users.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly IHeraDbContext _context;

        public CryptoService(IHeraDbContext context)
        {
            _context = context;
        }

        public async Task RecordCryptoCoins(List<CryptoCoin> cryptoCoins)
        {
            await _context.CryptoCoins.AddRangeAsync(cryptoCoins);
            await _context.SaveChangesAsync();
        }

    }
}