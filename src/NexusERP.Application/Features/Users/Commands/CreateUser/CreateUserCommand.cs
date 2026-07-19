using MediatR;
using NexusERP.SharedKernel.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand(CreateUserRequest Request) : IRequest<ApiResponse<CreateUserResponse>>;
}
