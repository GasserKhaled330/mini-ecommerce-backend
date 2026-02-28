var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
		options.UseSqlServer(connectionString)
);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
	options.InvalidModelStateResponseFactory = context =>
	{
		var errorMessages = context
					.ModelState.Values.SelectMany(v => v.Errors)
					.Select(e => e.ErrorMessage)
					.ToList();
		var errorMessage = string.Join(" | ", errorMessages);

		var problemDetails = new ProblemDetails
		{
			Status = StatusCodes.Status400BadRequest,
			Title = "Validation Error",
			Detail = errorMessage,
			Instance = context.HttpContext.Request.Path,
		};
		return new BadRequestObjectResult(problemDetails);
	};
});

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddSeeders();
builder.Services.AddAppServices();
builder.Services.AddValidators();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
	await DbInitializer.InitalizeAsync(app.Services);
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
