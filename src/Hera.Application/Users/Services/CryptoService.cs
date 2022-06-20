using AutoMapper;
using Hera.Application.Common.Interfaces;
using Hera.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Hera.Application.Users.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly IHeraDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public CryptoService(IMapper mapper, IHeraDbContext context, IConfiguration config)
        {
            _mapper = mapper;
            _context = context;
            _config = config;
        }

        public async Task RecordCryptoCoins(List<CryptoCoin> cryptoCoins)
        {
            await _context.CryptoCoins.AddRangeAsync(cryptoCoins);
        }

    }
}