using MediatR;
using NexusERP.Application.Common.Errors;
using NexusERP.Application.Interfaces;
using NexusERP.Domain.Entities;
using NexusERP.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Commands.Employees.CreateEmployee
{
    public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<Guid>>
    {
        private readonly IEmployeeRepository _repository;
        public CreateEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeByCode = await _repository.GetByEmployeeCodeAsync(request.Request.EmployeeCode, cancellationToken);
            if (employeeByCode is not null)
            {
                return Result<Guid>.Failure(EmployeeErrors.EmployeeCodeAlreadyExists);
            }
            var employeeByEmail = await _repository.GetByEmailAsync(request.Request.Email, cancellationToken);
            if (employeeByEmail is not null)
            {
                return Result<Guid>.Failure(EmployeeErrors.EmailAlreadyExists);
            }
            var employee = new Employee(request.Request.EmployeeCode, request.Request.FirstName, request.Request.LastName, request.Request.Email, request.Request.Department);
            await _repository.AddAsync(employee, cancellationToken);
            return Result<Guid>.Success(employee.Id);
        }
    }
}
