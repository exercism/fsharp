# Representer normalizations

The [F# representer][representer] applies the following normalizations:

## Remove comments

All comments are removed.

### Before

```fsharp
module Fake

(* Block comment
   on multiple lines *)

let message = "Hi" (* Block comment after code *)

// Double-slash comment on single line
let reply = "Yo" // Double-slash comment after code

/// <summary>This function adds two numbers</summary>
/// <param name="x">The first number</param>
/// <param name="y">The second number</param>
/// <returns>The first number added to the second number</param>
let add x y = x + y
```

### After

```fsharp
module Fake

let message = "Hi"

let reply = "Yo"

let add x y = x + y
```

## Remove import declarations

All import declarations are removed.

### Before

```fsharp
module Fake

open System
open System.IO

let message = "Hi"
```

### After

```fsharp
module Fake

let message = "Hi"
```

## Format code

The code is formatted using the [fantomas library][fantomas].
This formats the code according to the F# style guide.
The full list of transformations that are applied by fantomas can be found [here][fantomas-formatting].

### Before

```fsharp
module Fake

let  add ( birthDate  :  DateTime)  =
    birthDate.Add (    2.0)

type Volume =
| Liter of float
| USPint of float
| ImperialPint of float
```

### After

```fsharp
module Fake

let add (birthDate: DateTime) =
    birthDate.Add(2.0)

type Volume =
    | Liter of float
    | USPint of float
    | ImperialPint of float
```

## Normalize identifiers

Identifiers are normalized to a placeholder value.

### Before

```fsharp
module Fake

let foo x = x + 1
```

### After

```fsharp
module PLACEHOLDER_1

let PLACEHOLDER_3 PLACEHOLDER_2 = PLACEHOLDER_2 + 1
```

[representer]: https://github.com/exercism/fsharp-representer
[fantomas]: https://fsprojects.github.io/fantomas/docs/index.html
[fantomas-formatting]: https://fsprojects.github.io/fantomas/docs/end-users/Configuration.html
