module Proverb

let line (want, lost) = sprintf "For want of a %s the %s was lost." want lost

let ending input = sprintf "And all for the want of a %s." (List.head input)

let recite input =
    match List.isEmpty input with
    | true -> 
        []
    | false ->
        let lines = input |> List.pairwise |> List.map line
        List.append lines [ending input]