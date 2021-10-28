# Introduction

A tuple is an _immutable_ grouping of unnamed but ordered values.
Tuples can hold any (or multiple) data type(s) -- including other tuples.

Tuples support can be used when pattern matching. They can be deconstructed and constructed.

Tuples have structural equality.

## Tuple Construction

Tuples can be formed in multiple ways, using either the `System.Tuple` class constructor or the `(<element_1>, <element_2>)` declaration.
### Examples of tuples include pairs, triples, and so on, of the same or different types. Some examples are illustrated in the following code.:

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
