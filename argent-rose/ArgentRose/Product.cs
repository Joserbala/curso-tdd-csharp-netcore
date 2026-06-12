using System;

namespace ArgentRose;

public class Product
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

	bool Equals(Product other)
	{
		return SellIn == other.SellIn && Quality == other.Quality && Description == other.Description;
	}

	public override bool Equals(object obj)
	{
		if (obj is null) return false;
		if (ReferenceEquals(this, obj)) return true;
		return obj.GetType() == GetType() && Equals((Product)obj);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(SellIn, Quality, Description);
	}
}