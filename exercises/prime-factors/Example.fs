module PrimeFactors

open System

let possiblePrimes (number: int64): int64 list =
    [2L; 3L] @ [for n in 6L..6L..number do
                   for k in [-1L; 1L] do
                      yield n + k ]

let primeFactorsFor number =
    let rec loop factors (remainder: int64) (possibleFactors: int64 list) =
        match possibleFactors with
        | [] -> factors |> List.rev
        | factor::xs ->        
            match remainder with
            | _ when remainder <= 1L -> factors |> List.rev
            | _ when remainder % factor = 0L -> loop (factor :: factors) (remainder / factor |> int64) possibleFactors
            | _ -> loop factors remainder (List.tail possibleFactors)

    loop [] number (possiblePrimes number)