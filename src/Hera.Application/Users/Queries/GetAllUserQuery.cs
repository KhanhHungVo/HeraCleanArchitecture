using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;
        private readonly HeraDbContext _context;

        public GetAllUserQueryHandler(HeraDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.ProjectTo<UserDto>(_mapper.ConfigurationProvider).ToListAsync();
            return users;
        }
    }
}
