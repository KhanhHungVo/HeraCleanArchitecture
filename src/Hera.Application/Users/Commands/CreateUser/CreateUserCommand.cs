using Hera.Application.Common.Interfaces;
using Hera.Domain.Entities;
using MediatR;

namespace Hera.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IHeraDbContext _context;
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IHeraDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //var user = new User
            //{
            //    FirstName = request.FirstName,
            //    LastName = request.LastName,
            //    UserName = request.UserName,
            //    Password = request.Password,
            //    Email = request.Email,
            //};
            //await  _context.Users.AddAsync(user);
            //await _context.SaveChangesAsync();
            //return user.Id;
            return await _userService.RegisterUser(request);
        }
    }
}