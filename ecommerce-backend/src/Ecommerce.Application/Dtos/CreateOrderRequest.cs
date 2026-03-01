namespace Ecommerce.Application.Dtos;

public sealed record CreateOrderRequest(string CustomerName, List<OrderItemRequest> Items);
