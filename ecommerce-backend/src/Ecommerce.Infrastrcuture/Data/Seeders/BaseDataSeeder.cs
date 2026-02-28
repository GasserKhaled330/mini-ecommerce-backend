namespace Ecommerce.Infrastructure.Data.Seeders;

public abstract class BaseDataSeeder<T>(ApplicationDbContext context) : IDataSeeder
		where T : BaseEntity
{
	public abstract int Order { get; }
	public abstract Task SeedAsync();

	protected async Task SaveDataAsync(ICollection<T> data)
	{
		await context.Set<T>().AddRangeAsync(data);
		await context.SaveChangesAsync();
	}

	protected async Task<bool> HasDataAsync() => await context.Set<T>().AnyAsync();
}
