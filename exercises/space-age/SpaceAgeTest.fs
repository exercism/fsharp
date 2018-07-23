// This file was auto-generated based on version 1.1.0 of the canonical data.

module SpaceAgeTest

open FsUnit.Xunit
open Xunit

open SpaceAge

[<Fact>]
let ``Age on Earth`` () =
    age Earth 1000000000L |> should (equalWithin 0.01) 31.69

[<Fact(Skip = "Remove to run test")>]
let ``Age on Mercury`` () =
    age Mercury 2134835688L |> should (equalWithin 0.01) 280.88

[<Fact(Skip = "Remove to run test")>]
let ``Age on Venus`` () =
    age Venus 189839836L |> should (equalWithin 0.01) 9.78

[<Fact(Skip = "Remove to run test")>]
let ``Age on Mars`` () =
    age Mars 2329871239L |> should (equalWithin 0.01) 39.25

[<Fact(Skip = "Remove to run test")>]
let ``Age on Jupiter`` () =
    age Jupiter 901876382L |> should (equalWithin 0.01) 2.41

[<Fact(Skip = "Remove to run test")>]
let ``Age on Saturn`` () =
    age Saturn 3000000000L |> should (equalWithin 0.01) 3.23

[<Fact(Skip = "Remove to run test")>]
let ``Age on Uranus`` () =
    age Uranus 3210123456L |> should (equalWithin 0.01) 1.21

[<Fact(Skip = "Remove to run test")>]
let ``Age on Neptune`` () =
    age Neptune 8210123456L |> should (equalWithin 0.01) 1.58

