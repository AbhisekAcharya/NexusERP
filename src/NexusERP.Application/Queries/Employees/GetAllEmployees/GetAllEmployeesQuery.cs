using MediatR;
using NexusERP.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Queries.Employees.GetAllEmployees
{
    public sealed record GetAllEmployeesQuery() : IRequest<Result<List<EmployeeDto>>>;
}
