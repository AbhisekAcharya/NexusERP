using NexusERP.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NexusERP.Infrastructure.Authentication
{
    public sealed class PasswordResetTokenGenerator : IPasswordResetTokenGenerator
    {
        public string GenerateToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(tokenBytes).Replace("+", "-").Replace("/", "_").Replace("=", "");
        }

        public string HashToken(string token)
        {
            var tokenBytes = Encoding.UTF8.GetBytes(token);
            var hashBytes = SHA512.HashData(tokenBytes);
            return Convert.ToHexString(hashBytes).ToLowerInvariant();
        }
    }
}
