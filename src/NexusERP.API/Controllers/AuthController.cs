using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexusERP.Application.Features.Authentication.Commands.Login;

namespace NexusERP.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public sealed class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new LoginCommand(request), cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
