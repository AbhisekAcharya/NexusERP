using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Request.EmployeeId).NotEmpty().WithMessage("Employee is required.");
            RuleFor(x => x.Request.Username).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Request.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.Request.Role).IsInEnum().WithMessage("Invalid role.");
        }
    }
}
