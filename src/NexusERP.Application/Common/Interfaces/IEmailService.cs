using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendPasswordResetEmailAsync(string email, string resetLink, CancellationToken cancellationToken);
    }
}
