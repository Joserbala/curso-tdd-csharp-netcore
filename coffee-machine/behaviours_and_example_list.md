# Behaviour

Translate the order from costumers to drink maker.

Customer -> Coffee Machine (us) -> Drink Maker

# Input

The type of drink and the amount of sugar.

# Output

Instructions to the drink maker, a string.

# Smaller Behaviours

1. Take the order from the customer.
    * Coffee, tea or chocolate.
2. Add zero, one, or two sugars.
3. Send the order to the drink maker.
    * Show the message to the customer.
4. When order contains sugar, instruct the maker to add a stick.

# Rules

No stick: "X::"
With stick: "X:Y:0"

# Collaborators

1. DrinkMaker: Violates Self-Validating, Indirect Output, Spy

# Examples, MakeDrink

[x] (typeOfDrink: empty, sugar: 0) -> without interaction.

[x] (typeOfDrink: coffee, sugar: 0) -> ("C::")
[x] (typeOfDrink: coffee, sugar: 1) -> ("C:1:0")
[] (typeOfDrink: coffee, sugar: 2) -> ("C:2:0")

[x] (typeOfDrink: tea, sugar: 0) -> ("T::")
[] (typeOfDrink: tea, sugar: 1) -> ("T:1:0")
[] (typeOfDrink: tea, sugar: 2) -> ("T:2:0")

[x] (typeOfDrink: chocolate, sugar: 0) -> ("H::")
[] (typeOfDrink: chocolate, sugar: 1) -> ("H:1:0")
[] (typeOfDrink: chocolate, sugar: 2) -> ("H:2:0")