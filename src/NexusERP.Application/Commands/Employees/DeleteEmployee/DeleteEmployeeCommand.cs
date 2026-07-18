using MediatR;
using NexusERP.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Commands.Employees.DeleteEmployee
{
    public sealed record DeleteEmployeeCommand(Guid Id) : IRequest<Result>;
}
