using MediatR;
using NexusERP.Application.Common.Interfaces;
using NexusERP.Application.Interfaces;
using NexusERP.Domain.Entities;
using NexusERP.SharedKernel.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Authentication.Commands.ForgotPassword
{
    public sealed class ForgotPasswordHandler : IRequestHandler<ForgotPasswordCommand, ApiResponse<ForgotPasswordResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordResetTokenRepository _passwordResetTokenRepository;
        private readonly IPasswordResetTokenGenerator _tokenGenerator;
        private readonly IEmailService _emailService;

        public ForgotPasswordHandler(IUserRepository userRepository, IPasswordResetTokenRepository passwordResetTokenRepository, IPasswordResetTokenGenerator tokenGenerator, IEmailService emailService)
        {
            _userRepository = userRepository;
            _passwordResetTokenRepository = passwordResetTokenRepository;
            _tokenGenerator = tokenGenerator;
            _emailService = emailService;
        }

        public async Task<ApiResponse<ForgotPasswordResponse>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var email = request.Request.Email.Trim().ToLowerInvariant();
            var user = await _userRepository.GetByEmailAsync(email, cancellationToken);
            // Do not reveal whether an account exists.
            if (user is null)
            {
                return ApiResponse<ForgotPasswordResponse>.Success(new ForgotPasswordResponse
                    {
                        Message = "If an account exists for this email, a password reset link will be sent."
                    }, "Password reset request processed.", 200);
            }
            // Generate raw token.
            var rawToken = _tokenGenerator.GenerateToken();
            // Store only the hash in database.
            var tokenHash = _tokenGenerator.HashToken(rawToken);
            var resetToken = new PasswordResetToken(user.Id, tokenHash, DateTime.UtcNow.AddMinutes(30));
            await _passwordResetTokenRepository.AddAsync(resetToken, cancellationToken);
            // Frontend reset-password page.
            var resetLink = $"http://localhost:4200/reset-password?token={Uri.EscapeDataString(rawToken)}";
            await _emailService.SendPasswordResetEmailAsync(user.Email, resetLink, cancellationToken);
            return ApiResponse<ForgotPasswordResponse>.Success(new ForgotPasswordResponse
                {
                    Message = "If an account exists for this email, a password reset link will be sent."
                }, "Password reset request processed.", 200);
        }
    }

}
