using CLINICAL.Application.UseCase.UseCases.User.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.User.Queries.LoginQuery;
using CLINICAL.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HasPermission(Permission.RegisterUser)]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
