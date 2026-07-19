using MediatR;
using NexusERP.Application.Common.Interfaces;
using NexusERP.Application.Interfaces;
using NexusERP.Domain.Entities;
using NexusERP.SharedKernel.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUserCommand, ApiResponse<CreateUserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserHandler(IUserRepository userRepository, IEmployeeRepository employeeRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<ApiResponse<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Request.EmployeeId, cancellationToken);
            if (employee is null)
                return ApiResponse<CreateUserResponse>.Failure("Employee not found.", 404);
            if (await _userRepository.EmployeeHasUserAsync(request.Request.EmployeeId, cancellationToken))
                return ApiResponse<CreateUserResponse>.Failure("This employee already has a user account.", 400);
            if (await _userRepository.UsernameExistsAsync(request.Request.Username, cancellationToken))
                return ApiResponse<CreateUserResponse>.Failure("Username already exists.", 400);
            var passwordHash = _passwordHasher.Hash(request.Request.Password);
            var user = new User(request.Request.Username, passwordHash, request.Request.Role, request.Request.EmployeeId);
            await _userRepository.AddAsync(user, cancellationToken);
            var response = new CreateUserResponse
            {
                Id = user.Id,
                EmployeeId = user.EmployeeId,
                Username = user.Username,
                Role = user.Role.ToString()
            };
            return ApiResponse<CreateUserResponse>.Success(response, "User created successfully.", 201);
        }
    }
}
