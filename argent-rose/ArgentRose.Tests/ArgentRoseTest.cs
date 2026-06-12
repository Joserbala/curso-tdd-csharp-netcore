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
}