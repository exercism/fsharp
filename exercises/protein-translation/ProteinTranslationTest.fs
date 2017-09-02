module ProteinTranslationTest

open Xunit
open FsUnit.Xunit
open System

open ProteinTranslation

[<Theory(Skip = "Remove to run test")>]
[<InlineData("AUG")>]
let ``Identifies Methionine codons`` (codon) =
    translate codon |> should equal ["Methionine"]
    
[<Theory(Skip = "Remove to run test")>]
[<InlineData("UUU")>]
[<InlineData("UUC")>]
let ``Identifies Phenylalanine codons`` (codon) =
    translate codon |> should equal ["Phenylalanine"]
 
[<Theory(Skip = "Remove to run test")>]   
[<InlineData("UUA")>]
[<InlineData("UUG")>]
let ``Identifies Leucine codons`` (codon) =
    translate codon |> should equal ["Leucine"]
    
[<Theory(Skip = "Remove to run test")>]
[<InlineData("UCU")>]
[<InlineData("UCC")>]
[<InlineData("UCA")>]
[<InlineData("UCG")>]
let ``Identifies Serine codons`` (codon) =
    translate codon |> should equal ["Serine"]
    
[<Theory(Skip = "Remove to run test")>]
[<InlineData("UAU")>]
[<InlineData("UAC")>]
let ``Identifies Tyrosine codons`` (codon) =
    translate codon |> should equal ["Tyrosine"]
    
[<Theory(Skip = "Remove to run test")>]
[<InlineData("UGU")>]
[<InlineData("UGC")>]
let ``Identifies Cysteine codons`` (codon) =
    translate codon |> should equal ["Cysteine"]
    
[<Theory(Skip = "Remove to run test")>]
[<InlineData("UGG")>] 
let ``Identifies Tryptophan codons`` (codon) =
    translate codon |> should equal ["Tryptophan"]

[<Fact(Skip = "Remove to run test")>]
let ``Translates rna strand into correct protein`` () =
    translate "AUGUUUUGG" |> should equal ["Methionine"; "Phenylalanine"; "Tryptophan"]

[<Fact(Skip = "Remove to run test")>]
let ``Stops translation if stop codon present`` () =
    translate "AUGUUUUAA" |> should equal ["Methionine"; "Phenylalanine"]

[<Fact(Skip = "Remove to run test")>]
let ``Stops translation of longer strand`` () =
    translate "UGGUGUUAUUAAUGGUUU'" |> should equal ["Tryptophan"; "Cysteine"; "Tyrosine"]

[<Fact(Skip = "Remove to run test")>]
let ``Throws for invalid codons`` () =
    (fun () -> translate "CARROT'" |> List.ofSeq |> ignore) |> should throw typeof<Exception>