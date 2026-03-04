namespace Ecommerce.Api.Controllers;

[ApiVersion("1.0")]
public class ProductsController(IProductService productService) : BaseApiController
{

	/// <summary>
	/// Retrieves a paginated list of products.
	/// </summary>
	[HttpGet]
	[ProducesResponseType(typeof(Result<PagedResponse<IReadOnlyList<ProductDto>>>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAll(
			[FromQuery] int pageNumber = 1,
			[FromQuery] int pageSize = 10)
	{
		// Ensure minimum values for pagination
		pageNumber = pageNumber < 1 ? 1 : pageNumber;
		pageSize = pageSize < 1 ? 10 : pageSize;

		var result = await productService.GetAllAsync(pageNumber, pageSize);
		return HandleResult(result);
	}

	/// <summary>
	/// Retrieves a specific product by its ID.
	/// </summary>
	[HttpGet("{id:int}")]
	[ProducesResponseType(typeof(Result<ProductDto>), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetById(int id)
	{
		var product = await productService.GetByIdAsync(id);
		return HandleResult(product);
	}

	/// <summary>
	/// Creates a new product.
	/// </summary>
	[HttpPost]
	[ProducesResponseType(typeof(Result<ProductDto>), StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
	{
		var createdProduct = await productService.CreateAsync(request);
		return HandleCreated(createdProduct, nameof(GetById), new { id = createdProduct.Value?.Id });
	}

	/// <summary>
	/// Updates an existing product.
	/// </summary>
	[HttpPut("{id:int}")]
	[ProducesResponseType(typeof(Result<ProductDto>), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Update(int id, [FromBody] UpdateProductRequest request)
	{
		var updatedProduct = await productService.UpdateAsync(id, request);
		return HandleResult(updatedProduct);
	}

	/// <summary>
	/// Deletes a product from the catalog.
	/// </summary>
	[HttpDelete("{id:int}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Delete(int id)
	{
		var result = await productService.DeleteAsync(id);
		return HandleResult(result);
	}
}
