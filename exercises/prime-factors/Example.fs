module PrimeFactors

open System

let factors number =
    let rec loop factors (remainder: int64) (factorToCheck: int64) =     
            match remainder with
            | _ when remainder <= 1L -> factors |> List.rev
            | _ when remainder % factorToCheck = 0L 
                    -> loop (int factorToCheck :: factors) (remainder / factorToCheck |> int64) factorToCheck
            | _ -> loop factors remainder (factorToCheck+1L)

    loop [] number 2L