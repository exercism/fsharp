// This file was auto-generated based on version 2.1.0 of the canonical data.

module HammingTest

open FsUnit.Xunit
open Xunit

open Hamming

[<Fact>]
let ``Empty strands`` () =
    distance "" "" |> should equal (Some 0)

[<Fact(Skip = "Remove to run test")>]
let ``Identical strands`` () =
    distance "A" "A" |> should equal (Some 0)

[<Fact(Skip = "Remove to run test")>]
let ``Long identical strands`` () =
    distance "GGACTGA" "GGACTGA" |> should equal (Some 0)

[<Fact(Skip = "Remove to run test")>]
let ``Complete distance in single nucleotide strands`` () =
    distance "A" "G" |> should equal (Some 1)

[<Fact(Skip = "Remove to run test")>]
let ``Complete distance in small strands`` () =
    distance "AG" "CT" |> should equal (Some 2)

[<Fact(Skip = "Remove to run test")>]
let ``Small distance in small strands`` () =
    distance "AT" "CT" |> should equal (Some 1)

[<Fact(Skip = "Remove to run test")>]
let ``Small distance`` () =
    distance "GGACG" "GGTCG" |> should equal (Some 1)

[<Fact(Skip = "Remove to run test")>]
let ``Small distance in long strands`` () =
    distance "ACCAGGG" "ACTATGG" |> should equal (Some 2)

[<Fact(Skip = "Remove to run test")>]
let ``Non-unique character in first strand`` () =
    distance "AAG" "AAA" |> should equal (Some 1)

[<Fact(Skip = "Remove to run test")>]
let ``Non-unique character in second strand`` () =
    distance "AAA" "AAG" |> should equal (Some 1)

[<Fact(Skip = "Remove to run test")>]
let ``Same nucleotides in different positions`` () =
    distance "TAG" "GAT" |> should equal (Some 2)

[<Fact(Skip = "Remove to run test")>]
let ``Large distance`` () =
    distance "GATACA" "GCATAA" |> should equal (Some 4)

[<Fact(Skip = "Remove to run test")>]
let ``Large distance in off-by-one strand`` () =
    distance "GGACGGATTCTG" "AGGACGGATTCT" |> should equal (Some 9)

[<Fact(Skip = "Remove to run test")>]
let ``Disallow first strand longer`` () =
    distance "AATG" "AAA" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Disallow second strand longer`` () =
    distance "ATA" "AGTG" |> should equal None

