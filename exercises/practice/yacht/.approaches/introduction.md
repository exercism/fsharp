# Introduction

The key to this exercise is to see if a list of dice matches a specific pattern.

## General guidance

- Consider sorting the dice to simplify pattern matching
- Consider the trade-off between using a [discriminated union vs an enum type][enum-types]

## Approach: `List` module

```fsharp
let private singleScore (target: Die) (dice: Die list): int =
    dice
    |> List.filter (fun die -> die = target)
    |> List.sumBy dieScore

let private bigStraightScore (dice: Die list): int =
    match List.sort dice with
    | [Die.Two; Die.Three; Die.Four; Die.Five; Die.Six] -> 30
    | _ -> 0

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
For more information, check the [`List` module approach][approach-list-module].

## Approach: active patterns

```fsharp
let private (|SingleThrow|) (target: Die) (dice: Die list): int =
    dice
    |> List.filter (fun die -> die = target)
    |> List.length

let private (|BigStraightThrow|_|) (dice: Die list): unit option =
    match List.sort dice with
    | [Die.Two; Die.Three; Die.Four; Die.Five; Die.Six] -> Some ()
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

This approach uses [active patterns][active-patterns] to match dice to categories and then we can score them.
For more information, check the [Active Patterns approach][approach-active-patterns].

## Which approach to use?

Both approaches are equally valid.
If you'd want to work with yacht categories besides scoring them, the active patterns approach gives you some nice re-usable functionality that could be useful for other purposes too.

[approach-active-patterns]: https://exercism.org/tracks/fsharp/exercises/yacht/approaches/active-patterns
[approach-list-module]: https://exercism.org/tracks/fsharp/exercises/yacht/approaches/list-module
[list-module]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html
[enum-types]: https://fsharpforfunandprofit.com/posts/enum-types/
[active-patterns]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/active-patterns
