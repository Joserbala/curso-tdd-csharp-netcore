using System.Collections.Generic;
using NUnit.Framework;

namespace ArgentRose.Tests;

public class ArgentRoseTest
{
	[Test]
	public void Empty_Inventory_Returns_Empty_Inventory()
	{
		var products = InventoryUpdater.Execute([]);

		Assert.That(products.Count, Is.EqualTo(0));
	}

	[Test]
	public void SellIn_With_Seven_Or_Higher_Updates_Quality_By_1()
	{
		var product = new Product(7, 4, "Theatre Passes");

		var products = InventoryUpdater.Execute([product]);

		var updatedProduct = new Product(6, 5, "Theatre Passes");
		Assert.That(products, Is.EquivalentTo(new List<Product> { updatedProduct }));
	}

	[Test]
	public void SellIn_With_Six_Or_Less_Updates_Quality_By_3()
	{
		var product = new Product(6, 4, "Theatre Passes");
		
		var products = InventoryUpdater.Execute([product]);
		
		var updatedProduct = new Product(5, 7, "Theatre Passes");
		Assert.That(products, Is.EquivalentTo(new List<Product> { updatedProduct }));
	}
}