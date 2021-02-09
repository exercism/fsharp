module BookStore

let private costPerGroup groupSize =
    let discountPercentage =
        match groupSize with
        | 1 ->  0m
        | 2 ->  5m
        | 3 -> 10m
        | 4 -> 20m
        | 5 -> 25m
        | _ -> failwith "Invalid group size"

    8m * (groupSize |> decimal) * (100m - discountPercentage) / 100m

let private remove n list =
    let rec removeTail n list acc =
        match list with
        | x::xs when x = n -> List.append (List.rev acc) xs
        | x::xs            -> removeTail n xs (x::acc)
        | []               -> List.rev acc
    removeTail n list []

let rec private calculateTotalCostHelper books priceSoFar =
    match books |> List.length with
    | 0 -> priceSoFar
    | _ ->
        let groups =
            books
            |> List.groupBy id
            |> List.sortByDescending (fun (key, value) -> value.Length)
            |> List.map fst
        
        let prices =
            [1 .. groups |> List.length]
            |> List.map (fun i ->
                let itemsToRemove =
                    groups
                    |> List.take i

                let remaining =
                    itemsToRemove
                    |> List.fold (fun state t ->
                        remove t state)
                        books

                calculateTotalCostHelper remaining (priceSoFar + costPerGroup i)
            )
        
        prices
        |> List.min

let total books =
    calculateTotalCostHelper books 0m