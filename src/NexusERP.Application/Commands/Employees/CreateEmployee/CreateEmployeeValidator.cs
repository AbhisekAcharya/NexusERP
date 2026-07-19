using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Commands.Employees.CreateEmployee
{
    public sealed class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Request.EmployeeCode).NotEmpty().WithMessage("Employee Code is required.").MaximumLength(20).WithMessage("Employee Code cannot exceed 20 characters."); ;
            RuleFor(x => x.Request.FirstName).NotEmpty().WithMessage("First Name is required.").MaximumLength(100).WithMessage("First Name cannot exceed 100 characters.");
            RuleFor(x => x.Request.LastName).NotEmpty().WithMessage("Last Name is required.").MaximumLength(100).WithMessage("Last Name cannot exceed 100 characters.");
            RuleFor(x => x.Request.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.Request.Department).NotEmpty().WithMessage("Department is required.");
        }
    }
}
