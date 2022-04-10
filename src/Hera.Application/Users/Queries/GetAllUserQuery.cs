using Hera.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hera.Application.Users.Queries
{
    public class GetAllUserQuery : IRequest<List<UserDto>>
    {

    }
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserDto>>
    {
        private readonly HeraDbContext _context;

        public GetAllUserQueryHandler(HeraDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(u => new UserDto
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
            }).ToList();
        }
    }
}
