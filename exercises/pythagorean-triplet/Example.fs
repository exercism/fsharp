module PythagoreanTriplet

open System

type Triplet = { x: int; y: int; z: int }

let private square x = x * x
let private squareRoot x = Math.Sqrt(x |> float) |> Math.Floor |> int

let triplet x y z =     
    match [x; y; z] |> List.sort with
    | x'::y'::z'::_ -> { x = x' ; y = y'; z = z' }
    | _ -> failwith "Should never get here"

let isPythagorean triplet = square triplet.x + square triplet.y = square triplet.z

let tripletsWithSum sum = 
    [for x in 1 .. (sum - 1) do
        for y in (x + 1) .. (sum - 1 - x) do
            let target = sum - (x + y)
            let triplet = triplet x y target
            if isPythagorean triplet then
                    yield triplet] |> List.distinct