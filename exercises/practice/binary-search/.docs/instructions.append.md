# Hints

For this exercise the following F# features come in handy:

- [Tail recursion](https://blogs.msdn.microsoft.com/fsharpteam/2011/07/08/tail-calls-in-f/) Prevent stack overflows with large input by using tail recursion. While there are no test cases checking explicitly for this, using tail recursion leads to a more performant solution. Another good resource on tail recursion is [this blog post](http://blog.ploeh.dk/2015/12/22/tail-recurse/).
- [Pattern matching](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/pattern-matching) is extremely powerful and helps simplify multi-branch conditional logic.
