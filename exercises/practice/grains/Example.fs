module Grains

open System.Numerics

let square (n:int) = 
    if n <= 0 || n > 64 then 
        Error "square must be between 1 and 64"
    else
        Ok (2I ** (n - 1) |> uint64)

let total = 
    [1..64] 
    |> List.map square
    |> List.reduce (fun x y -> match x, y with Ok a, Ok b -> Ok (a + b) | _ -> Error "Invalid input")