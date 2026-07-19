using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Common.Interfaces
{
    public interface IJwtTokenProvider
    {
        string GenerateToken(Domain.Entities.User user);
    }
}
