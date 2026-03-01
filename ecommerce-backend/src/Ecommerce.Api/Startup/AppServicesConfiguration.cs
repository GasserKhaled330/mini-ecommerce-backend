namespace Ecommerce.Api.Startup;

public static class AppServicesConfiguration
{
	public static void AddAppServices(this IServiceCollection services)
	{
		services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
		services.AddScoped<IProductService, ProductService>();
		services.AddScoped<IOrderService, OrderService>();
	}
}
