using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NexusERP.Infrastructure.Email
{
    public sealed class BrevoSender
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
