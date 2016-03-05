module RNATranscriptionTests

open NUnit.Framework
open Complement

type RNATranscriptionTest() =
    
    [<Test>]
    member tests.Rna_complement_of_cytosine_is_guanine() =
        Assert.That(Complement().ofDna("C"), Is.EqualTo("G"))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Rna_complement_of_guanine_is_cytosine() =
        Assert.That(Complement().ofDna("G"), Is.EqualTo("C"))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Rna_complement_of_thymine_is_adenine() =
        Assert.That(Complement().ofDna("T"), Is.EqualTo("A"))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Rna_complement_of_adenine_is_uracil() =
        Assert.That(Complement().ofDna("A"), Is.EqualTo("U"))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Rna_complement() =
        Assert.That(Complement().ofDna("ACGTGGTCTTAA"), Is.EqualTo("UGCACCAGAAUU"))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Dna_complement_of_cytosine_is_guanine() =
        Assert.That(Complement().ofRna("C"), Is.EqualTo("G"))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Dna_complement_of_guanine_is_cytosine() =
        Assert.That(Complement().ofRna("G"), Is.EqualTo("C"))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Dna_complement_of_uracil_is_adenine() =
        Assert.That(Complement().ofRna("U"), Is.EqualTo("A"))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Dna_complement_of_adenine_is_thymine() =
        Assert.That(Complement().ofRna("A"), Is.EqualTo("T"))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Dna_complement() =
        Assert.That(Complement().ofRna("UGAACCCGACAUG"), Is.EqualTo("ACTTGGGCTGTAC"))
