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

		products[0] = Product.Update(product);

		return products;
	}
}