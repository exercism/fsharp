module Dominoes

let rotate xs =
    let length = xs |> List.length
    let perm n = xs |> List.permute (fun index -> (index + n) % length) 
    [1 .. length] |> List.rev |> List.map perm

let chainPair (x, y) list = 
    match list with    
    | (x', y')::xs when y = x' -> (x, y')::xs |> Some
    | (x', y')::xs when y = y' -> (x, x')::xs |> Some
    | _ -> None
    
let rec canChain input = 
    match input with
    | [] -> true
    | (x, y)::[] -> x = y
    | x::xs -> rotate xs |> List.choose (chainPair x) |> List.exists canChain