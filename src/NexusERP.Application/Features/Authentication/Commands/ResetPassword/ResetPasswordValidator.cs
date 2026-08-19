using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Authentication.Commands.ResetPassword
{
    public sealed class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordValidator()
        {
            RuleFor(x => x.Request.Token).NotEmpty().WithMessage("Reset token is required.");
            RuleFor(x => x.Request.NewPassword)
                .NotEmpty().WithMessage("New password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .MaximumLength(128).WithMessage("Password cannot exceed 128 characters.");
        }
    }
}
