module GuessingGameTests



let ``Give hint for 42``() = reply 42 |> should equal "Correct"

let ``Give hint for 41``() = reply 41 |> should equal "So close"

let ``Give hint for 43``() = reply 43 |> should equal "So close"

let ``Give hint for 40``() = reply 40 |> should equal "Too low"

let ``Give hint for 1``() = reply 1 |> should equal "Too low"

let ``Give hint for 44``() = reply 44 |> should equal "Too high"

let ``Give hint for 100``() = reply 100 |> should equal "Too high"
