// This file was auto-generated based on version 1.1.0 of the canonical data.

module ScrabbleScoreTests

open FsUnit.Xunit
open Xunit

open ScrabbleScore

[<Fact>]
let ``Lowercase letter`` () =
    score "a" |> should equal 1

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Uppercase letter`` () =
    score "A" |> should equal 1

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Valuable letter`` () =
    score "f" |> should equal 4

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Short word`` () =
    score "at" |> should equal 2

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Short, valuable word`` () =
    score "zoo" |> should equal 12

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Medium word`` () =
    score "street" |> should equal 6

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Medium, valuable word`` () =
    score "quirky" |> should equal 22

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Long, mixed-case word`` () =
    score "OxyphenButazone" |> should equal 41

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``English-like word`` () =
    score "pinata" |> should equal 8

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Empty input`` () =
    score "" |> should equal 0

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Entire alphabet available`` () =
    score "abcdefghijklmnopqrstuvwxyz" |> should equal 87

