// This file was created manually and its version is 1.0.0.
// This file supports running the performance benchmarks. Do not modify it.

open System.Collections.Generic
open System.Linq

open BenchmarkDotNet.Columns
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Diagnosers
open BenchmarkDotNet.Loggers
open BenchmarkDotNet.Reports
open BenchmarkDotNet.Running

open TreeBuildingBenchmark

type BenchmarkConfig() =
    inherit ManualConfig()

    let distinctWithComparer (comparer: IEqualityComparer<'T>) (sequence: 'T seq) =
        sequence.Distinct(comparer)

    let columnProvider =
        {
            new IColumnProvider with
                member __.GetColumns(summary: Summary) =
                    seq {
                        yield TargetMethodColumn.Method
                        yield StatisticColumn.Mean

                        yield!
                            summary.Reports
                            |> Seq.collect (fun r ->
                                r.Metrics.Values
                                |> Seq.filter (fun m -> m.Descriptor.DisplayName = "Allocated")
                                |> Seq.map (fun m -> m.Descriptor))
                            |> distinctWithComparer MetricDescriptorEqualityComparer.Instance
                            |> Seq.map (fun d -> MetricColumn d :> IColumn)
                    }
        }

    do
        base.Add(columnProvider)
        base.Add(MemoryDiagnoser.Default)
        base.Add(new ConsoleLogger());

[<EntryPoint>]
let main _ =
    BenchmarkRunner.Run<Benchmarks>(BenchmarkConfig()) |> ignore

    0
