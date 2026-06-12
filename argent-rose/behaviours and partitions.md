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

Boundary between SP1 and SP2: --- 6 | 7 ---

- From SP1: on-point 7, off-point 6
- From SP2: on-point 6, off-point 7

```json5
[{sellIn: 7, quality: 4, description: 'Theatre Passes'] => [{sellIn: 6, quality: 5, description: 'Theatre Passes']
[{sellIn: 6, quality: 4, description: 'Theatre Passes'] => [{sellIn: 5, quality: 7, description: 'Theatre Passes']
```

Boundary between SP2 and SP3: --- 0 | 1 ---

- From SP2: on-point 1, off-point 0
- From SP3: on-point 0, off-point 1

```json5
[{sellIn: 1, quality: 4, description: 'Theatre Passes'] => [{sellIn: 0, quality: 7, description: 'Theatre Passes']
[{sellIn: 0, quality: 4, description: 'Theatre Passes'] => [{sellIn: -1, quality: 0, description: 'Theatre Passes']
```

## Regarding invariants, quality

In SP1:

- IP1: quality ∈ [0, 49] => quality' = quality + 1
- IP2: quality = 50 => quality' = 50

Boundary between IP1 and IP2: --- 49 | 50 ---

- From IP1: on-point 49, off-point 50
- From IP2: on-point 50, off-point 49

```json5
[{sellIn: 10, quality: 49, description: 'Theatre Passes'] => [{sellIn: 9, quality: 50, description: 'Theatre Passes']
[{sellIn: 10, quality: 50, description: 'Theatre Passes'] => [{sellIn: 9, quality: 50, description: 'Theatre Passes']
```

In SP2:

- IP3: quality ∈ [0, 47] => quality' = quality + 3
- IP4: quality ∈ [48, 50] => quality' = 50

Boundary between IP3 and IP4: --- 47 | 48 ---

- From IP1: on-point 47, off-point 48
- From IP2: on-point 48, off-point 47

```json5
[{sellIn: 4, quality: 47, description: 'Theatre Passes'] => [{sellIn: 3, quality: 50, description: 'Theatre Passes']
[{sellIn: 4, quality: 48, description: 'Theatre Passes'] => [{sellIn: 3, quality: 50, description: 'Theatre Passes']
```

In SP3:

- IP5: quality = 0 => quality' = 0

```json5
[{sellIn: 0, quality: 0, description: 'Theatre Passes'] => [{sellIn: -1, quality: 0, description: 'Theatre Passes']
```
