# Tree Building

This exercise is different from most others in that you already start with
working code, which needs to be refactored. The existing code is fairly slow and
very unidiomatic, which means it's not written in a way that F# would typically
be used in.

In addition to unit tests, this exercise also provides a set of benchmark tests.
Benchmark tests have a similar purpose to unit tests - they check properties of some
other code. While unit tests check the correctness of the result, benchmarks
evaluate the performance of the code under test.

The benchmark tests are run in a similar way as the unit tests (instructions
provided below). They allow you to check that your code does not just work, but
is also efficient.

## The task

Refactor a tree building algorithm.

Some web-forums have a tree layout, so posts are presented as a tree. However
the posts are typically stored in a database as an unsorted set of records. Thus
when presenting the posts to the user the tree structure has to be
reconstructed.

Your job will be to refactor a working but slow and ugly piece of code that
implements the tree building logic for highly abstracted records. The records
only contain an ID number and a parent ID number. The ID number is always
between 0 (inclusive) and the length of the record list (exclusive). All records
have a parent ID lower than their own ID, except for the root record, which has
a parent ID that's equal to its own ID.

An example tree:

```text
root (ID: 0, parent ID: 0)
|-- child1 (ID: 1, parent ID: 0)
|    |-- grandchild1 (ID: 2, parent ID: 1)
|    +-- grandchild2 (ID: 4, parent ID: 1)
+-- child2 (ID: 3, parent ID: 0)
|    +-- grandchild3 (ID: 6, parent ID: 3)
+-- child3 (ID: 5, parent ID: 0)
```

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

## Running the benchmarks

The benchmark tests use another library called **BenchmarkDotNet**. This is
already referenced in the exercise project, and no additional steps need to be
taken to use it.

To run the benchmarks, run the command `dotnet run -c Release` from within the
exercise directory. You will get a table with two rows of results: `Baseline`
shows the values for the original version of the code; `Mine` is the performance
of your current solution.

```text
|   Method |     Mean | Allocated |
|--------- |---------:|----------:|
| Baseline | 12.39 us |  13.87 KB |
|     Mine | 12.23 us |  13.87 KB |
```

In addition to identifying the particular version of the code tested, the table
provides two columns with metrics - `Mean` and `Allocated`.

- The `Mean` column shows the average running time of the respective solution. BenchmarkDotNet runs each solution a number of times and then reports the the average time needed.
- The `Allocated` column shows the amount of memory that each solution allocates per single benchmark run. This has performance implications, because memory allocated by .NET code is cleaned up by a _Garbage Collector_, and this cleanup process takes time, slowing down the overall execution. For this exercise, reducing the amount of memory allocated should typically also improve overall performance.

## Further information

For more detailed information about the F# track, including how to get help if
you're having trouble, please visit the exercism.io [F# language page](http://exercism.io/languages/fsharp/resources).

