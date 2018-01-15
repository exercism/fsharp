## Hints

A [doubly linked list](https://en.wikipedia.org/wiki/Doubly_linked_list) is a mutable data structure. As F# is a functional-first language, immutability is generally preferred, but there are language features that allow the use of mutation where it is required.

* The `mutable` keyword can be placed before `let` bindings and [record](https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/records) fields, allowing you to assign new values to them.

* [Class](https://fsharpforfunandprofit.com/posts/classes) properties can be made mutable by specifying a property setter with the `set` keyword.

Mutable bindings must be re-assigned with `<-`

```fsharp
let mutable x = "initial value"
x <- "new value"
```
