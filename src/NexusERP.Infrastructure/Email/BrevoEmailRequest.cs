using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NexusERP.Infrastructure.Email
{
    public sealed class BrevoEmailRequest
    {
        [JsonPropertyName("sender")]
        public BrevoSender Sender { get; set; } = null!;

        [JsonPropertyName("to")]
        public List<BrevoRecipient> To { get; set; } = [];

        [JsonPropertyName("subject")]
        public string Subject { get; set; } = string.Empty;

        [JsonPropertyName("textContent")]
        public string TextContent { get; set; } = string.Empty;
    }
}
