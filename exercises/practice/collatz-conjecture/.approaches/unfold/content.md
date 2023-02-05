# Unfold

```fsharp
let steps (number: int): int option =
    let collatzSequence (number: int): int seq =
        Seq.unfold (fun current ->
            if current = 1 then
                None
            elif current % 2 = 0 then
                Some (current, current / 2)
            else
                Some (current, current * 3  + 1)
            )
            number

    if number < 1 then None
    else collatzSequence number |> Seq.length |> Some
```

The collatz sequence is basically a while loop that updates a value and terminates when the value is equal to one.
This is a common enough pattern, that F# has a built-in function for this use case: [`Seq.unfold`][seq.unfold].

## `Seq.unfold`

The `Seq.unfold` function takes two arguments:

1. A function that takes a value and returns a value pair wrapped in an [`Option<T>`][options]
2. The initial value

The function can return either:

1. `Some (returnValue, newValue)`: continue executing, whilst adding the first value (`returnValue`) to the list of values to return, and use `newValue` as the value for the next call to the lambda
2. `None`: stop execution

Once the function returns `None`, the accumulated return values are returned.

## Unfolding the collatz sequence

Now that we know how `Seq.unfold` works, let's use it to generate our collatz sequence.

```fsharp
Seq.unfold (fun current ->
    if current = 1 then
        None
    elif current % 2 = 0 then
        Some (current, current / 2)
    else
        Some (current, current * 3  + 1)
    )
    number
```

You can see that there are three different paths the lambda takes.

### 1. Stop executing when the number is one

The very first thing we check is whether the current number is equal to one.
If so, we return `None` and execution stops.

```fsharp
if current = 1 then
    None
```

### 2. Handle an even number

We use the modulo operator to check if the number is even, and if so, we return `Some (current, current / 2)`:

```fsharp
elif current % 2 = 0 then
    Some (current, current / 2)
```

As a reminder: the first value `current` is added to the list of values to return, whereas `current / 2` will be the new value to work with.

### 3. Handle an odd number

At this point, we know the number must be odd, so we return `Some (current, current * 3 + 1)`:

```fsharp
else
    Some (current, current * 3  + 1)
```

### Step-by-step execution

Let's run through the `Seq.unfold` calls to get a better feel for it working as intended:

| Current number | Lambda return  | Return values      |
| -------------- | -------------- | ------------------ |
| 5              | `Some (5, 16)` | `[5]`              |
| 16             | `Some (16, 8)` | `[5; 16]`          |
| 8              | `Some (8, 4)`  | `[5; 16; 8]`       |
| 4              | `Some (4, 2)`  | `[5; 16; 8; 4]`    |
| 2              | `Some (2, 1)`  | `[5; 16; 8; 4; 2]` |
| 1              | None           | `[5; 16; 8; 4; 2]` |

You can see that we're slowly building up the return values, returning them once we've reached one.

## Counting the number of steps

Let's make use of our `collatzSequence` function within the `steps` function:

```fsharp
let steps (number: int): int option =
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
let steps (number: int): int option =
    let collatzSequence (number: int): int seq =
        Seq.unfold (fun current ->
            if current = 1 then
                None
            elif current % 2 = 0 then
                Some (current, current / 2)
            else
                Some (current, current * 3  + 1)
            )
            number

    if number < 1 then None
    else collatzSequence number |> Seq.length |> Some
```

## Inline collatz sequence

It is also not unreasonable to inline the `collatzSequence` function:

```fsharp
let steps (number: int): int option =
    if number < 1 then
        None
    else
        number
        |> Seq.unfold (fun n -> if n = 1 then None elif n % 2 = 0 then Some (n, n / 2) else Some (n, n * 3  + 1))
        |> Seq.length
        |> Some
```

It's a bit dense, but not unreasonably so.
You do love the expressiveness of the call to the appropriately named `collatzSequence` function.

[seq.unfold]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#unfold
[seq.length]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#length
[options]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/options
