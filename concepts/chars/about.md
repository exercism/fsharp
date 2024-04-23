# About

## Representation, Characters and Integers

Like other simple types (`int`s, `bool`s, etc.) the `char` has a companion or alias type, in this case, `System.Char`. 

This is in fact a `struct` with a 16 bit field, and is immutable by default.

`char` has some instance methods such as `Equals`, `ToString` and [`CompareTo`][compare-to].

`char` has the same width as a [`ushort`][uint16] but they are generally not used interchangeably as they are in some languages. `ushort` has
to be explicitly cast to a `char`. 

For what it's worth, `char`s can be subject to arithmetic operations. The result of these operations is an integer.

Obviously there is no equivalence between a `byte` at 8 bits and the 16 bit `char`.

## Usage

`char`s are generally easy to use. 

They can be defined as literals with single quotes:

```fsharp
let ch = 'A'
// => val ch: char = 'A'
```

An individual `char` can be retrieved from a string with (zero-based) indexing:

```fsharp
let str = "Exercism" 
// => val str: string = "Exercism"

str[4]
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

The `System.Char` library contains the full set of [methods][Char-methods] expected for a .NET language, such as upper/lower conversions (but see the caveats in the next section):

```fsharp
'a' |> System.Char.ToUpper
// => val it: char = 'A'

'Q' |> System.Char.ToLower
// => val it: char = 'q'
```

The .NET libraries help with extracting `char`s from strings, in this case `Seq` methods:

```fsharp
"Exercism" |> Seq.toList
// => val it: char list = ['E'; 'x'; 'e'; 'r'; 'c'; 'i'; 's'; 'm']

"Zürich" |> Seq.toArray
// => val it: char array = [|'Z'; 'ü'; 'r'; 'i'; 'c'; 'h'|]
```

There are various ways to convert a character list (or array) to a string, including these:

```fsharp
let s = ['E'; 'x'; 'e'; 'r'; 'c'; 'i'; 's'; 'm']
// => val s: char list = ['E'; 'x'; 'e'; 'r'; 'c'; 'i'; 's'; 'm']

// with a .NET method
System.String.Concat s
// => val it: string = "Exercism"

// with String.concat
String.concat "" <| List.map string s
// => val it: string = "Exercism"

// with a string constructor
new string [|for c in s -> c|]
// => val it: string = "Exercism"

// with StringBuilder
open System.Text
string (List.fold (fun (sb:StringBuilder) (c:char) -> sb.Append(c)) 
                      (new StringBuilder())
                       s)
// => val it: string = "Exercism"
```

General information on `char`s can be found here:

- [Chars documentation][chars-docs]: reference documentation for `char`.

However, `char`s have a number of rough edges as detailed below. These rough edges mostly relate to the opposition between the full unicode standard on the one side and  historic representations of text as well as performance and memory usage on the other.

## Unicode Issues

When dealing with strings, if [`System.String`][System-string] library methods are available you should seek these out and use them rather than breaking the string down into characters.

Some textual "characters" consist of more than one `char` because the unicode standard has more than 65536 code points. For instance the emojis that show up in some of the tests have 2 `char`s as they comprise [surrogate][surrogates] characters.

Additionally, there are combining sequences for instance where in some cases an accented character may consist of one `char` for the plain character and another `char` for the accent.

If you have to deal with individual characters you should try to use library methods such as [`System.Char.IsControl`][is-control], [`System.Char.IsDigit`][is-digit] rather than making naive comparisons such as checking that a character is between '0' and '9'. 

For instance, note that '٢' is the arabic digit 2. `IsDigit` will return true for the arabic version so you need to be clear say when validating what range of inputs is acceptable.

Even the `System.Char` library methods may not behave as you would expect when you are dealing with more obscure languages.

One way safely to break a string into display "characters" is to use [`StringInfo`][string-info] and methods such as [`GetNexttextElement`][get-next-text-element]. 
This might be necessary if you are dealing with globalization/localization. 

Another avenue where the scalar values of unicode characters is important (say you are rolling your own encoding system) is to use [runes][runes]. However, if you know the range of characters you deal with does not include surrogates or combining character sequences (e.g. Latin ASCII) and your input is well validated then you can avoid this. 

Again, the best position to be in is where you can use `String`'s library methods.

If you do find yourself in the unenviable position of dealing with the minutiae of unicode then [this][char-encoding-net] is a good starting point.

## Globalization

If you are working in an environment where you are dealing with multiple cultures or the culture is important in some parts of the code but not others then be aware of the overloads of [`ToUpper`][to-upper] and [`ToLower`][to-lower] which take a culture and [`ToUpperInvariant`][to-upper-invariant] and [`ToLowerInvariant`][to-lower-invariant] which will provide a consistent result irrespective of the current [culture][culture-info].

[chars-docs]: https://learn.microsoft.com/en-us/dotnet/api/system.char?view=net-8.0
[culture-info]: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo
[uint16]: https://docs.microsoft.com/en-us/dotnet/api/system.uint16
[string-info]: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.stringinfo
[runes]: https://docs.microsoft.com/en-us/dotnet/api/system.text.rune
[char-encoding-net]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/character-encoding-introduction
[surrogates]: https://docs.microsoft.com/en-us/dotnet/api/system.char.issurrogate
[is-control]: https://docs.microsoft.com/en-us/dotnet/api/system.char.iscontrol
[to-upper]: https://docs.microsoft.com/en-us/dotnet/api/system.char.toupper
[to-lower]: https://docs.microsoft.com/en-us/dotnet/api/system.char.tolower
[to-upper-invariant]: https://docs.microsoft.com/en-us/dotnet/api/system.char.toupperinvariant
[to-lower-invariant]: https://docs.microsoft.com/en-us/dotnet/api/system.char.tolowerinvariant
[is-digit]: https://docs.microsoft.com/en-us/dotnet/api/system.char.isdigit
[get-next-text-element]: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.stringinfo.getnexttextelement
[compare-to]: https://docs.microsoft.com/en-us/dotnet/api/system.char.compareto
[Char-methods]: https://learn.microsoft.com/en-us/dotnet/api/system.char?view=net-8.0#methods
[System-string]: https://learn.microsoft.com/en-us/dotnet/api/system.string?view=net-8.0
