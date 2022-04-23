using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hera.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Hera.Application.Common.Helper
{
    public static class JwtHelper
    {
        public static string GenerateToken(User user, string issuer, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Issuer = issuer,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}