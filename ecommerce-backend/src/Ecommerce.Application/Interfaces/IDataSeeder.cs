using System;

namespace Ecommerce.Application.Interfaces;

public interface IDataSeeder
{
	int Order { get; }
	Task SeedAsync();
}
