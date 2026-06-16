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
			var command = drinkType + "::";

			drinkMaker.Send(command);
		}
	}

	public void SelectTea()
	{
		isDrinkSelected = true;
		drinkType = "T";
	}
}