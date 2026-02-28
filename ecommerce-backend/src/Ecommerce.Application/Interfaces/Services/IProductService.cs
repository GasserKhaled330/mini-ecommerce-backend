namespace Ecommerce.Application.Interfaces.Services;

public interface IProductService
{
	Task<Result<ProductDto>> GetByIdAsync(int id);
	Task<Result<PagedResponse<IReadOnlyList<ProductDto>>>> GetAllAsync(int pageNumber, int pageSize);
	Task<Result<ProductDto>> CreateAsync(CreateProductRequest createProductRequest);
	Task<Result<ProductDto>> UpdateAsync(int id, UpdateProductRequest updateProductRequest);
	Task<Result> DeleteAsync(int id);
}
