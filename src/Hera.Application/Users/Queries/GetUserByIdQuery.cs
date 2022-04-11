﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hera.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hera.Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly HeraDbContext _context;

        public GetUserByIdHandler(HeraDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);
            return _mapper.Map<UserDto>(user);
        }
    }
}