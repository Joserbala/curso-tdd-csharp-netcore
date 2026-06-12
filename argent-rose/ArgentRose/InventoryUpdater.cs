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

		for (var i = 0; i < products.Count; i++)
		{
			var product = products[i];

			products[i] = Product.Update(product);
		}

		return products;
	}
}