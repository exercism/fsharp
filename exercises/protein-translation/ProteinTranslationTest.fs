module ProteinTranslationTest

open NUnit.Framework
open FsUnit

open ProteinTranslation

[<TestCase("AUG")>]
let ``Identifies Methionine codons`` (codon) =
    translate codon |> should equal ["Methionine"]
    
[<TestCase("UUU", Ignore = "Remove to run test case")>]
[<TestCase("UUC", Ignore = "Remove to run test case")>]
let ``Identifies Phenylalanine codons`` (codon) =
    translate codon |> should equal ["Phenylalanine"]
    
[<TestCase("UUA", Ignore = "Remove to run test case")>]
[<TestCase("UUG", Ignore = "Remove to run test case")>]
let ``Identifies Leucine codons`` (codon) =
    translate codon |> should equal ["Leucine"]
    
[<TestCase("UCU", Ignore = "Remove to run test case")>]
[<TestCase("UCC", Ignore = "Remove to run test case")>]
[<TestCase("UCA", Ignore = "Remove to run test case")>]
[<TestCase("UCG", Ignore = "Remove to run test case")>]
let ``Identifies Serine codons`` (codon) =
    translate codon |> should equal ["Serine"]
    
[<TestCase("UAU", Ignore = "Remove to run test case")>]
[<TestCase("UAC", Ignore = "Remove to run test case")>]
let ``Identifies Tyrosine codons`` (codon) =
    translate codon |> should equal ["Tyrosine"]
    
[<TestCase("UGU", Ignore = "Remove to run test case")>]
[<TestCase("UGC", Ignore = "Remove to run test case")>]
let ``Identifies Cysteine codons`` (codon) =
    translate codon |> should equal ["Cysteine"]
    
[<TestCase("UGG", Ignore = "Remove to run test case")>] 
let ``Identifies Tryptophan codons`` (codon) =
    translate codon |> should equal ["Tryptophan"]

[<Test>]
[<Ignore("Remove to run test")>]
let ``Translates rna strand into correct protein`` () =
    translate "AUGUUUUGG" |> should equal ["Methionine"; "Phenylalanine"; "Tryptophan"]

[<Test>]
[<Ignore("Remove to run test")>]
let ``Stops translation if stop codon present`` () =
    translate "AUGUUUUAA" |> should equal ["Methionine"; "Phenylalanine"]

[<Test>]
[<Ignore("Remove to run test")>]
let ``Stops translation of longer strand`` () =
    translate "UGGUGUUAUUAAUGGUUU'" |> should equal ["Tryptophan"; "Cysteine"; "Tyrosine"]

[<Test>]
[<Ignore("Remove to run test")>]
let ``Throws for invalid codons`` () =
    (fun () -> translate "CARROT'" |> List.ofSeq |> ignore) |> should throw typeof<Exception>