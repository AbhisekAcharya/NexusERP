using MediatR;
using NexusERP.Application.Common.Errors;
using NexusERP.Application.Interfaces;
using NexusERP.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Commands.Employees.UpdateEmployee
{
    public sealed class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Result>
    {
        private readonly IEmployeeRepository _repository;
        public UpdateEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (employee is null)
            {
                return Result.Failure(EmployeeErrors.NotFound);
            }
            var employeeCodeExists = await _repository.ExistsByEmployeeCodeAsync(request.Request.EmployeeCode, request.Id, cancellationToken);
            if (employeeCodeExists)
            {
                return Result.Failure(EmployeeErrors.EmployeeCodeAlreadyExists);
            }
            var emailExists = await _repository.ExistsByEmailAsync(request.Request.Email, request.Id, cancellationToken);
            if (emailExists)
            {
                return Result.Failure(EmployeeErrors.EmailAlreadyExists);
            }
            employee.Update(request.Request.EmployeeCode, request.Request.FirstName, request.Request.LastName, request.Request.Email, request.Request.Department);
            await _repository.UpdateAsync(employee, cancellationToken);
            return Result.Success();
        }
    }
}
