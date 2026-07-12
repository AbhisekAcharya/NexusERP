using MediatR;
using NexusERP.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Commands.Employees.CreateEmployee
{
    public sealed record CreateEmployeeCommand(CreateEmployeeRequest Request) : IRequest<Result<Guid>>;
}
