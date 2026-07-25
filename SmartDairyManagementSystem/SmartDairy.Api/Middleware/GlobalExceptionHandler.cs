using Microsoft.AspNetCore.Diagnostics;
using SmartDairy.Domain.Exceptions;

namespace SmartDairy.Api.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        async public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if(exception is NotFoundException)
            {
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                await httpContext.Response.WriteAsJsonAsync(new { error = exception.Message }, cancellationToken: cancellationToken);
                return true;
            }

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(
    new
    {
        error = exception.Message,
        type = exception.GetType().Name,
        stackTrace = exception.StackTrace
    },
    cancellationToken: cancellationToken);
            return true;
        }
    }
}
