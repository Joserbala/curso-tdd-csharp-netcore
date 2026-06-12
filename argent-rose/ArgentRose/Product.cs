using System;

namespace ArgentRose;

public record Product
{
	internal int SellIn { get; }
	internal int Quality { get; }
	internal string Description { get; }

	public Product(int sellIn, int quality, string description)
	{
		SellIn = sellIn;
		Quality = quality;
		Description = description;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(SellIn, Quality, Description);
	}

	internal static bool HasExpired(Product product)
	{
		return product.SellIn <= 0;
	}

	internal static bool IsMoreValuable(Product product)
	{
		return product.SellIn <= 6;
	}

	internal static Product MoreValuableProduct(int updatedSellIn, Product product)
	{
		return new Product(updatedSellIn, product.Quality + 3, product.Description);
	}

	internal static Product ExpiredProduct(int updatedSellIn, Product product)
	{
		return new Product(updatedSellIn, 0, product.Description);
	}
}