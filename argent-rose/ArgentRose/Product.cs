namespace ArgentRose;

public record Product(int SellIn, int Quality, string Description)
{
	const int MaximumQuality = 50;

	internal static Product Update(Product product)
	{
		var updatedSellIn = product.SellIn - 1;

		if (HasExpired(product))
		{
			return ExpiredProduct(updatedSellIn, product);
		}

		if (WouldQualityBeAtTheMaximum(product))
		{
			return MaximumQualityProduct(product, updatedSellIn);
		}

		if (IsMoreValuable(product))
		{
			return MoreValuableProduct(updatedSellIn, product);
		}

		return new Product(updatedSellIn, product.Quality + 1, product.Description);
	}

	static Product MaximumQualityProduct(Product product, int updatedSellIn)
	{
		return new Product(updatedSellIn, MaximumQuality, product.Description);
	}

	static bool WouldQualityBeAtTheMaximum(Product product)
	{
		return product.Quality + 1 >= MaximumQuality || product.Quality + 3 >= MaximumQuality;
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