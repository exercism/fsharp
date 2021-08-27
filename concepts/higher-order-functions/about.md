# About

A [higher-order function](https://docs.microsoft.com/en-us/dotnet/fsharp/introduction-to-functional-programming/first-class-functions) is a function that either:

- Takes a function as an argument
- Returns a function

A function argument is just a regular argument, albeit one that you can invoke.

```fsharp
let double = fun x -> x * 2

let apply f x = f x

apply double 3
// => 6
```
