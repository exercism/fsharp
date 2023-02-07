# `List` module

```fsharp
module Yacht

type Category =
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | FullHouse
    | FourOfAKind
    | LittleStraight
    | BigStraight
    | Choice
    | Yacht

type Die =
    | One
    | Two
    | Three
    | Four
    | Five
    | Six

let private dieScore (die: Die): int =
    match die with
    | One   -> 1
    | Two   -> 2
    | Three -> 3
    | Four  -> 4
    | Five  -> 5
    | Six   -> 6

let private singleScore (target: Die) (dice: Die list): int =
    dice
    |> List.filter (fun die -> die = target)
    |> List.sumBy dieScore

let private fullHouseScore (dice: Die list): int =
    match List.countBy id dice |> List.sortBy snd with
    | [(_, 2); (_, 3)] -> List.sumBy dieScore dice
    | _ -> 0

let private fourOfAKindScore (dice: Die list): int =
    match List.countBy id dice |> List.sortBy snd with
    | [(number, 5)] | [_; (number, 4)] -> dieScore number * 4
    | _ -> 0

let private littleStraightScore (dice: Die list): int =
    match List.sort dice with
    | [Die.One; Die.Two; Die.Three; Die.Four; Die.Five] -> 30
    | _ -> 0

let private bigStraightScore (dice: Die list): int =
    match List.sort dice with
    | [Die.Two; Die.Three; Die.Four; Die.Five; Die.Six] -> 30
    | _ -> 0

let private yachtScore (dice: Die list): int =
    match List.distinct dice with
    | [_] -> 50
    | _ -> 0

let private choiceScore (dice: Die list): int = List.sumBy dieScore dice

let score (category: Category) (dice: Die list): int =
    match category with
    | Ones           -> singleScore Die.One dice
    | Twos           -> singleScore Die.Two dice
    | Threes         -> singleScore Die.Three dice
    | Fours          -> singleScore Die.Four dice
    | Fives          -> singleScore Die.Five dice
    | Sixes          -> singleScore Die.Six dice
    | FullHouse      -> fullHouseScore dice
    | FourOfAKind    -> fourOfAKindScore dice
    | LittleStraight -> littleStraightScore dice
    | BigStraight    -> bigStraightScore dice
    | Yacht          -> yachtScore dice
    | Choice         -> choiceScore dice
```

This approach combines a number of functions from the [`List` module][list-module] with some pattern matching to score the dice.

## Scoring dice

A `Die` is defined by a discriminated union.
We need some way to convert its individual values to scores (e.g. `Three` should equal `3`).
One way to do this is by converting the discriminated union to an enum type:

```fsharp
type Die =
    | One   = 1
    | Two   = 2
    | Three = 3
    | Four  = 4
    | Five  = 5
    | Six   = 6
```

While this may look appealing, it is actually not recommend. As explained in this
[discriminated union vs enum types article][enum-types], it is possible to construct an enum value that doesn't match any of the predefined values.
For that reason, we'll stick with the discriminated union.

We'll support converting dice to scores via a function that uses some basic pattern matching:

```fsharp
let private dieScore (die: Die): int =
    match die with
    | One   -> 1
    | Two   -> 2
    | Three -> 3
    | Four  -> 4
    | Five  -> 5
    | Six   -> 6
```

````exercism/note
Another option would have been to add a member to the discriminated union:

```fsharp
type Die =
    | One
    | Two
    | Three
    | Four
    | Five
    | Six

    member this.Score: int =
        match this with
        | One -> 1
        | Two -> 2
        | Three -> 3
        | Four -> 4
        | Five -> 5
        | Six -> 6
```

We've chosen not to do this, as members are more awkward to use in higher-order functions, which we rely on a lot in this approach.
````

## Scoring categories

In our approach, we'll have a separate function for each type of throw.
These functions will then later on be called in the `score` function, but first, let's go through the scoring functions one by one.

### Single score

To score a single dice, we need to:

1. Find the dice that match the target die
2. Sum the matching dice

We do this by first using [`List.filter`][list.filter] to filter the dice matching the target die.
Then, we sum those dice via [`List.sumBy`][list.sumby], passing the `dieScore` function to convert the `Die` values to `int` values (allowing them to be "summed"):

```fsharp
let private singleScore (target: Die) (dice: Die list): int =
    dice
    |> List.filter (fun die -> die = target)
    |> List.sumBy dieScore
```

### Full house score

```fsharp
let private fullHouseScore (dice: Die list): int =
    match List.countBy id dice with
    | [(_, 2); (_, 3)] | [(_, 3); (_, 2)] -> List.sumBy dieScore dice
    | _ -> 0
```

A four of a kind score contains one dice at least four times.
We can use [`List.countBy`][list.countby] to return a list of pairs where the first value is the unique value and the second value is the number times it occurred in the list.

Then we pattern match the result of the `List.countBy` call with the two possible full house patterns:

1. The dice contain two numbers, and the first number occurs twice and the second number thrice times: `[(_, 2); (_, 3)]`
2. The dice contain two numbers, and the first number occurs thrice and the second number twice times: `[(_, 3); (_, 2)]`

```fsharp
let private fullHouseScore (dice: Die list): int =
    match List.countBy id dice with
    | [(_, 2); (_, 3)] | [(_, 3); (_, 2)] -> List.sumBy dieScore dice
    | _ -> 0
```

We can simplify things a bit by sorting the results, ordering by the second value (the count) using [`List.sortBy`][list.sortby] and [`snd`][snd] (which selects the second value).
This allows us to merge the second and third pattern:

```fsharp
let private fullHouseScore (dice: Die list): int =
    match List.countBy id dice |> List.sortBy snd with
    | [(_, 2); (_, 3)] -> List.sumBy dieScore dice
    | _ -> 0
```

### Four of a kind score

A four of a kind score contains one dice at least four times.
We can use [`List.countBy`][list.countby] to return a list of pairs where the first value is the unique value and the second value is the number times it occurred in the list.

Then we pattern match the result of the `List.countBy` call with the three possible four of a kind patterns:

1. The dice contain just one number and it occurs five times: `[(number, 5)]`
2. The dice contain two numbers, and the first number occurs four times: `[(number, 4); _]`
3. The dice contain two numbers, and the second number occurs four times: `[_; (number, 4)`

```fsharp
let private fourOfAKindScore (dice: Die list): int =
    match List.countBy id dice with
    | [(number, 5)] | [(number, 4); _] | [_; (number, 4)] -> dieScore number * 4
    | _ -> 0
```

Once again, we can simplify things a bit by sorting the results, ordering by the second value (the count) using [`List.sortBy`][list.sortby] and [`snd`][snd] (which selects the second value).
This allows us to merge the second and third pattern:

```fsharp
let private fourOfAKindScore (dice: Die list): int =
    match List.countBy id dice |> List.sortBy snd with
    | [(number, 5)] | [_; (number, 4)] -> dieScore number * 4
    | _ -> 0
```

### Little straight score

A little straight contains the dice with face values 1, 2, 3, 4 and 5.
This can be directly translated into pattern matching:

```fsharp
let private littleStraightScore (dice: Die list): int =
    match List.sort dice with
    | [Die.One; Die.Two; Die.Three; Die.Four; Die.Five] -> 30
    | _ -> 0
```

Note that we do need to call [`List.sort`][list.sort] first, as the dice aren't necessarily in order and pattern matching is sensitive to the ordering.

### Big straight score

A big straight contains the dice with face values 2, 3, 4, 5 and 6.
This can be directly translated into pattern matching:

```fsharp
let private bigStraightScore (dice: Die list): int =
    match List.sort dice with
    | [Die.Two; Die.Three; Die.Four; Die.Five; Die.Six] -> 30
    | _ -> 0
```

Once again, we need [`List.sort`][list.sort] to fix the ordering.

### Yacht score

For the yacht category, we need to determine if all dice have the same face.
We can check this by using [`List.distinct`][list.distinct] to first remove any duplicates, and then use pattern matching to check if there is only one unique die:

```fsharp
let private yachtScore (dice: Die list): int =
    match List.distinct dice with
    | [_] -> 50
    | _ -> 0
```

````exercism/note
Alternatively, we could have counted the number of unique dice and checked if that was equal to one in an `if` expression:

```fsharp
let private yachtScore (dice: Die list): int =
    if List.distinct dice |> List.length = 1 then 50 else 0
```
````

### Choice score

Scoring the choice category is simple: we just need to sum all the dice.
We can do this by once again using [`List.sumBy`][list.sumby] and the `dieScore` function (but this time we don't apply any filtering):

```fsharp
let private choiceScore (dice: Die list): int = List.sumBy dieScore dice
```

## Putting it all together

Let's put good use of these category scoring functions in our `score` function.
This function takes two parameters (the category to score for and a list of dice) and returns the score as an `int`:

```fsharp
let score (category: Category) (dice: Die list): int
```

Within this function, we'll pattern match on the `category` parameter and call the appropriate category scoring function:

```fsharp
match category with
| Ones           -> singleScore Die.One dice
| Twos           -> singleScore Die.Two dice
| Threes         -> singleScore Die.Three dice
| Fours          -> singleScore Die.Four dice
| Fives          -> singleScore Die.Five dice
| Sixes          -> singleScore Die.Six dice
| FullHouse      -> fullHouseScore dice
| FourOfAKind    -> fourOfAKindScore dice
| LittleStraight -> littleStraightScore dice
| BigStraight    -> bigStraightScore dice
| Yacht          -> yachtScore dice
| Choice         -> choiceScore dice
```

Nothing interesting really, except for the fact that the categories for individual dice (`Ones` .. `Sixes`) take an additional parameter: the dice to score for.

And that's it!
Our implementation now passes all the tests.

[enum-types]: https://fsharpforfunandprofit.com/posts/enum-types/
[list-module]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html
[list.distinct]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#distinct
[list.filter]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#filter
[list.sumby]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#sumBy
[list.sort]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#sort
[list.countby]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#countBy
[list.sortby]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#sortBy
[id]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#id
[snd]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#snd
