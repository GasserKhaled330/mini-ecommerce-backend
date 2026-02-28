namespace Ecommerce.Application.Dtos;

public sealed record UpdateProductRequest(
		string? Name,
		string? Description,
		decimal? Price,
		int? Quantity
);
