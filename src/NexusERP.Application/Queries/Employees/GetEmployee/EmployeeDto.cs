using NexusERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Queries.Employees.GetEmployee
{
    public sealed record EmployeeDto(Guid Id, string EmployeeCode, string FirstName, string LastName, string Email, string Department, EmployeeStatus Status);
}
