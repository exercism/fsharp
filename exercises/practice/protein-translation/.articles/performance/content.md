# Performance

In this approach, we'll find out how to most efficiently translate the RNA to proteins in F#.

The [approaches page][approaches] lists three idiomatic approaches to this exercise:

1. [Using recursion][approach-recursion]
2. [Using `Seq.unfold`][approach-unfold]
3. [Using the `Seq` module][approach-seq-module]

For our performance investigation, we'll also include a fourth approach that [uses the `Span<T>` type][approach-span].

## Benchmarks

To benchmark the approaches, we wrote a [small benchmark application][benchmark-application] using [BenchmarkDotNet library][benchmark-dotnet].
We've benchmarked using RNA sequences with 0, 1, 10 and 1000 codons.

| Method    | NumberOfCodons |         Mean |      Error |     StdDev |   Gen0 |   Gen1 | Allocated |
| --------- | -------------- | -----------: | ---------: | ---------: | -----: | -----: | --------: |
| Recursion | 0              |     7.493 ns |  0.0388 ns |  0.0363 ns |      - |      - |         - |
| SeqModule | 0              |   152.652 ns |  2.1404 ns |  2.0021 ns | 0.0956 |      - |     600 B |
| Span      | 0              |    14.663 ns |  0.1050 ns |  0.0931 ns |      - |      - |         - |
| Unfold    | 0              |    43.211 ns |  0.5399 ns |  0.4786 ns | 0.0204 |      - |     128 B |
| Recursion | 1              |    17.780 ns |  0.3530 ns |  0.3302 ns | 0.0051 |      - |      32 B |
| SeqModule | 1              |   235.316 ns |  3.6080 ns |  3.3749 ns | 0.1109 |      - |     696 B |
| Span      | 1              |    29.655 ns |  0.2732 ns |  0.2556 ns | 0.0051 |      - |      32 B |
| Unfold    | 1              |    82.138 ns |  0.9021 ns |  0.7997 ns | 0.0343 |      - |     216 B |
| Recursion | 10             |   137.225 ns |  1.5763 ns |  1.4744 ns | 0.1109 |      - |     696 B |
| SeqModule | 10             |   509.363 ns |  7.7862 ns |  7.2832 ns | 0.1669 |      - |    1048 B |
| Span      | 10             |    24.006 ns |  0.4712 ns |  0.4408 ns | 0.0051 |      - |      32 B |
| Unfold    | 10             |   237.525 ns |  3.9554 ns |  5.0023 ns | 0.1466 |      - |     920 B |
| Recursion | 1000           | 1,785.969 ns | 17.1735 ns | 16.0641 ns | 4.8676 | 0.0019 |   30544 B |
| SeqModule | 1000           |   501.784 ns |  4.8090 ns |  4.4983 ns | 0.1669 |      - |    1048 B |
| Span      | 1000           |   146.319 ns |  1.3266 ns |  1.2409 ns | 0.0713 |      - |     448 B |
| Unfold    | 1000           |   408.245 ns |  5.8096 ns |  5.4343 ns | 1.0028 | 0.0224 |    6296 B |

For zero or one codons, the recursion approach is the fastest one.
For bigger numbers of codons, the `Span<T>` approach is undoubtedly the best one, which shows that not allocating strings can be a great boost to performance.

It is interesting to see that, for all but a tiny number of codonds, manual recursion is far less optimal than `Seq.unfold`.

[approaches]: https://exercism.org/tracks/fsharp/exercises/protein-translation/dig_deeper
[approach-recursion]: https://exercism.org/tracks/fsharp/exercises/protein-translation/approaches/recursion
[approach-unfold]: https://exercism.org/tracks/fsharp/exercises/protein-translation/approaches/unfold
[approach-seq-module]: https://exercism.org/tracks/fsharp/exercises/protein-translation/approaches/seq-module
[approach-span]: https://exercism.org/tracks/fsharp/exercises/protein-translation/approaches/span
[benchmark-dotnet]: https://benchmarkdotnet.org/index.html
[benchmark-application]: https://github.com/exercism/fsharp/blob/main/exercises/practice/protein-translation/.articles/performance/code/Program.fs
