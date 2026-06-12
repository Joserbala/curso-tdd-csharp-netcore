using System.Collections.Generic;
using System.Linq;

namespace ArgentRose;

public static class InventoryUpdater
{
	public static List<Product> Execute(List<Product> products)
	{
		if (products.Count == 0)
		{
			return products;
		}

		return products.Select(Product.Update).ToList();
	}
}