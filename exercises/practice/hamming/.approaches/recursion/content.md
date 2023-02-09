# Recursion

```fsharp
module Hamming

let distance (strand1: string) (strand2: string): int option =
    let rec doDistance (letters1: char list) (letters2: char list) (distance: int): int option =
        match letters1, letters2 with
        | [], [] -> Some distance
        | [], _ -> None
        | _, [] -> None
        | head1 :: tail1, head2 :: tail2 when head1 <> head2 -> doDistance tail1 tail2 (distance + 1)
        | _ :: tail1, _ :: tail2 -> doDistance tail1 tail2 distance

    doDistance (Seq.toList strand1) (Seq.toList strand2) 0
```

To use (tail call) recursion to calculate the distance, we'll introduce a helper function: `doDistance`.
We define this function within the `distance` function (also known as a _nested_ function), but it could just as well have been defined outside the `distance` function.

```fsharp
let rec doDistance (letters1: char list) (letters2: char list) (distance: int): int option
```

This function takes the remaining letters for both strands as a `char list`, which means that we'll be able to pattern match on it.
Besides these two lists, we'll also take an _accumulator_ parameter: `distance`, of type `int`.
This parameter represents the current distance and is updated between the recursive function calls until we're done processing, at which point it will represent the total distance.

```exercism/note
To allow a function to recursively call itself, the `rec` modified must be added.
In other words: by default, functions cannot call themselves.
```

Within this function, we pattern match on both letter lists at the same time, using:

```fsharp
match letters1, letters2 with
```

We first check to see if both lists are empty, which means that the strands must have had the same length.
Therefore, everything is fine and we can return the distance by wrapping it in `Some`:

```fsharp
| [], [] -> Some distance
```

The next two cases check if either of the lists is empty.
As we previously checked if both lists were empty, one of the lists being empty means that the other one isn't.
This is turn implies that the strands were of different lengths, so we'll return `None`:

```fsharp
| [], _ -> None
| _, [] -> None
```

At this point, we know that both lists are not empty, so we can use pattern matching to check if the first character in both lists is unequal.
If so, we'll recursively call our function but with the tails of both lists, and the distance increment by one (as the character were unequal):

```fsharp
| head1 :: tail1, head2 :: tail2 when head1 <> head2 -> doDistance tail1 tail2 (distance + 1)
```

The final pattern is one where the lists are not empty and the first characters are both equal.
In this case, we can recursively call our function with the tails of both lists, keeping the same distance:

```fsharp
| _ :: tail1, _ :: tail2 -> doDistance tail1 tail2 distance
```

## Calling the recursive helper function

The final step is to call our recursive helper function.
We'll use [`Seq.toList`][seq.tolist] to convert the string to `char list`s, and pass in an initial distance of `0`:

```fsharp
doDistance (Seq.toList strand1) (Seq.toList strand2) 0
```

And with that, we have a working, tail recursive implementation!

```exercism/note
Tail call recursion prevents stack overflows when a recursive function is called many times.
While the exercise does not have large test cases that would cause a stack overflow, it is good practice to always use using tail recursion when implementing a recursive functions.
If you'd like to read more about tail recursion, [this MSDN article](https://blogs.msdn.microsoft.com/fsharpteam/2011/07/08/tail-calls-in-f/) goes into more detail.
Another good resource on tail recursion is [this blog post](http://blog.ploeh.dk/2015/12/22/tail-recurse/).
```

[seq.tolist]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#toList
