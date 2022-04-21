using Hera.Application.Common.Interfaces;
using MediatR;

namespace Hera.Application.Users.Commands.AuthenticateUser
{
    public class AuthenticateCommand : IRequest<AuthenticateResponse>
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }

    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticateResponse>
    {
        private readonly IHeraDbContext _context;
        private readonly IUserService _userService;

        public AuthenticateCommandHandler(IHeraDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<AuthenticateResponse> Handle(AuthenticateCommand command, CancellationToken cancellationToken)
        {
            return await _userService.Authenticate(command);
        }
    }


}
