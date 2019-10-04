open BenchmarkDotNet.Running

open TreeBuildingBenchmark

[<EntryPoint>]
let main _ =
    BenchmarkRunner.Run<Benchmarks>() |> ignore

    0
