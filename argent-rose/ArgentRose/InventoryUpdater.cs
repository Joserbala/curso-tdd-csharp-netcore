using System.Collections.Generic;
using System.Linq;

namespace ArgentRose;

public static class InventoryUpdater
{
	public static List<Product> Execute(IEnumerable<Product> products)
	{
		return products.Select(Product.Update).ToList();
	}
}