module PerfectNumbers

type Classification = Perfect | Abundant | Deficient | InvalidInput

let sumOfFactors n = [for x in 1..n / 2 do if n % x = 0 then yield x] |> List.sum

let classify n = 
    match n with
    | x when x <= 0 -> InvalidInput
    | _ ->
        match sumOfFactors n with
        | x when x = n -> Perfect
        | x when x < n -> Deficient
        | _ -> Abundant