// This file was created manually and its version is 1.0.0.
// This file supports running the performance benchmarks. Do not modify it.

module TreeBuildingBenchmark

open BenchmarkDotNet.Attributes

open TreeBuildingTypes

let inline run buildTree inputs =
    for input in inputs do
        buildTree input |> ignore

[<MemoryDiagnoser>]
[<InProcess>]
type Benchmarks () =
    let oneNode =
        [
            { RecordId = 0; ParentId = 0 }
        ]

    let threeNodesInOrder =
        [
            { RecordId = 0; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
        ]

    let threeNodesInReverseOrder =
        [
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
        ]

    let moreThanTwoChildren =
        [
            { RecordId = 3; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
        ]

    let binaryTree =
        [
            { RecordId = 5; ParentId = 1 };
            { RecordId = 3; ParentId = 2 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 4; ParentId = 1 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
            { RecordId = 6; ParentId = 2 }
        ]

    let unbalancedTree =
        [
            { RecordId = 5; ParentId = 2 };
            { RecordId = 3; ParentId = 2 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 4; ParentId = 1 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
            { RecordId = 6; ParentId = 2 }
        ]

    let inputs =
        [
            oneNode
            threeNodesInOrder
            threeNodesInReverseOrder
            moreThanTwoChildren
            binaryTree
            unbalancedTree
        ]

    [<Benchmark(Baseline = true)>]
    member __.Baseline () =
        inputs |> run TreeBuildingBaseline.buildTree

    [<Benchmark>]
    member __.Mine () =
        inputs |> run TreeBuilding.buildTree
