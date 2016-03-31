module NucleoTideCountTest

open NUnit.Framework

open NucleoTideCount

[<Test>]
let ``Has no nucleotides`` () =
    let strand = ""
    let expected = [ ( 'A', 0 ); ( 'T', 0 ); ( 'C', 0 ); ( 'G', 0 ) ] |> Map.ofSeq
    Assert.That(nucleotideCounts strand, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Has no adenosine`` () =
    let strand = ""
    Assert.That(count 'A' strand, Is.EqualTo(0))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Repetitive cytidine gets counts`` () =
    let strand = "CCCCC"
    Assert.That(count 'C' strand, Is.EqualTo(5))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Repetitive sequence has only guanosine`` () =
    let strand = "GGGGGGGG"
    let expected = [ ( 'A', 0 ); ( 'T', 0 ); ( 'C', 0 ); ( 'G', 8 ) ] |> Map.ofSeq
    Assert.That(nucleotideCounts strand, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Counts only thymidine`` () =
    let strand = "GGGGTAACCCGG"
    Assert.That(count 'T' strand, Is.EqualTo(1))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Validates nucleotides`` () =
    let strand = "GGTTGG"
    Assert.Throws(fun () -> count 'X' strand |> ignore) |> ignore
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Counts all nucleotides`` () =
    let strand = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"
    let expected = [ ( 'A', 20 ); ( 'T', 21 ); ( 'C', 12 ); ( 'G', 17 ) ] |> Map.ofSeq
    Assert.That(nucleotideCounts strand, Is.EqualTo(expected))