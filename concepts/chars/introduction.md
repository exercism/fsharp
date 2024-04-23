# Introduction

The F# `char` type is a 16 bit value to represent the smallest addressable components of text.

A `char` is immutable by default.

Multiple `char`s can comprise a string such as `"word"` or `char`s can be processed independently.

They can be defined as literals with single quotes:

```fsharp
let ch = 'A'
// => val ch: char = 'A'
```

An individual `char` can be retrieved from a string with (zero-based) indexing:

```fsharp
"Exercism"[4] //  =>  'c'
```

Iterating over a string returns a `char` at each step:

```fsharp
[| for c in "F#" -> c, int c |]  //  => [|('F', 70); ('#', 35)|]
```

As shown above, a `char` can be cast to its `int` value.
This also works (*at least some of the time*) for other scripts:

```fsharp
[| for c in "東京" -> c, int c |] //  =>  [|('東', 26481); ('京', 20140)|]
```

The underlying `Int16` type is used when comparing characters:


```fsharp
'A' < 'D'  // =>  true
```

Also, an `int` can be cast to `char`:

```fsharp
char 77  // => 'M'
```

The `System.Char` library contains the full set of methods expected for a .NET language, such as upper/lower conversions:

```fsharp
'a' |> System.Char.ToUpper  // =>  'A'

'Q' |> System.Char.ToLower  // =>  'q'
```
