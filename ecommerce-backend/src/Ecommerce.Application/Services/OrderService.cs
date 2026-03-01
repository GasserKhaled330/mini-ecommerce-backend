namespace Ecommerce.Application.Services;

public class OrderService(IApplicationDbContext context) : IOrderService
{
	public async Task<Result<OrderDto>> CreateAsync(CreateOrderRequest request)
	{
		var order = new Order { CustomerName = request.CustomerName };
		decimal subtotal = 0;
		int totalItemsCount = request.Items.Sum(i => i.Quantity);

		foreach (var itemRequest in request.Items)
		{
			var product = await context.Products.FindAsync(itemRequest.ProductId);

			// 1. Validate Existence
			if (product == null)
			{
				return Result<OrderDto>.Failure(
						$"Product {itemRequest.ProductId} not found",
						ErrorType.NotFound
				);
			}

			// 2. Validate Stock (US-03)
			if (product.Quantity < itemRequest.Quantity)
			{
				return Result<OrderDto>.Failure(
						$"Insufficient stock for {product.Name}",
						ErrorType.Conflict
				);
			}

			// 3. Deduct Stock
			product.Quantity -= itemRequest.Quantity;

			var orderItem = new OrderItem
			{
				ProductId = product.Id,
				Quantity = itemRequest.Quantity,
				UnitPrice = product.Price,
			};

			order.Items.Add(orderItem);
			subtotal += (orderItem.UnitPrice * orderItem.Quantity);
		}

		// 4. Calculate Discount (US-04)
		order.DiscountAmount = CalculateDiscount(subtotal, totalItemsCount);
		order.TotalAmount = subtotal - order.DiscountAmount;

		context.Orders.Add(order);
		await context.SaveChangesAsync();

		return Result<OrderDto>.Success(order.ToDto());
	}

	public async Task<Result<OrderDto>> GetByIdAsync(int id)
	{
		var order = await context
				.Orders.Include(o => o.Items)
						.ThenInclude(oi => oi.Product)
				.FirstOrDefaultAsync(o => o.Id == id);
		return order == null
				? Result<OrderDto>.Failure($"Order {id} not found", ErrorType.NotFound)
				: Result<OrderDto>.Success(order.ToDto());
	}

	private decimal CalculateDiscount(decimal subtotal, int totalQuantity)
	{
		if (totalQuantity >= 5)
		{
			return subtotal * 0.10m; // 10% discount
		}

		if (totalQuantity >= 2)
		{
			return subtotal * 0.05m; // 5% discount
		}

		return 0;
	}
}
