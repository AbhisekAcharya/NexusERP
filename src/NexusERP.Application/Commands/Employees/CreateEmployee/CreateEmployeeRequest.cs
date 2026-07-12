using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Commands.Employees.CreateEmployee
{
    public sealed record CreateEmployeeRequest(string EmployeeCode, string FirstName, string LastName, string Email, string Department);
}
