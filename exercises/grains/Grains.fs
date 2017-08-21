module Grains

open System.Numerics

let square (n:int) = 2I ** (n - 1)
let total = [1..64] |> List.sumBy square