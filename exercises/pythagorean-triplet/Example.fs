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

let pythagoreanTriplets min max = 
    [for x in min .. (max - 2) do
        for y in x .. (max - 1) do
            let target = square x + square y
            let z = squareRoot target
            if z <= max && square z = target then
                yield triplet x y z]