namespace Ecommerce.Api.Startup;

public static class ApiVersioningConfiguration
{
	public static void AddApiVersioningConfig(this IServiceCollection services)
	{
		services.AddApiVersioning(options =>
		{
			options.AssumeDefaultVersionWhenUnspecified = true;
			options.DefaultApiVersion = new ApiVersion(2, 0);
			options.ReportApiVersions = true;
			options.ApiVersionReader = new UrlSegmentApiVersionReader();
		}).AddMvc().AddApiExplorer(options =>
		{
			options.GroupNameFormat = "'v'VVV";
			options.SubstituteApiVersionInUrl = true;
		});
	}
}
