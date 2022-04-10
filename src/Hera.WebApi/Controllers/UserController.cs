using Hera.Application.Users.Commands.CreateUser;
using Hera.Application.Users.Queries;
using MediatR;
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            return  Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return  Ok(await _mediator.Send(new GetAllUserQuery()));
        }
    }
}
