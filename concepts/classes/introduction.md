# Introduction

Classes are the primary construct to do object-oriented programming in F#.

A class in F# is made up of its fields and methods. The fields and methods of a class are known as its _members_.

Classes in F# are defined using the `type` keyword. Methods are defined using the `member` keyword and are always public. To define (private) fields, `let` bindings can be used.

```fsharp
type Shoe() =
    let size = 8

    member this.Describe() = $"This is a size {size} shoe"
```

Classes are templates for creating objects with. To create an instance of a class, invoke the class' name as a function. An instance of a class is also known as an _object_.

One can access an object's members using dot notation.

```fsharp
let myShoe = Shoe()
myShoe.Describe()
// => "This is a size 8 shoe"
```
