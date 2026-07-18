using MediatR;
using NexusERP.Application.Commands.Employees.CreateEmployee;
using NexusERP.Application.Common.Errors;
using NexusERP.Application.Interfaces;
using NexusERP.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Commands.Employees.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Result>
    {
        private readonly IEmployeeRepository _repository;
        public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (employee is null)
                return Result.Failure(EmployeeErrors.NotFound);
            await _repository.DeleteAsync(employee, cancellationToken);
            return Result.Success();
        }
    }
}
