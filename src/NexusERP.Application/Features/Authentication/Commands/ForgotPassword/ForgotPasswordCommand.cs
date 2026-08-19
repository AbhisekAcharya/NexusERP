using MediatR;
using NexusERP.SharedKernel.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Authentication.Commands.ForgotPassword
{
    public sealed record ForgotPasswordCommand(ForgotPasswordRequest Request) : IRequest<ApiResponse<ForgotPasswordResponse>>;
}
