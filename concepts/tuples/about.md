# About

A [tuple](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/tuples) is an _immutable_ grouping of unnamed but ordered values.
Tuples can hold any (or multiple) data type(s) -- including other tuples.

Tuples are defined as comma-separated values between `(` and `)` characters: `(<element_1>, ... , <element_n>)`.

```fsharp
("one", 2) // Tuple pair (2 values)
("one", 2, true) // Tuple triplet (3 values)
```

Only tuples with the same length and the same types (in the same order) can be compared.
Tuples have structural equality, which means they are equal _only_ if all their values are equal.

```fsharp
(1, 2) = (1, 2) // Same length, same types, same values, same order
// => true

(1, 2) = (2, 1) // Same length, same types, same values, different order
// => false

(1, 2) = (1, "2") // Same length, different types
// compiler error

(1, 2) = (1, 2, 3) // Different length
// compiler error
```

There are [three ways in which you can extract values from a tuple](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/tuples#obtaining-individual-values):

- The `fst` and `snd` functions
- Tuple deconstruction
- Pattern matching

```fsharp
let person = ("Jordan", 170)

// Option 1: fst/snd
let name1 = fst person
let length1 = snd person

// Option 2: deconstruction
let (name2, length2) = person

// Option 3: pattern matching
match person with
| name3, length3 -> printf "%s: %d" name3 length3
```

~~~~exercism/note
Technically, you can access a tuples value using its `.Item1`, `.Item2`, ... properties, but this is discouraged and results in a compiler warning.
~~~~

## Key points about tuples

Some key things to know about tuples are:

- A particular instance of a tuple type is a single object, similar to a two-element array in C#, say. When using them with functions they count as a single parameter. The only exception is when calling non F#-code with multiple parameters, in which case you pass in a tuple and its values will automatically be extracted to the corresponding parameter value.
- Tuple types cannot be given explicit names. The “name” of the tuple type is determined by the combination of types that are multiplied together.
- The comma is the critical symbol that defines tuples, not the parentheses. You can define tuples without the parentheses, although it can sometimes be confusing. In F#, if you see a comma, it is probably part of a tuple.
- Tuples can be used as arguments of function and return value of function.
