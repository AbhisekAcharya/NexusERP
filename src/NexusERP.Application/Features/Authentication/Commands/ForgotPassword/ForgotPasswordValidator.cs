using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Authentication.Commands.ForgotPassword
{
    public sealed class ForgotPasswordValidator : AbstractValidator<ForgotPasswordCommand>
    {        
        public ForgotPasswordValidator()
        {
            RuleFor(x => x.Request.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Please enter a valid email address.")
                .MaximumLength(256)
                .WithMessage("Email cannot exceed 256 characters.");
        }
    }
}
