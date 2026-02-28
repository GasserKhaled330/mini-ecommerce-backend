namespace Ecommerce.Api.Startup;

public static class SeedersConfiguration
{
	public static void AddSeeders(this IServiceCollection services)
	{
		services.AddScoped<IDataSeeder, ProductDataSeeder>();
	}
}
