using Hera.Application.Users.Commands.AuthenticateUser;
using Hera.Application.Users.Commands.CreateUser;
using Hera.Domain.Entities;

namespace Hera.Application.Common.Interfaces
{
    public interface ICryptoService
    {
        Task RecordCryptoCoins(List<CryptoCoin> cryptoCoins);
        
    }
}