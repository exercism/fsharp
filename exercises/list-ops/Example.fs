module ListOps

let rec foldl folder state list =
    match list with
    | [] -> state
    | x::xs -> foldl folder (folder state x) xs

let rec foldr folder state list =
    list
    |> List.rev
    |> foldl (fun acc item -> folder item acc) state

let length list = foldl (fun acc _ -> acc + 1) 0 list

let reverse list = foldl (fun acc item -> item :: acc) [] list

let map f list = foldr (fun item acc -> f item :: acc) [] list

let filter f list = foldr (fun item acc -> if f item then item :: acc else acc) [] list

let append xs ys = foldr (fun item acc -> item :: acc) ys xs

let concat xs = foldr append [] xs