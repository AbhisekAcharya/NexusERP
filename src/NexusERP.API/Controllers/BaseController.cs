using Microsoft.AspNetCore.Mvc;
using NexusERP.SharedKernel.Responses;

namespace NexusERP.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult SuccessResponse<T>(T data, string message, int statusCode = StatusCodes.Status200OK)
        {
            var response = ApiResponse<T>.Success(data, message, statusCode);
            return StatusCode(statusCode, response);
        }

        protected IActionResult FailureResponse(string message, int statusCode)
        {
            var response = ApiResponse<object>.Failure(message, statusCode);
            return StatusCode(statusCode, response);
        }
    }
}
