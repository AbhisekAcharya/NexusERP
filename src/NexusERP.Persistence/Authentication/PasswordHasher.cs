using NexusERP.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NexusERP.Persistence.Authentication
{
    public sealed class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public bool Verify(string password, string passwordHash)
        {
            return Hash(password) == passwordHash;
        }
    }
}
