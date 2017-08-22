module RNATranscriptionTest

open NUnit.Framework
open FsUnit

open RNATranscription
    
[<Test>]
let ``Rna complement of cytosine is guanine`` () =
    toRna "C" |> should equal "G"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Rna complement of guanine is cytosine`` () =
    toRna "G" |> should equal "C"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Rna complement of thymine is adenine`` () =
    toRna "T" |> should equal "A"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Rna complement of adenine is uracil`` () =
    toRna "A" |> should equal "U"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Rna complement`` () =
    toRna "ACGTGGTCTTAA" |> should equal "UGCACCAGAAUU"