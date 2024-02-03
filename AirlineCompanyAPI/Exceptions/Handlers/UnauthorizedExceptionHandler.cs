using AirlineCompanyAPI.Utils;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompanyAPI.Exceptions.Handlers
{
    internal sealed class UnauthorizedExceptionHandler(ILogger<UnauthorizedExceptionHandler> logger) : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is not UnauthorizedAccessException unauthorizedAccessException)
            {
                return false;
            }

            logger.LogError(
                unauthorizedAccessException,
                "Exception occurred: {Message}",
                unauthorizedAccessException.Message);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "Unauthorized Access",
                Detail = unauthorizedAccessException.Message
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
