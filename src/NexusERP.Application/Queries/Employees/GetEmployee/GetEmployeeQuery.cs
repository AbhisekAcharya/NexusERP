using MediatR;
using NexusERP.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Queries.Employees.GetEmployee
{
    public sealed record GetEmployeeQuery(Guid Id) : IRequest<Result<EmployeeDto>>;
}
