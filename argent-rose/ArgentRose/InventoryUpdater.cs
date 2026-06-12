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

		if (products[0].SellIn <= 6)
		{
			products[0] = new Product(products[0].SellIn - 1, 7, "Theatre Passes");

			return products;
		}

		products[0] = new Product(products[0].SellIn - 1, products[0].Quality + 1, products[0].Description);

		return products;
	}
}