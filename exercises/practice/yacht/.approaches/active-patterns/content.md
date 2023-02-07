# Active patterns

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

let private (|SingleThrow|) (target: Die) (dice: Die list): int =
    dice
    |> List.filter (fun die -> die = target)
    |> List.length

let private (|FullHouseThrow|_|) (dice: Die list): unit option =
    match List.countBy id dice |> List.sort with
    | [(_, 2); (_, 3)] | [(_, 3); (_, 2)] -> Some ()
    | _ -> None

let private (|FourOfAKindThrow|_|) (dice: Die list): Die option =
    match List.countBy id dice with
    | [(number, 5)] | [_; (number, 4)] | [(number, 4); _] -> Some number
    | _ -> None

let private (|LittleStraightThrow|_|) (dice: Die list): unit option =
    match List.sort dice with
    | [Die.One; Die.Two; Die.Three; Die.Four; Die.Five] -> Some ()
    | _ -> None

let private (|BigStraightThrow|_|) (dice: Die list): unit option =
    match List.sort dice with
    | [Die.Two; Die.Three; Die.Four; Die.Five; Die.Six] -> Some ()
    | _ -> None

let private (|YachtThrow|_|) (dice: Die list): unit option =
    match List.distinct dice with
    | [_] -> Some ()
    | _ -> None

let score (category: Category) (dice: Die list): int =
    match category, dice with
    | Ones,           SingleThrow Die.One count   -> count * 1
    | Twos,           SingleThrow Die.Two count   -> count * 2
    | Threes,         SingleThrow Die.Three count -> count * 3
    | Fours,          SingleThrow Die.Four count  -> count * 4
    | Fives,          SingleThrow Die.Five count  -> count * 5
    | Sixes,          SingleThrow Die.Six count   -> count * 6
    | FullHouse,      FullHouseThrow              -> List.sumBy dieScore dice
    | FourOfAKind,    FourOfAKindThrow die        -> dieScore die * 4
    | LittleStraight, LittleStraightThrow         -> 30
    | BigStraight,    BigStraightThrow            -> 30
    | Yacht,          YachtThrow                  -> 50
    | Choice,         _                           -> List.sumBy dieScore dice
    | _,              _                           -> 0
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

## Active patterns

[Active patterns][active-patterns] are used in pattern matching and can be used to categorize input and/or extract data from input.

There are two types of active patterns:

- Regular active patterns: these patterns will match any input
- Partial active patterns: these pattern will match some inputs, but not all

## Scoring categories

In this approach, we'll define active patterns for the different categories.
The idea is that if we're try to match category named `A`, then we have a corresponding active pattern named `AThrow` that will check if the dice match the category.

We'll use a combination of regular and partial active patterns.

Note that the active patterns do _not_ calculate scores, they're just there to help match input data.
This better separates responsiblities and opens up the active patterns for usage elsewhere.

These functions will then later on be called in the `score` function, like this:

```fsharp
let score (category: Category) (dice: Die list): int =
    match category, dice with
    | Yacht, YachtThrow -> 50
```

You can see that we're using regular pattern matching on the `category` parameter, which is a discriminated union.
However, we're _also_ pattern matching on the `dice` using a custom `YachtThrow` (active) pattern.
Let's start defining these active patterns!

### Single score

To score a single die, we need to:

1. Find the number of dice that match the target die
2. Multiply the number of matching dice with the die value

With the above steps, the output is also correct when the target die could not be found (zero times any dice value is zero).
Therefore, our active pattern can be a regular, non-partial active pattern as it will always match the input.

#### Score ones

Let's start by scoring the one dice (`Die.One`).
Our active pattern will take the thing we're matching on (the dice) as its sole parameter and return an `int` representing the number of one dice found:

```fsharp
let private (|OnesThrow|) (dice: Die list): int =
    dice
    |> List.filter (fun die -> die = Die.One)
    |> List.length
```

```exercism/note
Regular Active patterns functions have their name specified between `(|` and `|)`.
It is this name that will be used when using the active pattern in pattern matching, so choose carefully.
```

The implementation is fairly straightword.
We first filter the dice matching the one dice by using [`List.filter`][list.filter].
Then, we count those dice via [`List.length`][list.length], which is subsequently returned.

A different way to read this is: to use the `OnesThrow` active pattern, one has to pass it a list of dice and you'll get back their count.

We can now use this pattern in our `score` function:

```fsharp
match category, dice with
| Ones, OnesThrow count -> count
```

This is saying: if the category is `Ones` and the dice match the `OnesThrow` pattern (which they will always do), use the count returned by the `OnesThrow` pattern as the score (no multiplication needed as `count * 1` is equal to `count`).

We could continue defining similar patterns for the other five dice, but we can do something much nicer: parameterizing our active pattern.

##### Converting to a parameterized active pattern

Active patterns, like regular functions, can have parameters besides the value that is being matched on.
The only constraint is that the value to match on must be the last parameter.

To make our `OnesThrow` active pattern more generic, let's rename it to `SingleThrow` (as in: single dice throw) and add a parameter which is the target die:

```fsharp
let private (|SingleThrow|) (target: Die) (dice: Die list): int =
    dice
    |> List.filter (fun die -> die = target)
    |> List.length
```

The only thing we then need to change is to replace `Die.One` with our `target` parameter in the `List.filter` call's lambda.

We can do use this pattern to score the six single dice categories:

```fsharp
match category, dice with
| Ones,    SingleThrow Die.One count   -> count * 1
| Twos,    SingleThrow Die.Two count   -> count * 2
| Threes,  SingleThrow Die.Three count -> count * 3
| Fours,   SingleThrow Die.Four count  -> count * 4
| Fives,   SingleThrow Die.Five count  -> count * 5
| Sixes,   SingleThrow Die.Six count   -> count * 6
```

### Full house score

```fsharp
let private (|FullHouseThrow|_|) (dice: Die list): unit option =
    match List.countBy id dice |> List.sort with
    | [(_, 2); (_, 3)] | [(_, 3); (_, 2)] -> Some ()
    | _ -> None
```

### Four of a kind score

```fsharp
let private (|FourOfAKindThrow|_|) (dice: Die list): Die option =
    match List.countBy id dice with
    | [(number, 5)] | [_; (number, 4)] | [(number, 4); _] -> Some number
    | _ -> None
```

### Little straight score

A little straight contains the dice with face values 1, 2, 3, 4 and 5.
This can be directly translated into pattern matching:

```fsharp
let private (|LittleStraightThrow|_|) (dice: Die list): unit option =
    match List.sort dice with
    | [Die.One; Die.Two; Die.Three; Die.Four; Die.Five] -> Some ()
    | _ -> None
```

Note that we do need to call [`List.sort`][list.sort] first, as the dice aren't necessarily in order and pattern matching is sensitive to the ordering.

### Big straight score

A big straight contains the dice with face values 2, 3, 4, 5 and 6.
This can be directly translated into pattern matching:

```fsharp
let private (|BigStraightThrow|_|) (dice: Die list): unit option =
    match List.sort dice with
    | [Die.Two; Die.Three; Die.Four; Die.Five; Die.Six] -> Some ()
    | _ -> None
```

Once again, we need [`List.sort`][list.sort] to fix the ordering.

### Yacht score

For the yacht category, we need to determine if all dice have the same face.
We can check this by using [`List.distinct`][list.distinct] to first remove any duplicates, and then use pattern matching to check if there is only one unique die:

```fsharp
let private (|YachtThrow|_|) (dice: Die list): unit option =
    match List.distinct dice with
    | [_] -> Some ()
    | _ -> None
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
We therefore don't need to define an active pattern and can just add the following to the `score` function's pattern matching:

```fsharp
| Choice, _ -> List.sumBy dieScore dice
```

```exercism/note
We're matching the dice using the wildcard pattern (`_`), which will match any input.
```

## Handling non-matching dice

So far, we've secretly ignored something quite important: what to do if the dice _don't_ match a category's active pattern!

The solution for this is simple though.
As dice that don't match the pattern should be scored as zero, we can just add two wildcards at the end of our `score` function and return zero:

```fsharp
| _, _ -> 0
```

## Putting it all together

Now that we support all categories and handle non-matching dice, let's see what the `score` function looks like:

```fsharp
let score (category: Category) (dice: Die list): int =
    match category, dice with
    | Ones,           SingleThrow Die.One count   -> count * 1
    | Twos,           SingleThrow Die.Two count   -> count * 2
    | Threes,         SingleThrow Die.Three count -> count * 3
    | Fours,          SingleThrow Die.Four count  -> count * 4
    | Fives,          SingleThrow Die.Five count  -> count * 5
    | Sixes,          SingleThrow Die.Six count   -> count * 6
    | FullHouse,      FullHouseThrow              -> List.sumBy dieScore dice
    | FourOfAKind,    FourOfAKindThrow die        -> dieScore die * 4
    | LittleStraight, LittleStraightThrow         -> 30
    | BigStraight,    BigStraightThrow            -> 30
    | Yacht,          YachtThrow                  -> 50
    | Choice,         _                           -> List.sumBy dieScore dice
    | _,              _                           -> 0
```

Quite nice!

[enum-types]: https://fsharpforfunandprofit.com/posts/enum-types/
[list-module]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html
[list.distinct]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#distinct
[list.filter]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#filter
[list.length]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#length
[list.sumby]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#sumBy
[list.sort]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#sort
[list.countby]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#countBy
[active-patterns]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/active-patterns
