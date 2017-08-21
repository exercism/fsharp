module DifferenceOfSquares

let square x = x * x

let squareOfSums (number: int) = [1..number] |> List.sum |> square
let sumOfSquares (number: int) = [1..number] |> List.map square |> List.sum
let difference (number: int) = squareOfSums number - sumOfSquares number