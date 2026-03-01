namespace Ecommerce.Application.Interfaces.Services;

public interface IOrderService
{
	Task<Result<OrderDto>> GetByIdAsync(int orderId);
	Task<Result<OrderDto>> CreateAsync(CreateOrderRequest request);
}
