# Recursion

```fsharp
module CollatzConjecture

let steps (number: int): int option =
    let rec doSteps (current: int) (numberOfSteps: int) =
        if current < 1 then None
        elif current = 1 then Some numberOfSteps
        elif current % 2 = 0 then doSteps (current / 2)  (numberOfSteps + 1)
        else doSteps (current * 3  + 1) (numberOfSteps + 1)

    doSteps number 0
```

To use (tail call) recursion to calculate the distance, we'll introduce a helper function: `doSteps`.
We've defined this function within the `steps` function (also known as a _nested_ function), but it could just as well have been defined outside the `steps` function.

The `doSteps` function takes the number (basically, where we're at in the collatz sequence) and the number of steps taken so far:

```fsharp
let rec doSteps (current: int) (numberOfSteps: int)
```

~~~~exercism/note
To allow a function to recursively call itself, the `rec` modified must be added.
In other words: by default, functions cannot call themselves.
~~~~

With the `doSteps` function,

With each recursive call, we'll increment
This parameter represents the current distance and is updated between the recursive function calls until we're done processing, at which point it will represent the total distance.

Our function definition looks as follows:

```fsharp
let rec doSteps (current: int) (numberOfSteps: int) =
    if current < 1 then None
    elif current = 1 then Some numberOfSteps
    elif current % 2 = 0 then doSteps (current / 2)  (numberOfSteps + 1)
    else doSteps (current * 3  + 1) (numberOfSteps + 1)
```

Within this function, we first check if the current number is less than one.
If so, the input must have been less than one and is considered invalid, so we return `None`:

```fsharp
if current < 1 then None
```

Then we check if the current number is equal to one, which is the terminating condition for the collatz sequence.
If so, we're at the end of the collatz sequence and we can return the number of steps, wrapped in `Some`:

```fsharp
elif current = 1 then Some numberOfSteps
```

Finally, we're coming to the recursive function calls, as the current number is greater than one.
There are two cases we need to handle.

1. The current number is even
2. The current number is odd

In the even case, we recursively call the `doSteps` function with the new number (`current / 2`) and the number of steps increased by one (`numberOfSteps + 1`).
For the odd case, we do the same but the new number is `current * 3 + 1`:

```fsharp
elif current % 2 = 0 then doSteps (current / 2)  (numberOfSteps + 1)
else doSteps (current * 3  + 1) (numberOfSteps + 1)
```

## Calling the recursive helper function

The final step is to call our recursive helper function:

```fsharp
doSteps number 0
```

And with that, we have a working, tail recursive implementation that correctly calculates the number of steps in a number's collatz sequence.

~~~~exercism/note
Tail recursion prevents stack overflows when a recursive function is called many times.
While the exercise does not have large test cases that would cause a stack overflow, it is good practice to always use using tail recursion when implementing a recursive functions.
If you'd like to read more about tail recursion, [this MSDN article](https://blogs.msdn.microsoft.com/fsharpteam/2011/07/08/tail-calls-in-f/) goes into more detail.
Another good resource on tail recursion is [this blog post](http://blog.ploeh.dk/2015/12/22/tail-recurse/).
~~~~

## Pattern matching

Instead of using `if/elif` expressions, you could also use pattern matching:

```fsharp
match current with
| x when x < 1 -> None
| 1 -> Some numberOfSteps
| x when x % 2 = 0 -> doSteps (current / 2)  (numberOfSteps + 1)
| _ -> doSteps (current * 3 + 1)  (numberOfSteps + 1)
```

This is functionally equivalent, but whether or not this is more readable is up for debate.
