// This is the file you need to modify for your own solution.
// The unit tests will use this code, and it will be used by the benchmark tests
// for the "Mine" row of the summary table.

// Remember to not only run the unit tests for this exercise, but also the
// benchmark tests using `dotnet run -c Release`.
// Please refer to the instructions for more information about the benchmark tests.

module TreeBuilding

open TreeBuildingTypes

type Tree =
    | Branch of int * Tree list
    | Leaf of int

let recordId t =
    match t with
    | Branch (id, c) -> id
    | Leaf id -> id

let isBranch t =
    match t with
    | Branch (id, c) -> true
    | Leaf id -> false

let children t =
    match t with
    | Branch (id, c) -> c
    | Leaf id -> []

let buildTree records =
    let records' = List.sortBy (fun x -> x.RecordId) records

    if List.isEmpty records' then failwith "Empty input"
    else
        let root = records'.[0]
        if (root.ParentId = 0 |> not) then
            failwith "Root node is invalid"
        else
            if (root.RecordId = 0 |> not) then failwith "Root node is invalid"
            else
                let mutable prev = -1
                let mutable leafs = []

                for r in records' do
                    if (r.RecordId <> 0 && (r.ParentId > r.RecordId || r.ParentId = r.RecordId)) then
                        failwith "Nodes with invalid parents"
                    else
                        if r.RecordId <> prev + 1 then
                            failwith "Non-continuous list"
                        else
                            prev <- r.RecordId
                            if (r.RecordId = 0) then
                                leafs <- leafs @ [(-1, r.RecordId)]
                            else
                                leafs <- leafs @ [(r.ParentId, r.RecordId)]

                let root = leafs.[0]

                let grouped = leafs |> List.groupBy fst |> List.map (fun (x, y) -> (x, List.map snd y))
                let parents = List.map fst grouped
                let map = grouped |> Map.ofSeq

                let rec helper key =
                    if Map.containsKey key map then
                        Branch (key, List.map (fun i -> helper i) (Map.find key map))
                    else
                        Leaf key

                let root = helper 0
                root
