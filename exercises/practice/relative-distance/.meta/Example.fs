module RelativeDistance

open System.Collections.Generic

let private bidirectional tree =
    let connect person1 person2 graph =
        graph
        |> Map.change person1 (function
            | Some connections -> connections |> Set.add person2 |> Some
            | None -> person2 |> Set.singleton |> Some)

    let connectParentChild parent child graph =
        graph
        |> connect parent child
        |> connect child parent

    let connectSiblings siblings graph =
        siblings
        |> List.allPairs siblings
        |> List.filter (fun (a, b) -> a <> b)
        |> List.fold (fun acc (siblingA, siblingB) -> connect siblingA siblingB acc) graph

    Map.fold
        (fun graph parent children ->
            children
            |> List.fold (fun acc child -> connectParentChild parent child acc) graph
            |> connectSiblings children)
        Map.empty
        tree

let rec private bfs graph (visited: HashSet<string>) (queue: Queue<string * int>) target =
    if queue.Count = 0 then
        None
    else
        let (current, distance) = queue.Dequeue()

        if current = target then
            Some distance
        else
            let unvisitedNeighbors =
                graph
                |> Map.tryFind current
                |> Option.defaultValue Set.empty
                |> Set.difference
                <| Set.ofSeq visited

            Set.iter (fun neighbor -> queue.Enqueue((neighbor, distance + 1))) unvisitedNeighbors

            visited.UnionWith(unvisitedNeighbors)

            bfs graph visited queue target

let degreeOfSeparation (familyTree: Map<string, string list>) (personA: string) (personB: string) : int option =
    let graph = bidirectional familyTree

    if
        not (Map.containsKey personA graph)
        || not (Map.containsKey personB graph)
    then
        None
    else
        let visited = HashSet<string>([ personA ])
        let queue = Queue<string * int>([ personA, 0 ])
        bfs graph visited queue personB
