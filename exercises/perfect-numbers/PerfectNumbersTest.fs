// This file was auto-generated based on version 1.1.0 of the canonical data.

module PerfectNumbersTest

open FsUnit.Xunit
open Xunit

open PerfectNumbers

[<Fact>]
let ``Smallest perfect number is classified correctly`` () =
    classify 6 |> should equal (Some Classification.Perfect)

[<Fact(Skip = "Remove to run test")>]
let ``Medium perfect number is classified correctly`` () =
    classify 28 |> should equal (Some Classification.Perfect)

[<Fact(Skip = "Remove to run test")>]
let ``Large perfect number is classified correctly`` () =
    classify 33550336 |> should equal (Some Classification.Perfect)

[<Fact(Skip = "Remove to run test")>]
let ``Smallest abundant number is classified correctly`` () =
    classify 12 |> should equal (Some Classification.Abundant)

[<Fact(Skip = "Remove to run test")>]
let ``Medium abundant number is classified correctly`` () =
    classify 30 |> should equal (Some Classification.Abundant)

[<Fact(Skip = "Remove to run test")>]
let ``Large abundant number is classified correctly`` () =
    classify 33550335 |> should equal (Some Classification.Abundant)

[<Fact(Skip = "Remove to run test")>]
let ``Smallest prime deficient number is classified correctly`` () =
    classify 2 |> should equal (Some Classification.Deficient)

[<Fact(Skip = "Remove to run test")>]
let ``Smallest non-prime deficient number is classified correctly`` () =
    classify 4 |> should equal (Some Classification.Deficient)

[<Fact(Skip = "Remove to run test")>]
let ``Medium deficient number is classified correctly`` () =
    classify 32 |> should equal (Some Classification.Deficient)

[<Fact(Skip = "Remove to run test")>]
let ``Large deficient number is classified correctly`` () =
    classify 33550337 |> should equal (Some Classification.Deficient)

[<Fact(Skip = "Remove to run test")>]
let ``Edge case (no factors other than itself) is classified correctly`` () =
    classify 1 |> should equal (Some Classification.Deficient)

[<Fact(Skip = "Remove to run test")>]
let ``Zero is rejected (not a natural number)`` () =
    classify 0 |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Negative integer is rejected (not a natural number)`` () =
    classify -1 |> should equal None

