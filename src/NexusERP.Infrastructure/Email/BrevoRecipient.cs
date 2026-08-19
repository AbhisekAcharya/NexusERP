using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NexusERP.Infrastructure.Email
{
    public sealed class BrevoRecipient
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
    }
}
