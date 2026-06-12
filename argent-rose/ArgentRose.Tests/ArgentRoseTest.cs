using System.Collections.Generic;
using NUnit.Framework;

namespace ArgentRose.Tests
{
	public class ArgentRoseTest
	{
		[Test]
		public void Empty_Inventory_Returns_Empty_Inventory()
		{
			var inventory = new Inventory();

			var products = inventory.Update([]);

			Assert.That(products.Count, Is.EqualTo(0));
		}
	}

	internal class Product;

	internal class Inventory
	{
		public List<Product> Update(List<Product> products)
		{
			return products;
		}
	}
}