namespace ArgentRose;

public record Product
{
	int SellIn { get; }
	int Quality { get; }
	string Description { get; }

	public Product(int sellIn, int quality, string description)
	{
		SellIn = sellIn;
		Quality = quality;
		Description = description;
	}

	internal static Product Update(Product product)
	{
		var updatedSellIn = product.SellIn - 1;

		if (HasExpired(product))
		{
			return ExpiredProduct(updatedSellIn, product);
		}

		if (product.Quality + 1 >= 50 || product.Quality + 3 >= 50)
		{
			return new Product(updatedSellIn, 50, product.Description);
		}

		if (IsMoreValuable(product))
		{
			return MoreValuableProduct(updatedSellIn, product);
		}

		return new Product(updatedSellIn, product.Quality + 1, product.Description);
	}

	static bool HasExpired(Product product)
	{
		return product.SellIn <= 0;
	}

	static bool IsMoreValuable(Product product)
	{
		return product.SellIn <= 6;
	}

	static Product MoreValuableProduct(int updatedSellIn, Product product)
	{
		return new Product(updatedSellIn, product.Quality + 3, product.Description);
	}

	static Product ExpiredProduct(int updatedSellIn, Product product)
	{
		return new Product(updatedSellIn, 0, product.Description);
	}
}