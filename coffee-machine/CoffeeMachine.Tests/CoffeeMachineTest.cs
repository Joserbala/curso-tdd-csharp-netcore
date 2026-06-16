using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachine.Tests
{
	public class CoffeeMachineTest
	{
		[Test]
		public void Make_Coffee_Without_Sugar()
		{
			var drinkMaker = Substitute.For<IDrinkMaker>();
			var coffeeMachine = new CoffeeMachine(drinkMaker);
			coffeeMachine.SelectCoffee();

			coffeeMachine.MakeDrink();

			drinkMaker.Received(1).Send("C::");
		}
	}
}