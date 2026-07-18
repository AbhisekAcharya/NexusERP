using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.SharedKernel.Responses
{
    public sealed class ApiResponse<T>
    {
        public ResponseStatus Status { get; init; }
        public int StatusCode { get; init; }
        public string Message { get; init; } = string.Empty;
        public DateTime Timestamp { get; init; }
        public T? Data { get; init; }
        public static ApiResponse<T> Success(T? data, string message, int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                Status = ResponseStatus.Success,
                StatusCode = statusCode,
                Message = message,
                Data = data,
                Timestamp = DateTime.UtcNow
            };
        }
        public static ApiResponse<T> Failure(string message, int statusCode)
        {
            return new ApiResponse<T>
            {
                Status = ResponseStatus.Failure,
                StatusCode = statusCode,
                Message = message,
                Data = default,
                Timestamp = DateTime.UtcNow
            };
        }
    }
}
