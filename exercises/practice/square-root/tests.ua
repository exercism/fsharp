

let ``Root of 1`` () =
    squareRoot 1 |> should equal 1

let ``Root of 4`` () =
    squareRoot 4 |> should equal 2

let ``Root of 25`` () =
    squareRoot 25 |> should equal 5

let ``Root of 81`` () =
    squareRoot 81 |> should equal 9

let ``Root of 196`` () =
    squareRoot 196 |> should equal 14

let ``Root of 65025`` () =
    squareRoot 65025 |> should equal 255

