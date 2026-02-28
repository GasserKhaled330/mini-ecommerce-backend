using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.ExceptionHandlers;

public class GlobalExceptionHandler(IProblemDetailsService problemDetailsService, IHostEnvironment env) : IExceptionHandler
{
	public async ValueTask<bool> TryHandleAsync(
			HttpContext httpContext,
			Exception exception,
			CancellationToken cancellationToken
	)
	{
		httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

		var problemDetails = new ProblemDetails
		{
			Status = httpContext.Response.StatusCode,
			Title = "An unexpected error occurred",
			Type = exception.GetType().Name,
			Instance = httpContext.Request.Path,
			Detail = env.IsDevelopment()
						? exception.Message
						: "An error occurred while processing your request.",
		};
		problemDetails.Extensions["traceId"] = httpContext.TraceIdentifier;
		problemDetails.Extensions["timestamp"] = DateTime.UtcNow;

		return await problemDetailsService.TryWriteAsync(
				new ProblemDetailsContext
				{
					HttpContext = httpContext,
					ProblemDetails = problemDetails,
					Exception = exception,
				}
		);
	}
}
