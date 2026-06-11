# Behaviour

Update the inventory.

## Input

inventory = [products] = [{"description", sellIn, quality}]

## Output

inventory' = [products'] = [{"description", sellIn', quality'}]

# Smaller Behaviours

For Theatre Passes:

- sellIn decreases by one.
- quality changes as the sellIn diminishes:

    - Increases by 1 when there are more than 5 days to sell the product.

      quality' = quality + 1, when sellIn > 6

    - Increases by three when there are five days or less to sell the product.

      quality' = quality + 3, when sellIn <= 6 && sellIn > 0

    - Drops to 0 after the play.

      quality' = 0 when sellIn <= 0

# Invariants

- description does not change
- quality ∈ [0, 50]

# Partitions

## Regarding sellIn

- SP1: sellIn ∈ (6, inf) => quality' = quality + 1
- SP2: sellIn ∈ [1, 6] => quality' = quality + 3
- SP3: sellIn ∈ (-inf, 0] => quality' = 0

## Regarding invariants

In SP1:

- IP1: quality ∈ [0, 49] => quality' = quality + 1
- IP2: quality = 50 => quality' = 50

In SP2:

- IP3: quality ∈ [0, 47] => quality' = quality + 3
- IP4: quality ∈ [48, 50] => quality' = 50