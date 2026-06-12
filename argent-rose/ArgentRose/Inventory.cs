using System.Collections.Generic;
using System.Linq;

namespace ArgentRose;

public class Inventory
{
	public List<Product> Update(List<Product> products)
	{
		if (products.Count == 0)
		{
			return products;
		}

		products[0].SellIn -= 1;
		products[0].Quality += 1;

		return products;
	}
}