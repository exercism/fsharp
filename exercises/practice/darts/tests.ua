~ "SOLUTION" ~ Darts

let ``Missed target`` () =
    score -9.0 9.0 |> should equal 0

let ``On the outer circle`` () =
    score 0.0 10.0 |> should equal 1

let ``On the middle circle`` () =
    score -5.0 0.0 |> should equal 5

let ``On the inner circle`` () =
    score 0.0 -1.0 |> should equal 10

let ``Exactly on center`` () =
    score 0.0 0.0 |> should equal 10

let ``Near the center`` () =
    score -0.1 -0.1 |> should equal 10

let ``Just within the inner circle`` () =
    score 0.7 0.7 |> should equal 10

let ``Just outside the inner circle`` () =
    score 0.8 -0.8 |> should equal 5

let ``Just within the middle circle`` () =
    score -3.5 3.5 |> should equal 5

let ``Just outside the middle circle`` () =
    score -3.6 -3.6 |> should equal 1

let ``Just within the outer circle`` () =
    score -7.0 7.0 |> should equal 1

let ``Just outside the outer circle`` () =
    score 7.1 -7.1 |> should equal 0

let ``Asymmetric position between the inner and middle circles`` () =
    score 0.5 -4.0 |> should equal 5

