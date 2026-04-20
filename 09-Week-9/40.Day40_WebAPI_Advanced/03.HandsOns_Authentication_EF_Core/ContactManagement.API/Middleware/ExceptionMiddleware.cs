using ContactManagement.DAL.Exceptions;
using ContactManagement.API.Models;
using System.Net;
using System.Text.Json;

namespace ContactManagement.API.Middleware
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception Occurred");

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = "Something went wrong";

            switch (ex)
            {
                case NotFoundException:
                    status = HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;

                case ValidationException:
                    status = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;

                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "Internal Server Error";
                    break;
            }

            var response = new ErrorResponse
            {
                Message = message,
                StatusCode = (int)status,
                Timestamp = DateTime.UtcNow
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
