namespace Ecommerce.Application.Mappings;

public static class ProductMappingExtensions
{
	public static ProductDto ToDto(this Product product)
	{
		return new ProductDto(
			product.Id,
			product.Name,
			product.Description,
			product.Price,
			product.Quantity
		);
	}
	public static Product ToEntity(this CreateProductRequest dto)
	{
		return new Product
		{
			Name = dto.Name,
			Description = dto.Description,
			Price = dto.Price,
			Quantity = dto.Quantity
		};
	}

	public static void UpdateEntity(this UpdateProductRequest dto, Product product)
	{
		product.Name = !string.IsNullOrWhiteSpace(dto.Name) ? dto.Name : product.Name;
		product.Description = dto?.Description ?? product.Description;
		product.Price = dto?.Price ?? product.Price;
		product.Quantity = dto?.Quantity ?? product.Quantity;
	}
}
