using FluentValidation;

namespace ProductAPI.API.Models
{
    public record ProductRequest(string Name, string Description, decimal Price);

	public class ProductValidator : AbstractValidator<ProductRequest>
	{
		public ProductValidator()
		{
			RuleFor(x => x.Name).NotNull().WithMessage("Name must not be null");
			RuleFor(x => x.Name).Length(3, 100).WithMessage("Name has to be between 3 and 100 characters");
			RuleFor(x => x.Description).NotNull().WithMessage("Description may be empty, but not null");
			RuleFor(x => x.Price).GreaterThan(1).WithMessage("Prices has to be greater than 1");
		}
	}
}
