namespace Ecommerce.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public abstract class BaseApiController : ControllerBase
{
	protected ActionResult HandleResult<T>(Result<T> result)
	{
		return result.IsSuccess ? Ok(result.Value) : MapErrorToProblem(result);
	}

	protected ActionResult HandleResult(Result result)
	{
		return result.IsSuccess ? NoContent() : MapErrorToProblem(result);
	}

	protected ActionResult HandleCreated<T>(Result<T> result, string routeName, object routeValues)
	{
		return result.IsSuccess
				? CreatedAtRoute(routeName, routeValues, result.Value)
				: MapErrorToProblem(result);
	}

	private ObjectResult MapErrorToProblem(Result result)
	{
		var statusCode = result.ErrorType switch
		{
			ErrorType.NotFound => StatusCodes.Status404NotFound,
			ErrorType.Conflict => StatusCodes.Status409Conflict,
			ErrorType.BadRequest => StatusCodes.Status400BadRequest,
			_ => StatusCodes.Status400BadRequest,
		};

		return Problem(
				detail: result.ErrorMessage,
				statusCode: statusCode,
				title: result.ErrorType.ToString()
		);
	}
}
