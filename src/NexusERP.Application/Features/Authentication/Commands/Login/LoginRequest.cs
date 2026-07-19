using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Authentication.Commands.Login
{
    public sealed class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
