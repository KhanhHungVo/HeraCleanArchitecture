using Hera.Application.Users.Commands.AuthenticateUser;
using Hera.Application.Users.Commands.CreateUser;
using Hera.Application.Users.Commands.DeleteUser;
using Hera.Application.Users.Commands.UpdateUser;
using Hera.Application.Users.Queries;
using Hera.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hera.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateCommand command)
        {
            return  Ok(await _mediator.Send(command));
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            return  Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand command)
        {
            var currentUser = (User)HttpContext.Items["User"];
            if (id != currentUser.Id && currentUser.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorization.Authorize(Role.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Authorization.Authorize(Role.Admin)]
        public async Task<IActionResult> GetAllUsers()
        {
            return  Ok(await _mediator.Send(new GetAllUserQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var currentUser = (User)HttpContext.Items["User"];
            if (id != currentUser.Id && currentUser.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
