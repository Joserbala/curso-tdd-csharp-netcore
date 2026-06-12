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
		Product updatedProduct;
		var updatedSellIn = product.SellIn - 1;

		if (Product.HasExpired(product))
		{
			updatedProduct = Product.ExpiredProduct(updatedSellIn, product);
		}
		else if (Product.IsMoreValuable(product))
		{
			updatedProduct = Product.MoreValuableProduct(updatedSellIn, product);
		}
		else if (product.Quality + 1 >= 50)
		{
			updatedProduct = new Product(updatedSellIn, 50, product.Description);
		}
		else
		{
			updatedProduct = new Product(updatedSellIn, product.Quality + 1, product.Description);
		}
		
		products[0] = updatedProduct;

		return products;
	}
}