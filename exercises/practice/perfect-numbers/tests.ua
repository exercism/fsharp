module PerfectNumbersTests



let ``Smallest perfect number is classified correctly`` () =
    classify 6 |> should equal (Some Classification.Perfect)

let ``Medium perfect number is classified correctly`` () =
    classify 28 |> should equal (Some Classification.Perfect)

let ``Large perfect number is classified correctly`` () =
    classify 33550336 |> should equal (Some Classification.Perfect)

let ``Smallest abundant number is classified correctly`` () =
    classify 12 |> should equal (Some Classification.Abundant)

let ``Medium abundant number is classified correctly`` () =
    classify 30 |> should equal (Some Classification.Abundant)

let ``Large abundant number is classified correctly`` () =
    classify 33550335 |> should equal (Some Classification.Abundant)

let ``Smallest prime deficient number is classified correctly`` () =
    classify 2 |> should equal (Some Classification.Deficient)

let ``Smallest non-prime deficient number is classified correctly`` () =
    classify 4 |> should equal (Some Classification.Deficient)

let ``Medium deficient number is classified correctly`` () =
    classify 32 |> should equal (Some Classification.Deficient)

let ``Large deficient number is classified correctly`` () =
    classify 33550337 |> should equal (Some Classification.Deficient)

let ``Edge case (no factors other than itself) is classified correctly`` () =
    classify 1 |> should equal (Some Classification.Deficient)

let ``Zero is rejected (as it is not a positive integer)`` () =
    classify 0 |> should equal None

let ``Negative integer is rejected (as it is not a positive integer)`` () =
    classify -1 |> should equal None

