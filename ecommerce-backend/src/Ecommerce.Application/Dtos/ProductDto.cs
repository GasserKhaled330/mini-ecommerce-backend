namespace Ecommerce.Application.Dtos;

public sealed record ProductDto(
		int Id,
		string Name,
		string Description,
		decimal Price,
		int Quantity
);
