namespace Ecommerce.Application.Interfaces.Services;

public interface IProductService
{
	Task<ProductDto?> GetByIdAsync(int id);
	Task<PagedResponse<IReadOnlyList<ProductDto>>> GetAllAsync(int pageNumber, int pageSize);
	Task<ProductDto> CreateAsync(CreateProductRequest createProductRequest);
	Task<ProductDto> UpdateAsync(int id, UpdateProductRequest updateProductRequest);
	Task DeleteAsync(int id);
}
