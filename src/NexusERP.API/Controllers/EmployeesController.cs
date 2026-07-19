using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusERP.Application.Commands.Employees.CreateEmployee;
using NexusERP.Application.Commands.Employees.DeleteEmployee;
using NexusERP.Application.Commands.Employees.UpdateEmployee;
using NexusERP.Application.Common.Errors;
using NexusERP.Application.Queries.Employees.GetAllEmployees;
using NexusERP.Application.Queries.Employees.GetEmployee;
using NexusERP.SharedKernel.Responses;

namespace NexusERP.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public sealed class EmployeesController : BaseController
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
                    return FailureResponse(result.Error.Message, StatusCodes.Status409Conflict);
                return FailureResponse(result.Error.Message, StatusCodes.Status400BadRequest);
            }
            return SuccessResponse(result.Value, ResponseMessages.Created, StatusCodes.Status201Created);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetEmployeeQuery(id));
            if (result.IsFailure)
                return FailureResponse(result.Error.Message, StatusCodes.Status404NotFound);
            return SuccessResponse(result.Value, ResponseMessages.Retrieved);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery(), cancellationToken);
            return SuccessResponse(result.Value, ResponseMessages.RetrievedAll);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateEmployeeCommand(id, request);
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsFailure)
            {
                if (result.Error == EmployeeErrors.NotFound)
                    return FailureResponse(result.Error.Message, StatusCodes.Status404NotFound);
                if (result.Error == EmployeeErrors.EmployeeCodeAlreadyExists || result.Error == EmployeeErrors.EmailAlreadyExists)
                    return FailureResponse(result.Error.Message, StatusCodes.Status409Conflict);
                return FailureResponse(result.Error.Message, StatusCodes.Status400BadRequest);
            }
            return SuccessResponse<object?>(null, ResponseMessages.Updated);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteEmployeeCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsFailure)
                return FailureResponse(result.Error.Message, StatusCodes.Status404NotFound);
            return SuccessResponse<object?>(null, ResponseMessages.Deleted);
        }
    }
}
