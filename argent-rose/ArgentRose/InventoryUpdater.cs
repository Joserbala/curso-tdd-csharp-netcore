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
		
		var updatedProducts = new List<Product>();

		foreach (var product in products)
		{
			updatedProducts.Add(Product.Update(product));
		}

		return updatedProducts;
	}
}