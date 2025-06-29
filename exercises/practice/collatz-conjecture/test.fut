import "collatz_conjecture"

let ``Zero steps for one`` () =
    steps 1 |> should equal 0

let ``Divide if even`` () =
    steps 16 |> should equal 4

let ``Even and odd steps`` () =
    steps 12 |> should equal 9

let ``Large number of even and odd steps`` () =
    steps 1000000 |> should equal 152

let ``Zero is an error`` () =
    steps 0 |> should equal None

let ``Negative value is an error`` () =
    steps -15 |> should equal None

