// This file was auto-generated based on version 1.3.0 of the canonical data.

module NucleotideCountTest

open FsUnit.Xunit
open Xunit

open NucleotideCount

[<Fact>]
let ``Empty strand`` () =
    let strand = ""
    let expected = 
        [ ('A', 0);
          ('C', 0);
          ('G', 0);
          ('T', 0) ]
        |> Map.ofList
        |> Some
    nucleotideCounts strand |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Can count one nucleotide in single-character input`` () =
    let strand = "G"
    let expected = 
        [ ('A', 0);
          ('C', 0);
          ('G', 1);
          ('T', 0) ]
        |> Map.ofList
        |> Some
    nucleotideCounts strand |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Strand with repeated nucleotide`` () =
    let strand = "GGGGGGG"
    let expected = 
        [ ('A', 0);
          ('C', 0);
          ('G', 7);
          ('T', 0) ]
        |> Map.ofList
        |> Some
    nucleotideCounts strand |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Strand with multiple nucleotides`` () =
    let strand = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"
    let expected = 
        [ ('A', 20);
          ('C', 12);
          ('G', 17);
          ('T', 21) ]
        |> Map.ofList
        |> Some
    nucleotideCounts strand |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Strand with invalid nucleotides`` () =
    let strand = "AGXXACT"
    let expected = None
    nucleotideCounts strand |> should equal expected

