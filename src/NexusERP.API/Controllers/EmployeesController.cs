using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexusERP.Application.Commands.Employees.CreateEmployee;
using NexusERP.Application.Commands.Employees.UpdateEmployee;
using NexusERP.Application.Common.Errors;
using NexusERP.Application.Queries.Employees.GetAllEmployees;
using NexusERP.Application.Queries.Employees.GetEmployee;

namespace NexusERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateEmployeeCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsFailure)
            {
                if (result.Error == EmployeeErrors.EmployeeCodeAlreadyExists || result.Error == EmployeeErrors.EmailAlreadyExists)
                    return Conflict(result.Error); 
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetEmployeeQuery(id));
            if (result.IsFailure)
                return NotFound(result.Error);
            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery(), cancellationToken);
            return Ok(result.Value);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateEmployeeCommand(id, request);
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsFailure)
            {
                if (result.Error == EmployeeErrors.NotFound)
                    return NotFound(result.Error);
                if (result.Error == EmployeeErrors.EmployeeCodeAlreadyExists || result.Error == EmployeeErrors.EmailAlreadyExists)
                    return Conflict(result.Error);
                return BadRequest(result.Error);
            }
            return NoContent();
        }
    }
}
