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

		if (products[0].SellIn <= 6)
		{
			products[0] = new Product(updatedSellIn, products[0].Quality + 3, products[0].Description);

			return products;
		}

		products[0] = new Product(updatedSellIn, products[0].Quality + 1, products[0].Description);

		return products;
	}
}