using NexusERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Domain.Entities
{
    public sealed class Employee : BaseEntity
    {
        public string EmployeeCode { get; private set; } = string.Empty;
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Department { get; private set; } = string.Empty;
        public EmployeeStatus Status { get; private set; }
        private Employee()
        {
        }
        public Employee(string employeeCode, string firstName, string lastName, string email, string department)
        {
            EmployeeCode = employeeCode;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Department = department;
            Status = EmployeeStatus.Active;
        }
        public void ChangeDepartment(string department)
        {
            Department = department;
            ModifiedOnUtc = DateTime.UtcNow;
        }
        public void ChangeStatus(EmployeeStatus status)
        {
            Status = status;
            ModifiedOnUtc = DateTime.UtcNow;
        }
    }
}
