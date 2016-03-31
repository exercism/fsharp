module RNATranscriptionTests

open NUnit.Framework
open Complement
    
[<Test>]
let ``Rna complement of cytosine is guanine`` () =
    Assert.That(toRna "C", Is.EqualTo("G"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Rna complement of guanine is cytosine`` () =
    Assert.That(toRna "G", Is.EqualTo("C"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Rna complement of thymine is adenine`` () =
    Assert.That(toRna "T", Is.EqualTo("A"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Rna complement of adenine is uracil`` () =
    Assert.That(toRna "A", Is.EqualTo("U"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Rna complement`` () =
    Assert.That(toRna "ACGTGGTCTTAA", Is.EqualTo("UGCACCAGAAUU"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Dna complement of cytosine is guanine`` () =
    Assert.That(toDna "C", Is.EqualTo("G"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Dna complement of guanine is cytosine`` () =
    Assert.That(toDna "G", Is.EqualTo("C"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Dna complement of uracil is adenine`` () =
    Assert.That(toDna "U", Is.EqualTo("A"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Dna complement of adenine is thymine`` () =
    Assert.That(toDna "A", Is.EqualTo("T"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Dna complement`` () =
    Assert.That(toDna "UGAACCCGACAUG", Is.EqualTo("ACTTGGGCTGTAC"))