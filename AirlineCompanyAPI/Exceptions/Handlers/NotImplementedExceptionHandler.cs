using AirlineCompanyAPI.Utils;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompanyAPI.Exceptions.Handlers
{
    internal sealed class NotImplementedExceptionHandler(ILogger<NotImplementedExceptionHandler> logger) : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is not NotImplementedException notImplementedException)
            {
                return false;
            }

            logger.LogError(
                notImplementedException,
                "Exception occurred: {Message}",
                notImplementedException.Message);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Not Found",
                Detail = notImplementedException.Message
            };

            await JsonResponseUtils.SendExecepcionResponseAsync(
                httpContext,
                problemDetails,
                cancellationToken
            );

            return true;
        }
    }
}
