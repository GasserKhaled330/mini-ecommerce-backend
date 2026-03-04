namespace Ecommerce.Api.Swagger;

public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IOptionsMonitor<SwaggerAppSettings> swaggerAppSettings) : IConfigureOptions<SwaggerGenOptions>
{
	public void Configure(SwaggerGenOptions options)
	{
		foreach (var description in provider.ApiVersionDescriptions)

		{
			options.SwaggerDoc(
					description.GroupName,
					CreateInfoForApiVersion(description, swaggerAppSettings.CurrentValue)
			);
		}
	}

	private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description, SwaggerAppSettings swaggerAppSettings)
	{
		var info = new OpenApiInfo()
		{
			Title = swaggerAppSettings.Title,
			Version = description.ApiVersion.ToString(),
			Description = swaggerAppSettings.Description,
			Contact = new OpenApiContact { Name = swaggerAppSettings.ContactName, Email = swaggerAppSettings.ContactEmail }
		};

		if (description.IsDeprecated)
		{
			info.Description += "<p><font color='red'>This API version has been deprecated.</font></p>";
		}

		return info;
	}
}
