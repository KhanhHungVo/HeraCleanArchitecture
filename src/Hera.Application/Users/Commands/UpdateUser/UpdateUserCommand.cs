﻿using Hera.Application.Common.Exceptions;
using Hera.Domain.Entities;
using Hera.Infrastructure.Persistence;
using MediatR;

namespace Hera.Application.Users.Commands.UpdateUser
{

        public class UpdateUserCommand : IRequest
        {
            public  int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
        }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
        {
            private readonly HeraDbContext _context;

            public UpdateUserCommandHandler(HeraDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id, cancellationToken);
                if (user == null)
                {
                    throw new NotFoundException(nameof(User), request.Id);
                }

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.UserName = request.UserName;
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }

}