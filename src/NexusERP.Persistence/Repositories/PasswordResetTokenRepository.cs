using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Interfaces;
using NexusERP.Domain.Entities;
using NexusERP.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Persistence.Repositories
{
    public sealed class PasswordResetTokenRepository : IPasswordResetTokenRepository
    {
        private readonly ApplicationDbContext _context;

        public PasswordResetTokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PasswordResetToken token, CancellationToken cancellationToken)
        {
            await _context.PasswordResetTokens.AddAsync(token, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<PasswordResetToken?> GetByTokenHashAsync(string tokenHash, CancellationToken cancellationToken)
        {
            return await _context.PasswordResetTokens.Include(x => x.User).FirstOrDefaultAsync(x => x.TokenHash == tokenHash, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
