module DifferenceOfSquares

type DifferenceOfSquares(max: int) =
    member this.squareOfSums() =
        [1..max]
            |> List.sum
            |> fun sum -> sum * sum

    member this.sumOfSquares() =
        [1..max]
            |> List.map(fun num -> num * num)
            |> List.sum

    member this.difference() =
        this.squareOfSums() - this.sumOfSquares()