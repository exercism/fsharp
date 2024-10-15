module PerfectNumbersTests

open FsUnit.Xunit
open Xunit

open PerfectNumbers

[<Fact>]
let ``Smallest perfect number is classified correctly`` () =
    classify 6 |> should equal (Some Classification.Perfect)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Medium perfect number is classified correctly`` () =
    classify 28 |> should equal (Some Classification.Perfect)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Large perfect number is classified correctly`` () =
    classify 33550336 |> should equal (Some Classification.Perfect)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Smallest abundant number is classified correctly`` () =
    classify 12 |> should equal (Some Classification.Abundant)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Medium abundant number is classified correctly`` () =
    classify 30 |> should equal (Some Classification.Abundant)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Large abundant number is classified correctly`` () =
    classify 33550335 |> should equal (Some Classification.Abundant)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Smallest prime deficient number is classified correctly`` () =
    classify 2 |> should equal (Some Classification.Deficient)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Smallest non-prime deficient number is classified correctly`` () =
    classify 4 |> should equal (Some Classification.Deficient)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Medium deficient number is classified correctly`` () =
    classify 32 |> should equal (Some Classification.Deficient)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Large deficient number is classified correctly`` () =
    classify 33550337 |> should equal (Some Classification.Deficient)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Edge case (no factors other than itself) is classified correctly`` () =
    classify 1 |> should equal (Some Classification.Deficient)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Zero is rejected (as it is not a positive integer)`` () =
    classify 0 |> should equal None

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Negative integer is rejected (as it is not a positive integer)`` () =
    classify -1 |> should equal None

