using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Common.Interfaces
{
    public interface IPasswordResetTokenGenerator
    {
        string GenerateToken();
        string HashToken(string token);
    }
}
