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

		products[0] = UpdateProduct(product, updatedSellIn);

		return products;
	}

	static Product UpdateProduct(Product product, int updatedSellIn)
	{
		Product updatedProduct;
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

		return updatedProduct;
	}
}