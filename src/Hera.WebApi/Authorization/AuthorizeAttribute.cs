using Hera.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hera.WebApi.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> _roles;

        public AuthorizeAttribute(): base()
        {
        }
        public AuthorizeAttribute(params Role[] roles)
        {
            _roles = roles ?? new Role[] {};
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User) context.HttpContext.Items["User"];
            if( user == null || ( _roles != null && _roles.Any() && !_roles.Contains(user.Role))){
                context.Result = new JsonResult(new { message = "Unauthorized" }) 
                {
                    StatusCode = StatusCodes.Status401Unauthorized 
                };
            }
        }
    }
}