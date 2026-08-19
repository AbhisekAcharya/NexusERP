using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexusERP.Application.Features.Authentication.Commands.ForgotPassword;
using NexusERP.Application.Features.Authentication.Commands.Login;
using NexusERP.Application.Features.Authentication.Commands.ResetPassword;

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

        [HttpPost("forgot-password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ForgotPasswordCommand(request), cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("reset-password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ResetPasswordCommand(request), cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
