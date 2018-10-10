module PythagoreanTriplet

open System

let private square x = x * x

let private isPythagorean (x, y, z) = square x + square y = square z

let tripletsWithSum sum = 
    [for x in 1 .. (sum - 1) do
        for y in (x + 1) .. (sum - 1 - x) do
            let target = sum - (x + y)
            let triplet = (x, y, target)
            if isPythagorean triplet then
                    yield triplet] |> List.distinct