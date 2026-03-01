namespace Ecommerce.Application.Dtos;

public sealed record OrderDto(
		int Id,
		string CustomerName,
		decimal Subtotal, // Sum of (Price * Qty) before discount
		decimal DiscountAmount,
		decimal TotalAmount,
		double DiscountPercentage, // Calculated for UI display
		DateTime CreatedAt,
		List<OrderItemDto> Items
);
