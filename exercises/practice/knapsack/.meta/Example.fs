module Knapsack

type Item = { weight: int; value: int }

let rec maximumValue items maximumWeight =
    match items with
    | [] -> 0
    | item :: rest when item.weight > maximumWeight -> maximumValue rest maximumWeight
    | item :: rest ->
        max
            (maximumValue rest maximumWeight)
            (item.value
             + maximumValue rest (maximumWeight - item.weight))
