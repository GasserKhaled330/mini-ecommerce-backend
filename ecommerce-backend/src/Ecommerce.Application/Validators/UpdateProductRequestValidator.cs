namespace Ecommerce.Application.Validators;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
	public UpdateProductRequestValidator()
	{
		RuleFor(x => x.Name)
				.MaximumLength(100)
				.WithMessage("Product name cannot exceed 100 characters.");
		RuleFor(x => x.Description)
				.MaximumLength(500)
				.WithMessage("Product description cannot exceed 500 characters.");
		RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
		RuleFor(x => x.Quantity)
				.GreaterThanOrEqualTo(0)
				.WithMessage("Stock quantity cannot be negative.");
	}
}
