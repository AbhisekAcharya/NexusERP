using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Commands.Employees.UpdateEmployee
{
    public sealed record UpdateEmployeeRequest(string EmployeeCode, string FirstName, string LastName, string Email, string Department);
}
