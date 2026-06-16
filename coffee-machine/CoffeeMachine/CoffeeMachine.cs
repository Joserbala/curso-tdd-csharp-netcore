namespace CoffeeMachine;

public class CoffeeMachine(IDrinkMaker drinkMaker)
{
	bool isDrinkSelected;
	string drinkType;

	public void SelectCoffee()
	{
		isDrinkSelected = true;
		drinkType = "C";
	}

	public void MakeDrink()
	{
		if (isDrinkSelected)
		{
			if (drinkType == "C")
			{
				drinkMaker.Send("C::");
			}
			else
			{
				drinkMaker.Send("T::");
			}
		}
	}

	public void SelectTea()
	{
		isDrinkSelected = true;
		drinkType = "T";
	}
}