using System.Collections.Generic;
using NUnit.Framework;

namespace ArgentRose.Tests;

public class ArgentRoseTest
{
	[Test]
	public void Empty_Inventory_Returns_Empty_Inventory()
	{
		var inventory = new Inventory();

		var products = inventory.Update([]);

		Assert.That(products.Count, Is.EqualTo(0));
	}

	[Test]
	public void SellIn_With_Seven_Or_Higher_Updates_Quality_By_1()
	{
		var product = new Product(7, 4, "Theatre Passes");
		var inventory = new Inventory();

		var products = inventory.Update([product]);

		var updatedProduct = new Product(6, 5, "Theatre Passes");
		Assert.That(products, Is.EquivalentTo(new List<Product> { updatedProduct }));
	}
}