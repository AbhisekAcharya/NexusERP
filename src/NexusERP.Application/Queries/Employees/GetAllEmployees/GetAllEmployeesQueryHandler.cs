using MediatR;
using NexusERP.Application.Interfaces;
using NexusERP.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Queries.Employees.GetAllEmployees
{
    public sealed class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, Result<List<EmployeeDto>>>
    {
        private readonly IEmployeeRepository _repository;
        public GetAllEmployeesQueryHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<List<EmployeeDto>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _repository.GetAllAsync(cancellationToken);
            var dto = employees.Select(x => new EmployeeDto(x.Id, x.EmployeeCode, x.FirstName, x.LastName, x.Email, x.Department, (int)x.Status)).ToList();
            return Result<List<EmployeeDto>>.Success(dto);
        }
    }
}
