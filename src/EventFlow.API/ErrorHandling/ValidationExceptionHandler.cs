using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EventFlow.API.ErrorHandling;

public class ValidationExceptionHandler(ILogger<ValidationExceptionHandler> logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is ValidationException validationException)
        {
            logger.LogError(
                "Validation failed: {errors}",
                string.Join(", ", validationException.Errors
                    .Select(e => $"{e.PropertyName}: {e.ErrorMessage}")));

            var problemDetails = new ProblemDetails
            {
                Title = exception.GetType().Name,
                Status = StatusCodes.Status400BadRequest,
                Detail = "One or more validation errors occurred.",
                Instance = httpContext.Request.Path
            };

            problemDetails.Extensions.Add("traceId", httpContext.TraceIdentifier);
            problemDetails.Extensions.Add("errors", validationException.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage }));

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(problemDetails,
                cancellationToken: cancellationToken);

            return true;
        }

        return false;
    }
}
