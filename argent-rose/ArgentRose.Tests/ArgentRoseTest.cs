using System.Collections.Generic;
using NUnit.Framework;

namespace ArgentRose.Tests;

public class ArgentRoseTest
{
	[Test]
	public void Empty_Inventory_Returns_Empty_Inventory()
	{
		var products = InventoryUpdater.Execute((List<Product>)[]);

		Assert.That(products.Count, Is.EqualTo(0));
	}

	[Test]
	public void SellIn_With_Seven_Or_Higher_Updates_Quality_By_1()
	{
		var product = new Product(7, 4, "Theatre Passes");

		var products = InventoryUpdater.Execute((List<Product>)[product]);

		var updatedProduct = new Product(6, 5, "Theatre Passes");
		Assert.That(products, Is.EquivalentTo(new List<Product> { updatedProduct }));
	}

	[TestCase(6, 5, 4, 7)]
	[TestCase(5, 4, 4, 7)]
	[TestCase(5, 4, 7, 10)]
	[TestCase(1, 0, 5, 8)]
	public void SellIn_Between_One_And_Six_Updates_Quality_By_3(int sellIn, int finalSellIn, int quality,
		int finalQuality)
	{
		var product = new Product(sellIn, quality, "Theatre Passes");

		var products = InventoryUpdater.Execute((List<Product>)[product]);

		var updatedProduct = new Product(finalSellIn, finalQuality, "Theatre Passes");
		Assert.That(products, Is.EquivalentTo(new List<Product> { updatedProduct }));
	}

	[Test]
	public void SellIn_With_Zero_Or_Less_Updates_Quality_To_Zero()
	{
		var product = new Product(0, 4, "Theatre Passes");

		var products = InventoryUpdater.Execute((List<Product>)[product]);

		var updatedProduct = new Product(-1, 0, "Theatre Passes");
		Assert.That(products, Is.EquivalentTo(new List<Product> { updatedProduct }));
	}

	[TestCase(10, 9, 49, 50)]
	[TestCase(10, 9, 50, 50)]
	public void SellIn_Higher_Than_Six_Updates_Quality_No_Higher_Than_Fifty(
		int sellIn, int finalSellIn, int quality, int finalQuality)
	{
		var product = new Product(sellIn, quality, "Theatre Passes");

		var products = InventoryUpdater.Execute((List<Product>)[product]);

		var updatedProduct = new Product(finalSellIn, finalQuality, "Theatre Passes");
		Assert.That(products, Is.EquivalentTo(new List<Product> { updatedProduct }));
	}

	[TestCase(4, 3, 47, 50)]
	[TestCase(4, 3, 48, 50)]
	public void SellIn_Between_One_And_Six_Updates_Quality_No_Higher_Than_Fifty(
		int sellIn, int finalSellIn, int quality, int finalQuality)
	{
		var product = new Product(sellIn, quality, "Theatre Passes");

		var products = InventoryUpdater.Execute((List<Product>)[product]);

		var updatedProduct = new Product(finalSellIn, finalQuality, "Theatre Passes");
		Assert.That(products, Is.EquivalentTo(new List<Product> { updatedProduct }));
	}

	[Test]
	public void Inventory_With_More_Than_One_Product_Updates()
	{
		var product = new Product(7, 4, "Theatre Passes");
		var anotherProduct = new Product(3, 4, "Theatre Passes");

		var products = InventoryUpdater.Execute((List<Product>)[product, anotherProduct]);

		var updatedProduct = new Product(6, 5, "Theatre Passes");
		var anotherUpdatedProduct = new Product(2, 7, "Theatre Passes");
		Assert.That(products, Is.EquivalentTo(new List<Product> { updatedProduct, anotherUpdatedProduct }));
	}
}