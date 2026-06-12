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

		products[0] = UpdateProduct(product);

		return products;
	}

	static Product UpdateProduct(Product product)
	{
		var updatedSellIn = product.SellIn - 1;

		if (Product.HasExpired(product))
		{
			return Product.ExpiredProduct(updatedSellIn, product);
		}

		if (Product.IsMoreValuable(product))
		{
			return Product.MoreValuableProduct(updatedSellIn, product);
		}

		if (product.Quality + 1 >= 50)
		{
			return new Product(updatedSellIn, 50, product.Description);
		}

		return new Product(updatedSellIn, product.Quality + 1, product.Description);
	}
}