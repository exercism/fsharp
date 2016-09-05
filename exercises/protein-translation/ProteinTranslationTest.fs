module ProteinTranslationTest

open NUnit.Framework

open ProteinTranslation

[<TestCase("AUG")>]
let ``Identifies Methionine codons`` (codon) =
    Assert.That(translate codon, Is.EqualTo(["Methionine"]))
    
[<TestCase("UUU", Ignore = "Remove to run test case")>]
[<TestCase("UUC", Ignore = "Remove to run test case")>]
let ``Identifies Phenylalanine codons`` (codon) =
    Assert.That(translate codon, Is.EqualTo(["Phenylalanine"]))
    
[<TestCase("UUA", Ignore = "Remove to run test case")>]
[<TestCase("UUG", Ignore = "Remove to run test case")>]
let ``Identifies Leucine codons`` (codon) =
    Assert.That(translate codon, Is.EqualTo(["Leucine"]))
    
[<TestCase("UCU", Ignore = "Remove to run test case")>]
[<TestCase("UCC", Ignore = "Remove to run test case")>]
[<TestCase("UCA", Ignore = "Remove to run test case")>]
[<TestCase("UCG", Ignore = "Remove to run test case")>]
let ``Identifies Serine codons`` (codon) =
    Assert.That(translate codon, Is.EqualTo(["Serine"]))
    
[<TestCase("UAU", Ignore = "Remove to run test case")>]
[<TestCase("UAC", Ignore = "Remove to run test case")>]
let ``Identifies Tyrosine codons`` (codon) =
    Assert.That(translate codon, Is.EqualTo(["Tyrosine"]))
    
[<TestCase("UGU", Ignore = "Remove to run test case")>]
[<TestCase("UGC", Ignore = "Remove to run test case")>]
let ``Identifies Cysteine codons`` (codon) =
    Assert.That(translate codon, Is.EqualTo(["Cysteine"]))
    
[<TestCase("UGG", Ignore = "Remove to run test case")>] 
let ``Identifies Tryptophan codons`` (codon) =
    Assert.That(translate codon, Is.EqualTo(["Tryptophan"]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Translates rna strand into correct protein`` () =
    Assert.That(translate "AUGUUUUGG", Is.EqualTo(["Methionine"; "Phenylalanine"; "Tryptophan"]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Stops translation if stop codon present`` () =
    Assert.That(translate "AUGUUUUAA", Is.EqualTo(["Methionine"; "Phenylalanine"]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Stops translation of longer strand`` () =
    Assert.That(translate "UGGUGUUAUUAAUGGUUU'", Is.EqualTo(["Tryptophan"; "Cysteine"; "Tyrosine"]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Throws for invalid codons`` () =
    Assert.That((fun () -> translate "CARROT'" |> List.ofSeq |> ignore), Throws.Exception)