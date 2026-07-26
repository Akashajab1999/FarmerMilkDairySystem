using Microsoft.AspNetCore.Diagnostics;
using SmartDairy.Domain.Exceptions;

namespace SmartDairy.Api.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        async public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if(exception is NotFoundException)
            {
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                await httpContext.Response.WriteAsJsonAsync(new { error = exception.Message }, cancellationToken: cancellationToken);
                _logger.LogWarning(exception,exception.Message);
                return true;
            }

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(
                new
                {
                    error = exception.Message
                },
                cancellationToken: cancellationToken);
            _logger.LogError(exception,"An unexpected exception occurred.");
            return true;
        }

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
    }
}
