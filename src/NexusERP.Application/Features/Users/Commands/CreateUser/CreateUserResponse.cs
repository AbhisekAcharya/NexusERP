using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserResponse
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
