module NthPrimeTests

open FsUnit.Xunit
open Xunit

open NthPrime

[<Fact>]
let ``First prime`` () =
    prime 1 |> should equal (Some 2)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Second prime`` () =
    prime 2 |> should equal (Some 3)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Sixth prime`` () =
    prime 6 |> should equal (Some 13)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Big prime`` () =
    prime 10001 |> should equal (Some 104743)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``There is no zeroth prime`` () =
    prime 0 |> should equal None

