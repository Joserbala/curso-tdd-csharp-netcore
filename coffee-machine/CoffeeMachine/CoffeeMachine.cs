namespace CoffeeMachine;

public class CoffeeMachine(IDrinkMaker drinkMaker, int spoonsOfSugar = 0)
{
	bool isDrinkSelected;
	string drinkType;
	int spoonsOfSugar = spoonsOfSugar;

	public void SelectCoffee()
	{
		isDrinkSelected = true;
		drinkType = "C";
	}

	public void SelectTea()
	{
		isDrinkSelected = true;
		drinkType = "T";
	}

	public void SelectChocolate()
	{
		isDrinkSelected = true;
		drinkType = "H";
	}

	public void MakeDrink()
	{
		if (isDrinkSelected)
		{
			var sugarPart = "::";

			if (spoonsOfSugar > 0)
			{
				sugarPart = ":" + spoonsOfSugar + ":0";
			}

			var command = drinkType + sugarPart;

			drinkMaker.Send(command);
		}
	}

	public void AddOneSpoonOfSugar()
	{
		spoonsOfSugar++;
	}
}