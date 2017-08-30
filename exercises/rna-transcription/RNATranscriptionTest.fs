module RNATranscriptionTest

open Xunit
open FsUnit

open RNATranscription
    
[Fact]
let ``Rna complement of cytosine is guanine`` () =
    toRna "C" |> should equal "G"

[Fact(Skip = "Remove to run test")]
let ``Rna complement of guanine is cytosine`` () =
    toRna "G" |> should equal "C"

[Fact(Skip = "Remove to run test")]
let ``Rna complement of thymine is adenine`` () =
    toRna "T" |> should equal "A"

[Fact(Skip = "Remove to run test")]
let ``Rna complement of adenine is uracil`` () =
    toRna "A" |> should equal "U"

[Fact(Skip = "Remove to run test")]
let ``Rna complement`` () =
    toRna "ACGTGGTCTTAA" |> should equal "UGCACCAGAAUU"