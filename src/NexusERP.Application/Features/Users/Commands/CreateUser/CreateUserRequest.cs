using NexusERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserRequest
    {
        public Guid EmployeeId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
