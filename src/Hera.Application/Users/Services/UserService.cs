using AutoMapper;
using Hera.Application.Common.Interfaces;
using Hera.Application.Users.Commands.CreateUser;
using Hera.Domain.Entities;

namespace Hera.Application.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IHeraDbContext _context;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IHeraDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> RegisterUser(CreateUserCommand userCommand)
        {
            // validate
            if (_context.Users.Any(x => x.UserName == userCommand.UserName))
                throw new Exception("Username '" + userCommand.UserName + "' is already taken");

            var user = _mapper.Map<User>(userCommand);

            // hash password
            user.Password = BCrypt.Net.BCrypt.HashPassword(userCommand.Password);

            // save user
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        //public AuthenticateResponse Authenticate(AuthenticateRequest model)
        //{
        //    var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

        //    // validate
        //    if (user == null || !BCrypt.Verify(model.Password, user.Password))
        //        throw new AppException("Username or password is incorrect");

        //    // authentication successful
        //    var response = _mapper.Map<AuthenticateResponse>(user);
        //    response.Token = _jwtUtils.GenerateToken(user);
        //    return response;
        //}
    }
}