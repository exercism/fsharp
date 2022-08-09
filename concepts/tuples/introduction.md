# Introduction

A tuple is an _immutable_ grouping of unnamed but ordered values.
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

There are three ways in which you can extract values from a tuple:

- The `fst` and `snd` functions
- Tuple deconstruction
- Pattern matching

```fsharp
let person = ("Jordan", 170)

// Option 1: fst/snd
let name1 = fst person
let length2 = snd person

// Option 2: deconstruction
let (name2, length2) = person
// => name2 = "Jordan"
// => length2 = 170

// Option 3: pattern matching
match person with
| name3, length3 -> printf "%s: %d" name3 length3
```
