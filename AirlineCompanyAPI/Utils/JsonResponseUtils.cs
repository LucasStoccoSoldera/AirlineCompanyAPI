using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace AirlineCompanyAPI.Utils
{
    public class JsonResponseUtils
    {
        public static async Task SendExecepcionResponseAsync(
            HttpContext httpContext, 
            ProblemDetails problemDetails, 
            CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);
        }
    }
}
