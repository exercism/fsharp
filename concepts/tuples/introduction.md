# Introduction

A tuple is an _immutable_ grouping of unnamed but ordered values.
Tuples can hold any (or multiple) data type(s) -- including other tuples.

Tuples support can be used when pattern matching. They can be deconstructed and constructed.

Tuples have structural equality. Tuples must be of the same length and same type in order to be equal. All value of tuple compared.
For example:

```fsharp
(1, 2) = (1, 2)
// true
(1, 2) = (2, 1)
// false
(1, 2) = (1, 2, 3)
// compiler error
(1, 2) = (1, "2")
// compiler error
```

## Tuple Construction

Tuples can be created using `(<element_1>, <element_2>)` declaration.
Tuples ca be pairs, triples, and so on, of the same or different types. Some examples are illustrated in the following code.:

```fsharp
("one", 2) // Tuple pair 
("one", 2, true) // Tuple triplet
```

## Obtaining Individual Values

Pattern matching

```fsharp
match tuple with
| (x,y) -> printfn "Pair %A %A" x y
```
Tuple deconstruction

```fsharp
let (a,b) = (12, "twelve")
// a = 12, b = "twelve"
```
Using helper functions

```fsharp
let tuple = (1, 2)
let c = fst tuple
let d = snd tuple
// c = 1, d = 2
```
