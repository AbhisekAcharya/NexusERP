using NexusERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Authentication.Commands.Login
{
    public sealed class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Username { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
