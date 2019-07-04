// This file was auto-generated based on version 2.3.0 of the canonical data.

module HammingTest

open FsUnit.Xunit
open Xunit

open Hamming

[<Fact>]
let ``Empty strands`` () =
    distance "" "" |> should equal (Some 0)

[<Fact(Skip = "Remove to run test")>]
let ``Single letter identical strands`` () =
    distance "A" "A" |> should equal (Some 0)

[<Fact(Skip = "Remove to run test")>]
let ``Single letter different strands`` () =
    distance "G" "T" |> should equal (Some 1)

[<Fact(Skip = "Remove to run test")>]
let ``Long identical strands`` () =
    distance "GGACTGAAATCTG" "GGACTGAAATCTG" |> should equal (Some 0)

[<Fact(Skip = "Remove to run test")>]
let ``Long different strands`` () =
    distance "GGACGGATTCTG" "AGGACGGATTCT" |> should equal (Some 9)

[<Fact(Skip = "Remove to run test")>]
let ``Disallow first strand longer`` () =
    distance "AATG" "AAA" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Disallow second strand longer`` () =
    distance "ATA" "AGTG" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Disallow left empty strand`` () =
    distance "" "G" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Disallow right empty strand`` () =
    distance "G" "" |> should equal None

