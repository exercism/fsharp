module PythagoreanTriplet

open System

let tripletsWithSum sum = 
    [for x in 1 .. (sum / 3) do
        let squareX = x*x
        let z_plus_y = sum - x
        for y in (x + 1) .. (sum - 1 - x) do
            let z = sum - (x + y)
            if (z-y) * z_plus_y = squareX then
                    yield (x,y,z)]