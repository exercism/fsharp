# Introduction

The F# `char` type is a 16 bit value to represent the smallest addressable components of text, immutable by default.

`char`s can be defined as literals with single quotes:

```fsharp
let ch = 'A'
// => val ch: char = 'A'
```

Strings are a sequence of chars.

An individual `char` can be retrieved from a string with (zero-based) indexing:

```fsharp
"Exercism"[4] //  =>  'c'
```

Iterating over a string returns a `char` at each step.

The next example uses a higher order function and an anonymous function, for convenience.
These will be covered properly later in the syllabus, but for now they are essentially a concise way to write a loop over the characters in a string.

```fsharp
Seq.map (fun c -> c, int c) "F#"  //  =>  [('F', 70); ('#', 35)]
```

As shown above, a `char` can be cast to its `int` value.
This also works (*at least some of the time*) for other scripts:

```fsharp
Seq.map (fun c -> c, int c) "東京"  //  =>  [('東', 26481); ('京', 20140)]
```

The underlying Int16 is used when comparing characters:

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
