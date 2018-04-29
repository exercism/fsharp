module Sublist

type SublistType = Equal | Sublist | Superlist | Unequal

let rec isSublist xs ys lx ly = 
    let rec helper xs' ys' =
        match (xs', ys') with
        | [], _ -> true
        | x'::xs'', y'::ys'' when x' = y' -> helper xs'' ys''
        | _ -> false

    if lx > ly then false
    elif helper xs ys then true
    else isSublist xs (List.tail ys) lx (ly - 1)

let sublist xs ys = 
    match (List.length xs, List.length ys) with
    | x, y when x < y && isSublist xs ys x y -> Sublist
    | x, y when x > y && isSublist ys xs y x -> Superlist
    | _ when xs = ys -> Equal
    | _ -> Unequal