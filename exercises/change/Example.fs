module Change

let minimalCoins coins map target =
    coins
    |> List.filter (fun x -> x <= target)
    |> List.map (fun x -> x :: Map.find (target - x) map)
    |> List.sortBy List.length
    |> List.tryHead

let updateMinimalCoinsMap coins map target = 
    match minimalCoins coins map target with
    | Some x -> Map.add target x map
    | None   -> map

let findFewestCoins coins target = 
    [1..target]
    |> List.fold (updateMinimalCoinsMap coins) (Map.ofList [(0, [])])
    |> Map.tryFind target