using Hera.Application.Common.Exceptions;
using Hera.Application.Common.Interfaces;
using Hera.Domain.Entities;
using MediatR;

namespace Hera.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public  int Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IHeraDbContext _context;

        public DeleteUserCommandHandler(IHeraDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync( request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
