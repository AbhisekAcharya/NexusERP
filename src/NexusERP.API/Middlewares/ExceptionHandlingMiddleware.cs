using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NexusERP.SharedKernel.Responses;
using System.Text.Json;

namespace NexusERP.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly JsonSerializerOptions _jsonOptions;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IOptions<JsonOptions> jsonOptions)
        {
            _next = next;
            _logger = logger;
            _jsonOptions = jsonOptions.Value.JsonSerializerOptions;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException validationException)
            {
                _logger.LogWarning(validationException, "Validation failed.");
                await HandleValidationExceptionAsync(context, validationException);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var response = ApiResponse<object>.Failure(ResponseMessages.InternalServerError, StatusCodes.Status500InternalServerError);
            return context.Response.WriteAsJsonAsync(response, _jsonOptions);
        }

        private Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            var errors = exception.Errors.GroupBy(x => x.PropertyName.Replace("Request.", "")).ToDictionary(g => g.Key, g => g.Select(x => x.ErrorMessage).ToArray());
            var response = ApiResponse<object>.Failure(ResponseMessages.ValidationFailed, StatusCodes.Status400BadRequest, errors);
            return context.Response.WriteAsJsonAsync(response, _jsonOptions);
        }
    }
}
