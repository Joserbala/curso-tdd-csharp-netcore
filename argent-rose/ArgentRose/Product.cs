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
}