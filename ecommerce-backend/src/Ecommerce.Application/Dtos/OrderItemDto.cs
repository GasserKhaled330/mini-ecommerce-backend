namespace Ecommerce.Application.Dtos;

public sealed record OrderItemDto(
		int ProductId,
		string ProductName, // Helpful for the UI to avoid extra lookups
		int Quantity,
		decimal UnitPrice,
		decimal LineTotal
);
