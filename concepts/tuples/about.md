# About

A [tuple][tuple] is a _immutable_ grouping of unnamed but ordered values, possibly of different types. Tuples can either be reference types or structs.

`tuples` can hold any (or multiple) data type(s) -- including other `tuples`.

<br>

## Tuple Construction

Tuples can be formed in multiple ways, using either the `System.Tuple` class constructor or the `(<element_1>, <element_2>)` declaration.

### Using the `System.Tuple()` constructor:

```fsharp
let value = System.Tuple<int,int>(1, 2)
```

### Examples of tuples include pairs, triples, and so on, of the same or different types. Some examples are illustrated in the following code.:

```fsharp
(1, 2)
// Triple of strings.
("one", "two", "three")
// Tuple of generic types.
(a, b)
// Tuple that has mixed types.
("one", 1, 2.0)
// Tuple of integer expressions.
(a + 1, b + 1)
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

## Key points about tuples
Some key things to know about tuples are:

* A particular instance of a tuple type is a single object, similar to a two-element array in C#, say. When using them with functions they count as a single parameter.
* Tuple types cannot be given explicit names. The “name” of the tuple type is determined by the combination of types that are multiplied together.
* The order of the multiplication is important. So `int*string` is not the same tuple type as `string*int`.
* The comma is the critical symbol that defines tuples, not the parentheses. You can define tuples without the parentheses, although it can sometimes be confusing. In F#, if you see a comma, it is probably part of a tuple.
* Tuples have structural equality. `(1, 4, 6) = (1, 4, 6) -> true`
* Tuples can be used as arguments of function and return value of function

These points are very important – if you don’t understand them you will get confused quite quickly!
