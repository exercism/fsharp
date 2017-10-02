module DifferenceOfSquares

let square x = x * x

let squareOfSum (number: int) = [1..number] |> List.sum |> square
let sumOfSquares (number: int) = List.sumBy square [1..number]
let differenceOfSquares (number: int) = squareOfSum number - sumOfSquares number