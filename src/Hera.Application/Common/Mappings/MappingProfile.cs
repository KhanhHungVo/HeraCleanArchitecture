using System.Reflection;
using AutoMapper;
using Hera.Application.Users.Commands.CreateUser;
using Hera.Application.Users.Queries;
using Hera.Domain.Entities;

namespace Hera.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserCommand, User>();
        }

    }

    
}
