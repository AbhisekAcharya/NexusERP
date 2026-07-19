using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Common.Authentication
{
    public sealed class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string Issuer { get; init; } = string.Empty;
        public string Audience { get; init; } = string.Empty;
        public string SecretKey { get; init; } = string.Empty;
        public int ExpiryInMinutes { get; init; }
    }
}
