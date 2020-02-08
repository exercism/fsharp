# Linked List

Implement a doubly linked list.

Like an array, a linked list is a simple linear data structure. Several
common data types can be implemented using linked lists, like queues,
stacks, and associative arrays.

A linked list is a collection of data elements called *nodes*. In a
*singly linked list* each node holds a value and a link to the next node.
In a *doubly linked list* each node also holds a link to the previous
node.

You will write an implementation of a doubly linked list. Implement a
Node to hold a value and pointers to the next and previous nodes. Then
implement a List which holds references to the first and last node and
offers an array-like interface for adding and removing items:

* `push` (*insert value at back*);
* `pop` (*remove value at back*);
* `shift` (*remove value at front*).
* `unshift` (*insert value at front*);

To keep your implementation simple, the tests will not cover error
conditions. Specifically: `pop` or `shift` will never be called on an
empty list.

If you want to know more about linked lists, check [Wikipedia](https://en.wikipedia.org/wiki/Linked_list).

## Hints

A [doubly linked list](https://en.wikipedia.org/wiki/Doubly_linked_list) is a mutable data structure. As F# is a functional-first language, immutability is generally preferred, but there are language features that allow the use of mutation where it is required.

* The `mutable` keyword can be placed before `let` bindings and [record](https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/records) fields, allowing you to assign new values to them.

* [Class](https://fsharpforfunandprofit.com/posts/classes) properties can be made mutable by specifying a property setter with the `set` keyword.

Mutable bindings must be re-assigned with `<-`

```fsharp
let mutable x = "initial value"
x <- "new value"
```


## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

## Autoformatting the code

F# source code can be formatted with the [Fantomas](https://github.com/fsprojects/fantomas) tool.

After installing it with `dotnet tool restore`, run `dotnet fantomas .` to format code within the current directory.

## Further information

For more detailed information about the F# track, including how to get help if
you're having trouble, please visit the exercism.io [F# language page](http://exercism.io/languages/fsharp/resources).

## Source

Classic computer science topic

