open System

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running

open Approaches

let codons = [| "AUG"; "UUC"; "UUU"; "UUA"; "UUG"; "UCU"; "UCC"; "UCA"; "UCG"; "UAU"; "UAC"; "UGU"; "UGC"; "UGG"; "UAA"; "UAG"; "UGA" |]

[<MemoryDiagnoser>]
type Benchmarks() =
    let mutable rna = ""

    [<Params(0, 1, 10, 1000)>]
    member val NumberOfCodons = 0 with get, set

    [<GlobalSetup>]
    member this.Setup() =
        rna <- Seq.init this.NumberOfCodons (fun _ -> codons[Random.Shared.Next(codons.Length)]) |> String.concat ""

    [<Benchmark>] member _.Recursion () = recursionApproach rna
    [<Benchmark>] member _.Seq    [<Benchmark>] member _.Span () = spanApproach rna    
    [<Benchmark>] member _.Unfold () = unfoldApproach rna

let summary = BenchmarkRunner.Run<Benchmarks>()
