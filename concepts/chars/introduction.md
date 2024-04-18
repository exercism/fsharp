# Introduction

The F# `char` type is a 16 bit quantity to represent the smallest addressable components of text.

Multiple `char`s can comprise a string such as `"word"` or `char`s can be processed independently.

They can be defined as literals with single quotes:

```fsharp
let ch = 'A'
// => val ch: char = 'A'
```

An individual `char` can be retrieved from a string with (zero-based) indexing:

```fsharp
Exercism"[4]
// => val it: char = 'c'
```

Iterating over a string returns a `char` at each step:

```fsharp
[| for c in "F#" -> c, int c |]
// => val it: (char * int) array = [|('F', 70); ('#', 35)|]
```

As shown above, a `char` can be cast to its `int` value.
This also works (*at least some of the time*) for other scripts:

```fsharp
[| for c in "東京" -> c, int c |] // Tokyo, if Wikipedia is to be believed
// => val it: (char * int) array = [|('東', 26481); ('京', 20140)|]
```

The underlying Int16 is used when comparing characters:

```fsharp
'A' < 'D'
// => val it: bool = true
```

Also, an `int` can be cast to `char`:

```fsharp
char 77
// => val it: char = 'M'
```

The `System.Char` library contains the full set of methods expected for a .NET language, such as upper/lower conversions-:

```fsharp
'a' |> System.Char.ToUpper
// => val it: char = 'A'

'Q' |> System.Char.ToLower
// => val it: char = 'q'
```

To append a `char` to a `string`, convert it to a string first:

```fsharp
"Part" + string '1'
// => val it: string = "Part1"
```

Using a StringBuilder may be more performant:

```fsharp
let sb = new System.Text.StringBuilder()
// => val sb: System.Text.StringBuilder = 

sb.Append('F').Append('#')
// => val it: System.Text.StringBuilder = F# {Capacity = 16; Chars = ?; Length = 2; MaxCapacity = 2147483647;}

sb.ToString()
// => val it: string = "F#"
```

Converting between a `list` of `char` and a `string` is simple:

```fsharp
System.String.Concat ['E'; 'x'; 'e'; 'r'; 'c'; 'i'; 's'; 'm']
// => val it: string = "Exercism"

"Exercism" |> Seq.toList
// => val it: char list = ['E'; 'x'; 'e'; 'r'; 'c'; 'i'; 's'; 'm']
```
