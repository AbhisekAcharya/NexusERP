using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Authentication.Commands.Login
{
    public sealed class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Request.Username).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.Request.Password).NotEmpty().WithMessage("Password is required.");
        }
    }
}
