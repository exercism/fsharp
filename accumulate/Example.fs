module Accumulate

type Accumulate() =

    let rec accumulateLoop func input acc = 
        match input with
            | [] -> acc |> List.rev
            | x::xs -> accumulateLoop func xs (func x :: acc)

    member this.accumulate(func, input) = accumulateLoop func input List.empty

