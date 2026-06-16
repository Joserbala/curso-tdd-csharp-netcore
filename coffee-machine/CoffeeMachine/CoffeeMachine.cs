namespace CoffeeMachine;

public class CoffeeMachine(IDrinkMaker drinkMaker)
{
	public void SelectCoffee()
	{ }

	public void MakeDrink()
	{
		drinkMaker.Send("C::");
	}
}