using Hera.Application.Users.Commands.AuthenticateUser;
using Hera.Application.Users.Commands.CreateUser;

namespace Hera.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<int> RegisterUser(CreateUserCommand userCommand);
        Task<AuthenticateResponse> Authenticate(AuthenticateCommand model);
    }
}