namespace Ecommerce.Application.Dtos;

public sealed record CreateProductRequest(
		string Name,
		string Description,
		decimal Price,
		int Quantity
);
