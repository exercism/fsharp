# Introduction

The `Option` type is the F# language mechanism for dealing with values that may or may not exist.
It provides a type-safe alternative to the use of `null`, which is common in other languages for dealing with such values.
It is used in many standard F# library functions, so understanding it is essential for effective use of the standard F# library.

## Usage 

The `Option` type is a generic type (having an underlying type).  
`Option` values are either `Some value`, representing some specific value, or `None`, representing no value.

The following function demonstrates how to create an `Option` value:

```fsharp
let keepIfPositive (a: int) : int option = if a > 0 then Some a else None
```

~~~~exercism/note
`T option` is the postfix syntax equivalent for `Option<T>`; the two syntax forms can be used interchangeably.
However, according to the F# Style Guide, the postfix notation is preferred for Option types (see [F# Style Guide section on Formatting Types and Type Annotations](https://learn.microsoft.com/en-us/dotnet/fsharp/style-guide/formatting#for-types-prefer-prefix-syntax-for-generics-foot-with-some-specific-exceptions)). 
~~~~

## Reading the content of an Option value

The idiomatic way to read an `Option` value is via pattern matching, as shown in the following example:

```fsharp
// Returns "Hello, <name>!" if the name is provided; otherwise returns "Hello, you!"
let sayHello (optionalName: string option): string = 
    match optionalName with
    | Some name -> "Hello, " + name + "!"
    | None -> "Hello, you!"

sayHello (Some "Matthieu")
// --> "Hello, Matthieu!"

sayHello None
// --> "Hello, you!"
```

## Unwrapping Options with default values

`Option`s can be "unwrapped" (converted to their contained type) by providing default values with the `Option.defaultValue` function. 
This is particularly useful when you want to ensure that the value is not `None`.
For example:

```fsharp
Option.defaultValue "" (Some "F#")
// --> "F#"

Option.defaultValue 0 None
// --> 0
```
