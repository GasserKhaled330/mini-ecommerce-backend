namespace Ecommerce.Application.Common;

public class Result
{
	public bool IsSuccess { get; init; }
	public string? ErrorMessage { get; init; }
	public ErrorType ErrorType { get; init; } = ErrorType.None;

	public static Result Success() => new() { IsSuccess = true };

	public static Result Failure(string errorMessage, ErrorType type = ErrorType.BadRequest) =>
			new()
			{
				IsSuccess = false,
				ErrorMessage = errorMessage,
				ErrorType = type,
			};
}

public class Result<T> : Result
{
	public T? Value { get; init; }

	public static Result<T> Success(T value) => new() { IsSuccess = true, Value = value };

	public static new Result<T> Failure(
			string errorMessage,
			ErrorType type = ErrorType.BadRequest
	) =>
			new()
			{
				IsSuccess = false,
				ErrorMessage = errorMessage,
				ErrorType = type,
			};
}
