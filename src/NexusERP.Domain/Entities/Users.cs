using NexusERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public string Username { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public UserRole Role { get; private set; }
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;
        private User()
        {

        }
        public User(string username, string passwordHash, UserRole role, Guid employeeId)
        {
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
            EmployeeId = employeeId;
        }
        public void ChangePassword(string passwordHash)
        {
            PasswordHash = passwordHash;
            Touch();
        }
        public void ChangeRole(UserRole role)
        {
            Role = role;
            Touch();
        }
    }
}
