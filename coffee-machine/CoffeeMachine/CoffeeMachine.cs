namespace CoffeeMachine;

public class CoffeeMachine(IDrinkMaker drinkMaker)
{
	bool isDrinkSelected;

	public void SelectCoffee()
	{
		isDrinkSelected = true;
	}

	public void MakeDrink()
	{
		if (isDrinkSelected)
		{
			drinkMaker.Send("C::");
		}
	}
}