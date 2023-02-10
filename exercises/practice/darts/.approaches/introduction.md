# Introduction

The key to this exercise is use first calculate the distance from the center of the board, and then to check various boundary values to determine its score.

## Approach: if expressions

```fsharp
let score (x: double) (y: double): int =
    let distance = Math.Sqrt(x * x + y * y)

    if   distance <=  1.0 then 10
    elif distance <=  5.0 then  5
    elif distance <= 10.0 then  1
    else 0
```

This approach uses [`if` expressions][if-expressions] for the "distance from center" checks.
For more information, check the [`if` expressions approach][approach-if-expressions].

## Approach: pattern matching

```fsharp
let score (x: double) (y: double): int =
    match Math.Sqrt(x * x + y * y) with
    | distance when distance <=  1.0 -> 10
    | distance when distance <=  5.0 ->  5
    | distance when distance <= 10.0 ->  1
    | _ -> 0
```

This approach uses [pattern matching][pattern-matching] for the "distance from center" checks.
For more information, check the [pattern matching approach][approach-pattern-matching].

## Which approach to use?

Which to use is pretty much a matter of personal preference.

[approach-if-expressions]: https://exercism.org/tracks/fsharp/exercises/darts/approaches/if-expressions
[approach-pattern-matching]: https://exercism.org/tracks/fsharp/exercises/darts/approaches/pattern-matching
