using Hera.Domain.Entities;

namespace Hera.Application.Users.Queries
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}