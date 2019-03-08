# Accumulate

Implement the `accumulate` operation, which, given a collection and an
operation to perform on each element of the collection, returns a new
collection containing the result of applying that operation to each element of
the input collection.

Given the collection of numbers:

- 1, 2, 3, 4, 5

And the operation:

- square a number (`x => x * x`)

Your code should be able to produce the collection of squares:

- 1, 4, 9, 16, 25

Check out the test suite to see the expected function signature.

## Restrictions

Keep your hands off that collect/map/fmap/whatchamacallit functionality
provided by your standard library!
Solve this one yourself using other basic tools instead.

## Hints
For this exercise the following F# feature comes in handy:
- [Tail recursion](https://blogs.msdn.microsoft.com/fsharpteam/2011/07/08/tail-calls-in-f/) Prevent stack overflows with large input by using tail recursion. While there are no test cases checking explicitly for this, using tail recursion leads to a more performant solution. Another good resource on tail recursion is [this blog post](http://blog.ploeh.dk/2015/12/22/tail-recurse/).
- [Type inference](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/generics/#implicitly-generic-constructs) The F# compiler can automatically infer types, which means you often don't have to add any types at all. For more information on how this works and its advantages, see [this page](https://fsharpforfunandprofit.com/posts/type-inference/).


## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

## Further information

For more detailed information about the F# track, including how to get help if
you're having trouble, please visit the exercism.io [F# language page](http://exercism.io/languages/fsharp/resources).

## Source

Conversation with James Edward Gray II [https://twitter.com/jeg2](https://twitter.com/jeg2)

