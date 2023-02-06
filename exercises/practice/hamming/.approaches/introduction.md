# Introduction

The key to this exercise is to iterate over two strings sequentially and to return an [`Option<T>` type][options] to represent success or failure.

## Approach: zip

```fsharp
let distance (strand1: string) (strand2: string): int option =
    if strand1.Length <> strand2.Length then
        None
    else
        Seq.zip strand1 strand2
        |> Seq.filter (fun (letter1, letter2) -> letter1 <> letter2)
        |> Seq.length
        |> Some
```

This approach uses the [`Seq.zip` function][seq.zip] to join the two strings and calculate the hamming distance.
For more information, check the [zip approach][approach-zip].

## Approach: recursion

```fsharp
let distance (strand1: string) (strand2: string): int option =
    let rec doDistance (letters1: char list) (letters2: char list) (distance: int): int option =
        match letters1, letters2 with
        | [], [] -> Some distance
        | [], _ -> None
        | _, [] -> None
        | hd1 :: tail1, hd2 :: tail2 when hd1 <> hd2 -> doDistance tail1 tail2 (distance + 1)
        | _ :: tail1, _ :: tail2 -> doDistance tail1 tail2 distance

    doDistance (Seq.toList strand1) (Seq.toList strand2) 0
```

This approach uses recursion to process the two strings' characters and calculate the hamming distance.
For more information, check the [recursion approach][approach-recursion].

## Which approach to use?

Both approaches are equally valid, although the recursion one is more verbose, so which one to choose is basically up to personal preference.

[approach-recursion]: https://exercism.org/tracks/fsharp/exercises/hamming/approaches/recursion
[approach-zip]: https://exercism.org/tracks/fsharp/exercises/hamming/approaches/zip
[options]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/options
[seq.zip]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#zip
