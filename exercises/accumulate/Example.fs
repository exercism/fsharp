module Accumulate

let rec accumulateLoop func input acc = 
    match input with
        | [] -> acc |> List.rev
        | x::xs -> accumulateLoop func xs (func x :: acc)

let accumulate func input = accumulateLoop func input List.empty