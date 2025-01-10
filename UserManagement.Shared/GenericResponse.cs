using Microsoft.AspNetCore.Http;

namespace UserManagement.Shared
{
    /// <summary>
    /// Represents a standardized generic response for API endpoints.
    /// </summary>
    /// <typeparam name="T">The type of the response data.</typeparam>
    public class GenericResponse<T>
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }

        // Constructor with optional parameters for message and data
        public GenericResponse(string? message = null, int code = StatusCodes.Status200OK, T? data = default)
        {
            Message = message ?? "Operation successful.";
            Code = code;
            Data = data;
        }

        // Static factory methods for common responses
        public static GenericResponse<T> Success(T data, string? message = null) =>
            new GenericResponse<T>(message ?? "Operation successful.", StatusCodes.Status200OK, data);

        public static GenericResponse<T> BadRequest(string? message = null) =>
            new GenericResponse<T>(message ?? "Bad request.", StatusCodes.Status400BadRequest);

        public static GenericResponse<T> ValidationError(string? message = null, T? data = default) =>
            new GenericResponse<T>(message ?? "Validation errors occurred.", StatusCodes.Status400BadRequest, data);

        public static GenericResponse<T> InternalServerError(string? message = null) =>
            new GenericResponse<T>(message ?? "An internal server error occurred.", StatusCodes.Status500InternalServerError);

        public static GenericResponse<T> NotFound(string? message = null) =>
            new GenericResponse<T>(message ?? "Resource not found.", StatusCodes.Status404NotFound);

        public static GenericResponse<T> Conflict(string? message = null) =>
            new GenericResponse<T>(message ?? "Conflict occurred.", StatusCodes.Status409Conflict);
    }
}
