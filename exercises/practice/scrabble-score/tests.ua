module ScrabbleScoreTests



let ``Lowercase letter`` () =
    score "a" |> should equal 1

let ``Uppercase letter`` () =
    score "A" |> should equal 1

let ``Valuable letter`` () =
    score "f" |> should equal 4

let ``Short word`` () =
    score "at" |> should equal 2

let ``Short, valuable word`` () =
    score "zoo" |> should equal 12

let ``Medium word`` () =
    score "street" |> should equal 6

let ``Medium, valuable word`` () =
    score "quirky" |> should equal 22

let ``Long, mixed-case word`` () =
    score "OxyphenButazone" |> should equal 41

let ``English-like word`` () =
    score "pinata" |> should equal 8

let ``Empty input`` () =
    score "" |> should equal 0

let ``Entire alphabet available`` () =
    score "abcdefghijklmnopqrstuvwxyz" |> should equal 87

