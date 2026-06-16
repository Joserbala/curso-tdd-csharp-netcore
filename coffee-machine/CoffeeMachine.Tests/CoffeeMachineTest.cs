using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachine.Tests
{
	public class CoffeeMachineTest
	{
		IDrinkMaker drinkMaker;
		CoffeeMachine coffeeMachine;

		[SetUp]
		public void Setup()
		{
			drinkMaker = Substitute.For<IDrinkMaker>();
			coffeeMachine = new CoffeeMachine(drinkMaker);
		}

		[Test]
		public void Make_Coffee_Without_Sugar()
		{
			coffeeMachine.SelectCoffee();
			coffeeMachine.MakeDrink();

			drinkMaker.Received(1).Send("C::");
		}

		[Test]
		public void Make_Tea_Without_Sugar()
		{
			coffeeMachine.SelectTea();
			coffeeMachine.MakeDrink();

			drinkMaker.Received(1).Send("T::");
		}

		[Test]
		public void Make_Chocolate_Without_Sugar()
		{
			coffeeMachine.SelectChocolate();
			coffeeMachine.MakeDrink();

			drinkMaker.Received(1).Send("H::");
		}

		[Test]
		public void Make_Coffee_With_One_Sugar_And_Stick()
		{
			coffeeMachine.SelectCoffee();
			coffeeMachine.AddOneSpoonOfSugar();
			coffeeMachine.MakeDrink();

			drinkMaker.Received(1).Send("C:1:0");
		}

		[Test]
		public void Dont_Make_Drink()
		{
			coffeeMachine.MakeDrink();

			drinkMaker.DidNotReceiveWithAnyArgs().Send(Arg.Any<string>());
		}
	}
}