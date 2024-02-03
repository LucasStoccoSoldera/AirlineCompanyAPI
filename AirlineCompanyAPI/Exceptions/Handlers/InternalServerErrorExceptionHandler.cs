using AirlineCompanyAPI.Utils;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompanyAPI.Exceptions.Handlers
{
    internal sealed class InternalServerErrorExceptionHandler(ILogger<Exception> logger) : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            logger.LogError(
                exception, "Exception occurred: {Message}", exception.Message);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Server error"
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
