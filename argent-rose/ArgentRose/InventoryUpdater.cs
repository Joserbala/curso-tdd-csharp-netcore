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

		var updatedSellIn = products[0].SellIn - 1;

		if (HasExpired(products[0]))
		{
			products[0] = new Product(updatedSellIn, 0, products[0].Description);
			
			return products;
		}

		if (IsMoreValuable(products[0]))
		{
			products[0] = new Product(updatedSellIn, products[0].Quality + 3, products[0].Description);

			return products;
		}

		if (products[0].Quality + 1 >= 50)
		{
			products[0] = new Product(updatedSellIn, 50, products[0].Description);
			return products;
		}

		products[0] = new Product(updatedSellIn, products[0].Quality + 1, products[0].Description);

		return products;
	}

	static bool HasExpired(Product product)
	{
		return product.SellIn <= 0;
	}

	static bool IsMoreValuable(Product product)
	{
		return product.SellIn <= 6;
	}
}