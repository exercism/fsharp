# Introduction

The key to this exercise is to repeatedly apply an algorithm to a number until a value (`1`) is reached.

## Approach: unfold

```fsharp
let private collatzSequence number =
    Seq.unfold (fun current ->
        if current = 1 then
            None
        elif current % 2 = 0 then
            Some (current, current / 2)
        else
            Some (current, current * 3  + 1)
        )
        number

let steps number =
    if number < 1 then None
    else collatzSequence number |> Seq.length |> Some
```

This approach uses [`Seq.unfold`][seq.unfold] to generate the collatz sequence followed by [`Seq.length`][seq.length] to calculate the number of steps.
For more information, check the [unfold approach][approach-unfold].

## Approach: sequence expression

```fsharp
let rec private collatzSequence current =
    seq {
        if current > 1 then
            yield current
            if current % 2 = 0 then
                yield! collatzSequence (current / 2)
            else
                yield! collatzSequence (current * 3 + 1)
    }

let steps number =
    if number < 1 then None
    else collatzSequence number |> Seq.length |> Some
```

This approach uses a [sequence expression][sequence-expressions] to generate the collatz sequence followed by [`Seq.length`][seq.length] to calculate the number of steps.
For more information, check the [sequence expression approach][approach-sequence-expression].

## Approach: recursion

```fsharp
let steps number =
    let rec doSteps current numberOfSteps =
        if current < 1 then None
        elif current = 1 then Some numberOfSteps
        elif current % 2 = 0 then doSteps (current / 2)  (numberOfSteps + 1)
        else doSteps (current * 3  + 1) (numberOfSteps + 1)

    doSteps number 0
```

This approach uses recursion to calculate the number of steps.
For more information, check the [recursion approach][approach-recursion].

## Which approach to use?

All three approaches are equally valid.
There is some overhead to the unfold and sequence expression approaches, as they are creating an intermediate sequence, but this overhead should be negligible.

[approach-recursion]: https://exercism.org/tracks/fsharp/exercises/collatz-conjecture/approaches/recursion
[approach-unfold]: https://exercism.org/tracks/fsharp/exercises/collatz-conjecture/approaches/unfold
[approach-sequence-expression]: https://exercism.org/tracks/fsharp/exercises/collatz-conjecture/approaches/sequence-expression
[options]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/options
[seq.unfold]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#unfold
[seq.length]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#length
[sequence-expressions]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/sequences#sequence-expressions
