# Robot Name

Manage robot factory settings.

When a robot comes off the factory floor, it has no name.

The first time you turn on a robot, a random name is generated in the format
of two uppercase letters followed by three digits, such as RX837 or BC811.

Every once in a while we need to reset a robot to its factory settings,
which means that its name gets wiped. The next time you ask, that robot will
respond with a new random name.

The names must be random: they should not follow a predictable sequence.
Using random names means a risk of collisions. Your solution must ensure that
every existing robot has a unique name.

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

## Autoformatting the code

F# source code can be formatted with the [Fantomas](https://github.com/fsprojects/fantomas) tool.

After installing it with `dotnet tool restore`, run `dotnet fantomas .` to format code within the current directory.

## Further information

For more detailed information about the F# track, including how to get help if
you're having trouble, please visit the exercism.io [F# language page](http://exercism.io/languages/fsharp/resources).

## Source

A debugging session with Paul Blackwell at gSchool. [http://gschool.it](http://gschool.it)

