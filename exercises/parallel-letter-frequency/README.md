# Parallel Letter Frequency

Count the frequency of letters in texts using parallel computation.

Parallelism is about doing things in parallel that can also be done
sequentially. A common example is counting the frequency of letters.
Create a function that returns the total frequency of each letter in a
list of texts and that employs parallelism.

## Hints
For this exercise the following F# feature comes in handy:
- [Asynchronous programming](https://fsharpforfunandprofit.com/posts/concurrency-async-and-parallel/) .NET has asynchronous functionality built-in which enables you to run things in parallel (assuming you have a multi-core processor which is becoming more an more common) easily

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

## Further information

For more detailed information about the F# track, including how to get help if
you're having trouble, please visit the exercism.io [F# language page](http://exercism.io/languages/fsharp/resources).

## Submitting Incomplete Solutions
It's possible to submit an incomplete solution so you can see how others have completed the exercise.
