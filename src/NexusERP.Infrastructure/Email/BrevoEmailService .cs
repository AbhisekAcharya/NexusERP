using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using NexusERP.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace NexusERP.Infrastructure.Email
{
    public sealed class BrevoEmailService : IEmailService
    {
        private const string BrevoEndpoint = "https://api.brevo.com/v3/smtp/email";
        private readonly HttpClient _httpClient;
        private readonly BrevoSettings _settings;

        public BrevoEmailService(HttpClient httpClient, IOptions<BrevoSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task SendPasswordResetEmailAsync(string email, string resetLink, CancellationToken cancellationToken)
        {
            var request = new BrevoEmailRequest
            {
                Sender = new BrevoSender { Email = _settings.SenderEmail, Name = _settings.SenderName },
                To = [ new BrevoRecipient { Email = email } ],
                Subject = "NexusERP - Reset Your Password",
                TextContent = $"""
                    Hello,

                    We received a request to reset your NexusERP password.

                    Click the link below to reset your password:

                    {resetLink}

                    This link will expire in 30 minutes.

                    If you did not request a password reset, you can safely ignore this email.

                    Regards,
                    NexusERP
                    """
            };
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, BrevoEndpoint);
            httpRequest.Headers.Add("api-key", _settings.ApiKey);
            httpRequest.Content = JsonContent.Create(request);
            using var response = await _httpClient.SendAsync(httpRequest, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new InvalidOperationException(
                    $"Brevo email sending failed. " +
                    $"StatusCode: {(int)response.StatusCode}. " +
                    $"Response: {errorResponse}");
            }
        }
    }
}
