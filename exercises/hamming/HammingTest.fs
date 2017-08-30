module HammingTest

open Xunit
open FsUnit
open Hamming

[<Fact>]
let ``No difference between empty strands`` () =
    compute "" "" |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``No difference between identical strands`` () =
    compute "GGACTGA" "GGACTGA" |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Complete hamming distance in small strand`` () =
    compute "ACT" "GGA" |> should equal 3

[<Fact(Skip = "Remove to run test")>]
let ``Hamming distance is off by one strand`` () =
    compute "GGACGGATTCTG" "AGGACGGATTCT" |> should equal 9

[<Fact(Skip = "Remove to run test")>]
let ``Smalling hamming distance in middle somewhere`` () =
    compute "GGACG" "GGTCG" |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``Larger distance`` () =
    compute "ACCAGGG" "ACTATGG" |> should equal 2