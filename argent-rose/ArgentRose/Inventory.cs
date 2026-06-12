using System.Collections.Generic;

namespace ArgentRose;

public class Inventory
{
	public List<Product> Update(List<Product> products)
	{
		if (products.Count == 0)
		{
			return products;
		}

		products[0] = new Product(products[0].SellIn - 1, products[0].Quality + 1, products[0].Description);

		return products;
	}
}