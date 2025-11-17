# About

The `Option` type is the F# language mechanism for dealing with values that may or may not exist.
It provides a type-safe alternative to the use of `mull`, which is common in other languages for dealing with such values.
It is used in many standard F# library functions, so understanding it is essential for effective use of the standard F# library.

## Benefits of using the `Option` type

* __Compile-time safety__: By making the presence or absence of a value explicit in the type system, the compiler can ensure that you handle the "no value" case, preventing a large category of bugs that could occur with nulls.

* __Run-time safety__: Instead of using `null`, F# uses `None` to represent the absence of a value, making it impossible for a `NullReferenceException` to occur.

* __Forces explicit handling__: The type system requires code to explicitly handle both the `Some value` and `None` cases, making your code more robust and predictable.

* __Works with pattern matching__: `Option`s work seamlessly with F#'s pattern matching idiom, providing a clean and safe way to deconstruct and handle the value if it exists, or perform a different action if it doesn't.

## Usage 

The `Option` type is a generic type (having an underlying type).  
`Option` values are either `Some value`, representing some specific value, or `None`, representing no value.

The following function demonstrates how to create an `Option` value:

```fsharp
let keepIfPositive (a: int) : Option<int> = if a > 0 then Some(a) else None
```

A typical use case for an `Option` is search functions. 
For example, the `List.tryFind` function returns `Some index` when the item is in the list (where `index` is the position of the requested value in the list), or `None` when the item is not in the list.

## Reading the content of an Option value

The idiomatic way to read an `Option` value is via pattern matching, as shown in the following example:

```fsharp
// Returns "Hello, <name>!" if the name is provided; otherwise returns "Hello, you!"
let sayHello (optionalName: Option<string>): string = 
    match optionalName with
    | Some name -> "Hello, " + name + "!"
    | None -> "Hello, you!"

sayHello (Some "Matthieu")
// --> "Hello, Matthieu!"

sayHello None
// --> "Hello, you!"
```

## Unwrapping Options with default values

`Option`s can be "unwrapped" (converted to their contained type) by providing default values using the `Option.defaultValue` function. This is particularly useful when you want to ensure that the value is not `None`. 
For example:

```fsharp
Option.defaultValue "" Some "F#"
// --> "F#"

Option.defaultValue 0 None
// --> 0
```

## More functions in the `Option` module

The `Option` module also includes functions that correspond to the functions that are available for lists, arrays, sequences, and other collection types, such as `Option.map`, `Option.iter`, `Option.forall`, `Option.count`. 
These functions enable `Option`s to be treated like a collection of zero or one elements. 
