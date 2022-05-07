using AutoMapper;
using Hera.Application.Common.Helper;
using Hera.Application.Common.Interfaces;
using Hera.Application.Users.Commands.AuthenticateUser;
using Hera.Application.Users.Commands.CreateUser;
using Hera.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hera.Application.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IHeraDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserService(IMapper mapper, IHeraDbContext context, IConfiguration config)
        {
            _mapper = mapper;
            _context = context;
            _config = config;
        }

        public async Task<int> RegisterUser(CreateUserCommand userCommand)
        {
            // validate
            if (_context.Users.Any(x => x.UserName == userCommand.UserName))
                throw new Exception("Username '" + userCommand.UserName + "' is already taken");

            var user = _mapper.Map<User>(userCommand);
            user.Role = Role.Basic;

            // hash password
            user.Password = BCrypt.Net.BCrypt.HashPassword(userCommand.Password);

            // save user
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateCommand model)
        {
           var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == model.UserName);

           // validate
           if (user == null || !BCrypt.Net.BCrypt.Verify(model.PassWord, user.Password))
               throw new UnauthorizedAccessException("Username or password is incorrect");

           // authentication successful
           var response = _mapper.Map<AuthenticateResponse>(user);
           response.Token = JwtHelper.GenerateToken(user, _config["Jwt:Issuer"], _config["Jwt:Secret"]);
           return response;
        }
    }
}