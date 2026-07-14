using MediatR;
using NexusERP.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Commands.Employees.UpdateEmployee
{
    public sealed record UpdateEmployeeCommand(Guid Id, UpdateEmployeeRequest Request) : IRequest<Result>;
}
