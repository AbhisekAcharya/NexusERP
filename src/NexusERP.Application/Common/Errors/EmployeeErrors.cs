using NexusERP.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Common.Errors
{
    public static class EmployeeErrors
    {
        public static readonly Error NotFound = new Error("Employee.NotFound", "Employee not found.");
        public static readonly Error EmployeeCodeAlreadyExists = new("Employee.EmployeeCodeExists", "Employee Code already exists.");
        public static readonly Error EmailAlreadyExists = new("Employee.EmailExists", "Email already exists.");
    }
}
