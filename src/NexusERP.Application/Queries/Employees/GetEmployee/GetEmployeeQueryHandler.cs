using MediatR;
using NexusERP.Application.Common.Errors;
using NexusERP.Application.Interfaces;
using NexusERP.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Queries.Employees.GetEmployee
{
    public sealed class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Result<EmployeeDto>>
    {
        private readonly IEmployeeRepository _repository;
        public GetEmployeeQueryHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (employee is null)
            {
                return Result<EmployeeDto>.Failure(EmployeeErrors.NotFound);
            }
            var dto = new EmployeeDto(employee.Id, employee.EmployeeCode, employee.FirstName, employee.LastName, employee.Email, employee.Department, employee.Status);
            return Result<EmployeeDto>.Success(dto);
        }
    }
}
