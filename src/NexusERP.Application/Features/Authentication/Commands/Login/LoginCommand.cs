using MediatR;
using NexusERP.SharedKernel.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Authentication.Commands.Login
{
    public sealed record LoginCommand(LoginRequest Request) : IRequest<ApiResponse<LoginResponse>>;
}
