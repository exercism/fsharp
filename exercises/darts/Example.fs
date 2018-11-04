module Darts

open System

let score (x: double) (y: double): int = 
    let distance = Math.Sqrt(x * x + y * y)

    if distance <= 1.0 then
        10
    elif distance <= 5.0 then
        5
    elif distance <= 10.0 then
        1
    else
        0