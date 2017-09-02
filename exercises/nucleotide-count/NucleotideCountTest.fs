module NucleoTideCountTest

open Xunit
open FsUnit.Xunit
open System

open NucleoTideCount

[<Fact>]
let ``Has no nucleotides`` () =
    let strand = ""
    let expected = [ ( 'A', 0 ); ( 'T', 0 ); ( 'C', 0 ); ( 'G', 0 ) ] |> Map.ofSeq
    nucleotideCounts strand |> should equal expected
    
[<Fact(Skip = "Remove to run test")>]
let ``Has no adenosine`` () =
    let strand = ""
    count 'A' strand |> should equal 0
    
[<Fact(Skip = "Remove to run test")>]
let ``Repetitive cytidine gets counts`` () =
    let strand = "CCCCC"
    count 'C' strand |> should equal 5
    
[<Fact(Skip = "Remove to run test")>]
let ``Repetitive sequence has only guanosine`` () =
    let strand = "GGGGGGGG"
    let expected = [ ( 'A', 0 ); ( 'T', 0 ); ( 'C', 0 ); ( 'G', 8 ) ] |> Map.ofSeq
    nucleotideCounts strand |> should equal expected
    
[<Fact(Skip = "Remove to run test")>]
let ``Counts only thymidine`` () =
    let strand = "GGGGTAACCCGG"
    count 'T' strand |> should equal 1
    
[<Fact(Skip = "Remove to run test")>]
let ``Validates nucleotides`` () =
    let strand = "GGTTGG"
    (fun () -> count 'X' strand |> ignore) |> should throw typeof<Exception>
    
[<Fact(Skip = "Remove to run test")>]
let ``Counts all nucleotides`` () =
    let strand = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"
    let expected = [ ( 'A', 20 ); ( 'T', 21 ); ( 'C', 12 ); ( 'G', 17 ) ] |> Map.ofSeq
    nucleotideCounts strand |> should equal expected