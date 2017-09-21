// This file was auto-generated based on version 1.0.0 of the canonical data.

module ScrabbleScoreTest

open FsUnit.Xunit
open Xunit

open ScrabbleScore

[<Fact>]
let ``lowercase letter`` () =
    score "a" |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``uppercase letter`` () =
    score "A" |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``valuable letter`` () =
    score "f" |> should equal 4

[<Fact(Skip = "Remove to run test")>]
let ``short word`` () =
    score "at" |> should equal 2

[<Fact(Skip = "Remove to run test")>]
let ``short, valuable word`` () =
    score "zoo" |> should equal 12

[<Fact(Skip = "Remove to run test")>]
let ``medium word`` () =
    score "street" |> should equal 6

[<Fact(Skip = "Remove to run test")>]
let ``medium, valuable word`` () =
    score "quirky" |> should equal 22

[<Fact(Skip = "Remove to run test")>]
let ``long, mixed-case word`` () =
    score "OxyphenButazone" |> should equal 41

[<Fact(Skip = "Remove to run test")>]
let ``english-like word`` () =
    score "pinata" |> should equal 8

[<Fact(Skip = "Remove to run test")>]
let ``empty input`` () =
    score "" |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``entire alphabet available`` () =
    score "abcdefghijklmnopqrstuvwxyz" |> should equal 87

