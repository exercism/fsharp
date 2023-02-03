# Sequence expression

```fsharp
module CollatzConjecture

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

The collatz sequence can be generated using recursion, where the current number changes between calls.
One way to generate sequence of numbers in a number's collatz sequence is to use a [sequence expression][sequence-expressions].
Let's see how that works!

## Sequence expressions

With sequence expressions, one can generate sequences using very declarative code.
You start with the `seq` keyword and its logic is written between curly braces.
This (admittedly rather silly) sequence expression will return the first primes:

```fsharp
let firstPrimes () =
    seq {
        yield 2
        yield 3
        yield 5
    }
```

This will return a sequence contains `2`, `3` and `5` (in that order).

### Yielding multiple values

Whilst `yield` only ever returns one value, you can also return a _sequence_ of values via `yield!`

```fsharp
let firstPrimes () =
    seq {
        yield 2
        yield! [3; 5]
    }
```

This will, once again, return a sequence contains `2`, `3` and `5` (in that order).

### Using conditionals

You can also use `if` expressions within sequence expressions:

```fsharp
let greaterThanTen n =
    seq {
        if n > 10
            yield n
    }
```

Note that you don't _have_ to specific an `else` branch.

### Recursive sequence expressions

Sequence expressions can also be recursive, meaning they can call themselves.
Here is an function that generates an (infinite) sequence of all even numbers:

```fsharp
let rec evenNumbers current =
    seq {
        yield current
        yield! evenNumbers (current + 2)
    }
```

## Generating the collatz sequence

Now that we know how sequence expressions work, let's use them to generate our collatz sequence:

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
```

This function takes the current number as its sole parameter and is marked with `rec` to allow it to call itself.

```exercism/note
To allow a function to recursively call itself, the `rec` modified must be added.
In other words: by default, functions cannot call themselves.
```

The body of the function has code wrapped in `seq {}`, which indicates to the compiler that we're generate a sequence.

### 1. Stop executing when the number is one

With the sequence expression, we start by checking if the current number of greater than one.
Only when it is do we yield the current number:

```fsharp
if current > 1 then
    yield current
```

This has the effect that we stop generating the sequence when the number if less than or equal to one, which is exactly what we want.

### 2. Handle an even number

We then use the modulo operator to check if the number is even.
If it is, we yield the rest of the collatz sequence by recursively calling the `collatzSequence` with the new value being `(current / 2)`:

```fsharp
if current % 2 = 0 then
    yield! collatzSequence (current / 2)
```

Note: as `collatzSequence` returns a sequence, we have to use `yield!`

### 3. Handle an odd number

At this point, we know the number must be odd, so we recursively yield the rest of the sequence using the rule for odd numbers:

```fsharp
else
    yield! collatzSequence (current * 3 + 1)
```

## Counting the number of steps

Let's make use of our `collatzSequence` function within the `steps` function:

```fsharp
let steps number =
    if number < 1 then None
    else collatzSequence number |> Seq.length |> Some
```

We first check if the current number is less than one.
If so, the input must have been less than one and is considered invalid, so we return `None`:

```fsharp
if current < 1 then None
```

Otherwise, we can use `collatzSequence number` to return all the numbers in the collatz sequence up to (but not including) the number one.
We then count the steps using [`Seq.length`][seq.length] and wrap it in a `Some` value:

```fsharp
else collatzSequence number |> Seq.length |> Some
```

And that's it, we've correctly calculated the number of steps in a number's collatz sequence!

## Using a nested function

It's also possible to make the `collatzSequence` function a nested function of the `steps` function.
This is not unreasonable, as there is little going on in the `steps` function.

```fsharp
let steps number =
    let collatzSequence current =
        seq {
            if current > 1 then
                yield current
                if current % 2 = 0 then
                    yield! collatzSequence (current / 2)
                else
                    yield! collatzSequence (current * 3 + 1)
        }

    if number < 1 then None
    else collatzSequence number |> Seq.length |> Some
```

[options]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/options
[seq.length]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#length
[sequence-expressions]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/sequences#sequence-expressions
