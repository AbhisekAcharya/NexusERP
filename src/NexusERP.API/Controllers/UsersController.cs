using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexusERP.Application.Features.Users.Commands.CreateUser;

namespace NexusERP.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public sealed class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateUserCommand(request), cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
