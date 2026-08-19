using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Authentication.Commands.ForgotPassword
{
    public sealed class ForgotPasswordRequest
    {
        public string Email { get; set; } = string.Empty;
    }
}
