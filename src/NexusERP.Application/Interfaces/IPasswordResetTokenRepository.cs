using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Interfaces
{
    public interface IPasswordResetTokenRepository
    {
        Task AddAsync(PasswordResetToken token, CancellationToken cancellationToken);
        Task<PasswordResetToken?> GetByTokenHashAsync(string tokenHash, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
