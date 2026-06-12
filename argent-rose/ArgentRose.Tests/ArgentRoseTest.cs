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

	[TestCase(6, 5, 4, 7)]
	[TestCase(5, 4, 4, 7)]
	[TestCase(5, 4, 7, 10)]
	public void SellIn_With_Six_Or_Less_Updates_Quality_By_3(int sellIn, int finalSellIn, int quality, int finalQuality)
	{
		var product = new Product(sellIn, quality, "Theatre Passes");
		
		var products = InventoryUpdater.Execute([product]);
		
		var updatedProduct = new Product(finalSellIn, finalQuality, "Theatre Passes");
		Assert.That(products, Is.EquivalentTo(new List<Product> { updatedProduct }));
	}
}