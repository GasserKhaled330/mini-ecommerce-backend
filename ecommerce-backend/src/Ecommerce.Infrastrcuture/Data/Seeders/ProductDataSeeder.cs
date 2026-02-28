namespace Ecommerce.Infrastructure.Data.Seeders;

public class ProductDataSeeder(ApplicationDbContext context) : BaseDataSeeder<Product>(context)
{
	public override int Order => 1;

	public override async Task SeedAsync()
	{
		if (await HasDataAsync())
		{
			return;
		}

		await SaveDataAsync(SampleData.Products);
	}
}
