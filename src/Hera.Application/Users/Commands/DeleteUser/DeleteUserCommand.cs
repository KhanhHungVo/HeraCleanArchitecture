using Hera.Application.Common.Exceptions;
using Hera.Domain.Entities;
using Hera.Infrastructure.Persistence;
using MediatR;

namespace Hera.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
        public  int Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly HeraDbContext _context;

        public DeleteUserCommandHandler(HeraDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync( new object[] {request.Id}, cancellationToken);

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
