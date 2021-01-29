# Ledger

Refactor a ledger printer.

The ledger exercise is a refactoring exercise. There is code that prints a
nicely formatted ledger, given a locale (American or Dutch) and a currency (US
dollar or euro). The code however is rather badly written, though (somewhat
surprisingly) it consistently passes the test suite.

Rewrite this code. Remember that in refactoring the trick is to make small steps
that keep the tests passing. That way you can always quickly go back to a
working version.  Version control tools like git can help here as well.

Please keep a log of what changes you've made and make a comment on the exercise
containing that log, this will help reviewers.

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

## Autoformatting the code

F# source code can be formatted with the [Fantomas](https://github.com/fsprojects/fantomas) tool.

After installing it with `dotnet tool restore`, run `dotnet fantomas .` to format code within the current directory.

## Further information

For more detailed information about the F# track, including how to get help if
you're having trouble, please visit the exercism.io [F# language page](http://exercism.io/languages/fsharp/resources).

