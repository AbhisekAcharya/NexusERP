using MediatR;
using NexusERP.Application.Common.Interfaces;
using NexusERP.SharedKernel.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Authentication.Commands.Login
{
    public sealed class LoginHandler : IRequestHandler<LoginCommand, ApiResponse<LoginResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenProvider _jwtTokenProvider;

        public LoginHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenProvider jwtTokenProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenProvider = jwtTokenProvider;
        }

        public async Task<ApiResponse<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Request.Username, cancellationToken);
            if (user is null)
                return ApiResponse<LoginResponse>.Failure("Invalid username or password.", 401);
            var isValidPassword = _passwordHasher.Verify(request.Request.Password, user.PasswordHash);
            if (!isValidPassword)
                return ApiResponse<LoginResponse>.Failure("Invalid username or password.", 401);
            var token = _jwtTokenProvider.GenerateToken(user);
            var response = new LoginResponse
            {
                Token = token,
                UserId = user.Id,
                EmployeeId = user.EmployeeId,
                Username = user.Username,
                Role = user.Role
            };
            return ApiResponse<LoginResponse>.Success(response, "Login successful.", 200);
        }
    }
}
