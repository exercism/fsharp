

let ``Square of sum 1`` () =
    squareOfSum 1 |> should equal 1

let ``Square of sum 5`` () =
    squareOfSum 5 |> should equal 225

let ``Square of sum 100`` () =
    squareOfSum 100 |> should equal 25502500

let ``Sum of squares 1`` () =
    sumOfSquares 1 |> should equal 1

let ``Sum of squares 5`` () =
    sumOfSquares 5 |> should equal 55

let ``Sum of squares 100`` () =
    sumOfSquares 100 |> should equal 338350

let ``Difference of squares 1`` () =
    differenceOfSquares 1 |> should equal 0

let ``Difference of squares 5`` () =
    differenceOfSquares 5 |> should equal 170

let ``Difference of squares 100`` () =
    differenceOfSquares 100 |> should equal 25164150

