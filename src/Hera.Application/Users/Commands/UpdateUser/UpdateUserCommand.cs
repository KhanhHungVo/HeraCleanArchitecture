using Hera.Application.Common.Exceptions;
using Hera.Application.Common.Interfaces;
using Hera.Domain.Entities;
using MediatR;

namespace Hera.Application.Users.Commands.UpdateUser
{

        public class UpdateUserCommand : IRequest
        {
            public  int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
        }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
        {
            private readonly IHeraDbContext _context;

            public UpdateUserCommandHandler(IHeraDbContext context)
            {
                _context = context;
            }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.UserName = request.UserName;
            user.Email = request.Email;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }

}
