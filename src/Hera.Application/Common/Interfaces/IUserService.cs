using Hera.Application.Users.Commands.CreateUser;

namespace Hera.Application.Common.Interfaces
{
    public interface IUserService
    {
         Task<int> RegisterUser(CreateUserCommand userCommand);
    }
}