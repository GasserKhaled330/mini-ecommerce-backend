using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.Data;

public static class DbInitializer
{
	public static async Task InitalizeAsync(IServiceProvider serviceProvider)
	{
		using var scope = serviceProvider.CreateScope();
		var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

		var seeders = scope.ServiceProvider.GetServices<IDataSeeder>().OrderBy(s => s.Order);
		foreach (var seeder in seeders)
		{
			await seeder.SeedAsync();
		}
	}
}
