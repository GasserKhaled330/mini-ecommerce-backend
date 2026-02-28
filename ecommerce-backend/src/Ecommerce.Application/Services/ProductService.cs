namespace Ecommerce.Application.Services;

public class ProductService(IApplicationDbContext context) : IProductService
{
	public async Task<ProductDto?> GetByIdAsync(int id)
	{
		var product = await context.Products.FindAsync(id);

		return product?.ToDto();
	}

	public async Task<PagedResponse<IReadOnlyList<ProductDto>>> GetAllAsync(
			int pageNumber,
			int pageSize
	)
	{
		var totalCount = await context.Products.CountAsync();

		var products = await context
				.Products.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.Select(p => p.ToDto())
				.ToListAsync();

		return new PagedResponse<IReadOnlyList<ProductDto>>(
				products,
				pageNumber,
				pageSize,
				totalCount
		);
	}

	public async Task<ProductDto> CreateAsync(CreateProductRequest createProductRequest)
	{
		var product = createProductRequest.ToEntity();
		await context.Products.AddAsync(product);
		await context.SaveChangesAsync();
		return product.ToDto();
	}

	public async Task<ProductDto> UpdateAsync(int id, UpdateProductRequest dto)
	{
		var existingProduct = await context.Products.FindAsync(id);
		if (existingProduct is null)
		{
			throw new KeyNotFoundException($"Product with id {id} not found.");
		}
		dto.UpdateEntity(existingProduct);
		await context.SaveChangesAsync();

		return existingProduct.ToDto();
	}

	public async Task DeleteAsync(int id)
	{
		var existingProduct = await context.Products.FindAsync(id);
		if (existingProduct is null)
		{
			throw new KeyNotFoundException($"Product with id {id} not found.");
		}
		context.Products.Remove(existingProduct);
		await context.SaveChangesAsync();
	}
}
