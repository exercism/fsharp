import "nth_prime"

let ``First prime`` () =
    prime 1 |> should equal 2

let ``Second prime`` () =
    prime 2 |> should equal 3

let ``Sixth prime`` () =
    prime 6 |> should equal 13

let ``Big prime`` () =
    prime 10001 |> should equal 104743

let ``There is no zeroth prime`` () =
    prime 0 |> should equal None

