// This file was auto-generated based on version 1.3.0 of the canonical data.

module RnaTranscriptionTests

open FsUnit.Xunit
open Xunit

open RnaTranscription

[<Fact>]
let ``Empty RNA sequence`` () =
    toRna "" |> should equal ""

[<Fact(Skip = "Remove to run test")>]
let ``RNA complement of cytosine is guanine`` () =
    toRna "C" |> should equal "G"

[<Fact(Skip = "Remove to run test")>]
let ``RNA complement of guanine is cytosine`` () =
    toRna "G" |> should equal "C"

[<Fact(Skip = "Remove to run test")>]
let ``RNA complement of thymine is adenine`` () =
    toRna "T" |> should equal "A"

[<Fact(Skip = "Remove to run test")>]
let ``RNA complement of adenine is uracil`` () =
    toRna "A" |> should equal "U"

[<Fact(Skip = "Remove to run test")>]
let ``RNA complement`` () =
    toRna "ACGTGGTCTTAA" |> should equal "UGCACCAGAAUU"

