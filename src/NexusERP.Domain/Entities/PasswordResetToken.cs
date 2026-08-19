using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Domain.Entities
{
    public sealed class PasswordResetToken : BaseEntity
    {
        public Guid UserId { get; private set; }
        public string TokenHash { get; private set; } = string.Empty;
        public DateTime ExpiresOnUtc { get; private set; }
        public DateTime? UsedOnUtc { get; private set; }
        public User User { get; private set; } = null!;
        private PasswordResetToken()
        {
        }

        public PasswordResetToken(Guid userId, string tokenHash, DateTime expiresOnUtc)
        {
            UserId = userId;
            TokenHash = tokenHash;
            ExpiresOnUtc = expiresOnUtc;
        }

        public bool IsExpired()
        {
            return DateTime.UtcNow >= ExpiresOnUtc;
        }

        public bool IsUsed()
        {
            return UsedOnUtc.HasValue;
        }

        public void MarkAsUsed()
        {
            UsedOnUtc = DateTime.UtcNow;
            Touch();
        }
    }
}
