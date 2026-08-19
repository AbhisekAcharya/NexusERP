using MediatR;
using NexusERP.Application.Common.Interfaces;
using NexusERP.Application.Interfaces;
using NexusERP.SharedKernel.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Authentication.Commands.ResetPassword
{
    public sealed class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, ApiResponse<ResetPasswordResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordResetTokenRepository _passwordResetTokenRepository;
        private readonly IPasswordResetTokenGenerator _tokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public ResetPasswordHandler(IUserRepository userRepository, IPasswordResetTokenRepository passwordResetTokenRepository, IPasswordResetTokenGenerator tokenGenerator, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordResetTokenRepository = passwordResetTokenRepository;
            _tokenGenerator = tokenGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<ApiResponse<ResetPasswordResponse>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var rawToken = request.Request.Token.Trim();
            var tokenHash = _tokenGenerator.HashToken(rawToken);
            var resetToken = await _passwordResetTokenRepository.GetByTokenHashAsync(tokenHash, cancellationToken);
            if (resetToken is null)
                return ApiResponse<ResetPasswordResponse>.Failure("Invalid or expired password reset token.", 400);
            if (resetToken.IsExpired())
                return ApiResponse<ResetPasswordResponse>.Failure("Invalid or expired password reset token.", 400);
            if (resetToken.IsUsed())
                return ApiResponse<ResetPasswordResponse>.Failure("This password reset token has already been used.", 400);
            var user = resetToken.User;
            if (user is null)
                return ApiResponse<ResetPasswordResponse>.Failure("Unable to process password reset.", 400);
            user.ChangePassword(_passwordHasher.Hash(request.Request.NewPassword));
            resetToken.MarkAsUsed();
            await _passwordResetTokenRepository.SaveChangesAsync(cancellationToken);
            return ApiResponse<ResetPasswordResponse>.Success(new ResetPasswordResponse
                {
                    Message = "Password has been reset successfully."
                },
                "Password reset successful.",
                200);
        }
    }
}
