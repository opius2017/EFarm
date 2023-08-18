using EFarm.Api.Model;

namespace EFarm.Api.Data;

public class Seed
{

	public static async Task Initialise(AppDbContext context)
	{
		if (context.Products.Any()) return;
		var products = new List<Product> {
		 new Product("Anti-Aging Cream", 98.99m, 48.99m, "https://food-market.cmsmasters.net/wp-content/uploads/2015/05/6-1.jpg"),
			new Product("Smoked Meat ", 98.99m, 48.99m, "https://food-market.cmsmasters.net/wp-content/uploads/2015/05/15.jpg"),
			 new( ".NET Bot Black Sweatshirt", ".NET Bot Black Sweatshirt", 19.5M, "http://catalogbaseurltobereplaced/images/products/1.png"),
			new( ".NET Black & White Mug", ".NET Black & White Mug", 8.50M, "http://catalogbaseurltobereplaced/images/products/2.png"),
			new( "Prism White T-Shirt", "Prism White T-Shirt",15m, 12, "http://catalogbaseurltobereplaced/images/products/3.png"),
			new( ".NET Foundation Sweatshirt", ".NET Foundation Sweatshirt", 12, "http://catalogbaseurltobereplaced/images/products/4.png"),
			new( "Roslyn Red Sheet", "Roslyn Red Sheet", 8.5M, "http://catalogbaseurltobereplaced/images/products/5.png"),
			new( ".NET Blue Sweatshirt", ".NET Blue Sweatshirt",29m, 12, "http://catalogbaseurltobereplaced/images/products/6.png"),
			new("Roslyn Red T-Shirt", "Roslyn Red T-Shirt", 12, "http://catalogbaseurltobereplaced/images/products/7.png"),
			new( "Kudu Purple Sweatshirt", "Kudu Purple Sweatshirt",10.7m, 8.5M, "http://catalogbaseurltobereplaced/images/products/8.png"),
			new("Cup<T> White Mug", "Cup<T> White Mug", 12, "http://catalogbaseurltobereplaced/images/products/9.png"),
			new( ".NET Foundation Sheet", ".NET Foundation Sheet", 12, "http://catalogbaseurltobereplaced/images/products/10.png"),
			new( "Cup<T> Sheet", "Cup<T> Sheet", 8.5M, "http://catalogbaseurltobereplaced/images/products/11.png"),
			new("Prism White TShirt", "Prism White TShirt", 12, "http://catalogbaseurltobereplaced/images/products/12.png")
};
		products.ForEach(p => context.Products.Add(p));
		await context.SaveChangesAsync();
	}
}
