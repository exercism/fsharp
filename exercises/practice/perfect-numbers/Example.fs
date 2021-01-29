module PerfectNumbers

type Classification = Perfect | Abundant | Deficient

let sumOfFactors n = [for x in 1..n / 2 do if n % x = 0 then yield x] |> List.sum

let classify n : Classification option = 
    match n with
    | x when x <= 0 -> None
    | _ ->
        match sumOfFactors n with
        | x when x = n -> Some Perfect
        | x when x < n -> Some Deficient
        | _ -> Some Abundant