using MediatR;
using NexusERP.SharedKernel.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Features.Authentication.Commands.ResetPassword
{
    public sealed record ResetPasswordCommand(ResetPasswordRequest Request) : IRequest<ApiResponse<ResetPasswordResponse>>;
}
