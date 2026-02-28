namespace Ecommerce.Application.Interfaces;

public interface IApplicationDbContext
{
	DbSet<Product> Products { get; }
	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
