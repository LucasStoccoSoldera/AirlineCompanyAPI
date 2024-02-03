﻿using AirlineCompanyAPI.Utils;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompanyAPI.Exceptions.Handlers
{
    internal sealed class BadRequestExceptionHandler(ILogger<BadRequestExceptionHandler> logger) : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is not BadHttpRequestException badRequestException)
            {
                return false;
            }

            logger.LogError(
                badRequestException,
                "Exception occurred: {Message}",
                badRequestException.Message);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Bad Request",
                Detail = badRequestException.Message
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
