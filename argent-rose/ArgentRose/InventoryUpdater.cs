using System.Collections.Generic;

namespace ArgentRose;

public static class InventoryUpdater
{
	public static List<Product> Execute(List<Product> products)
	{
		if (products.Count == 0)
		{
			return products;
		}

		var product = products[0];
		var updatedSellIn = product.SellIn - 1;

		if (Product.HasExpired(product))
		{
			products[0] = new Product(updatedSellIn, 0, product.Description);
			
			return products;
		}

		if (Product.IsMoreValuable(product))
		{
			products[0] = new Product(updatedSellIn, product.Quality + 3, product.Description);

			return products;
		}

		if (product.Quality + 1 >= 50)
		{
			products[0] = new Product(updatedSellIn, 50, product.Description);
			return products;
		}

		products[0] = new Product(updatedSellIn, product.Quality + 1, product.Description);

		return products;
	}
}