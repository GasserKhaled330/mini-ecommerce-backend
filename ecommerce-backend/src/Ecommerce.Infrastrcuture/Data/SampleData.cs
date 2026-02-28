namespace Ecommerce.Infrastructure.Data;

public static class SampleData
{
	public static List<Product> Products =>
			[
					new Product
						{
								Name = "Product 1",
								Description = "Description for Product 1",
								Price = 19.99m,
								Quantity = 5,
						},
						new Product
						{
								Name = "Product 2",
								Description = "Description for Product 2",
								Price = 29.99m,
								Quantity = 10,
						},
						new Product
						{
								Name = "Product 3",
								Description = "Description for Product 3",
								Price = 9.99m,
								Quantity = 20,
						},
						new Product
						{
								Name = "Product 4",
								Description = "Description for Product 4",
								Price = 49.99m,
								Quantity = 15,
						},
						new Product
						{
								Name = "Product 5",
								Description = "Description for Product 5",
								Price = 99.99m,
								Quantity = 0,
						},
						new Product
						{
								Name = "Product 6",
								Description = "Description for Product 6",
								Price = 39.99m,
								Quantity = 3,
						},
						new Product
						{
								Name = "Product 7",
								Description = "Description for Product 7",
								Price = 49.99m,
								Quantity = 13,
						},
						new Product
						{
								Name = "Product 8",
								Description = "Description for Product 8",
								Price = 59.99m,
								Quantity = 12,
						},
						new Product
						{
								Name = "Product 9",
								Description = "Description for Product 9",
								Price = 69.99m,
								Quantity = 10,
						},
						new Product
						{
								Name = "Product 10",
								Description = "Description for Product 10",
								Price = 79.99m,
								Quantity = 5,
						},
				];
}
