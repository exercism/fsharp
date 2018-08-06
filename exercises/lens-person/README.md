# Lens Person

Use lenses to update nested records (specific to languages with immutable data).

Updating fields of nested records is kind of annoying in Haskell. One solution
is to use [lenses](https://wiki.haskell.org/Lens).  Implement several record
accessing functions using lenses, you may use any library you want. The test
suite also allows you to avoid lenses altogether so you can experiment with
different approaches.

## Hints
- This exercise expects you to use the [Aether](https://xyncro.tech/aether/) library, which adds *lenses* functionality to F#. With lenses, you can quite easily read or update nested structures. 

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

## Further information

For more detailed information about the F# track, including how to get help if
you're having trouble, please visit the exercism.io [F# language page](http://exercism.io/languages/fsharp/resources).

## Submitting Incomplete Solutions
It's possible to submit an incomplete solution so you can see how others have completed the exercise.
