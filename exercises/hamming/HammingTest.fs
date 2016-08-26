module HammingTest

open NUnit.Framework
open Hamming

[<Test>]
let ``No difference between empty strands`` () =
    Assert.That(compute "" "", Is.EqualTo(0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``No difference between identical strands`` () =
    Assert.That(compute "GGACTGA" "GGACTGA", Is.EqualTo(0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Complete hamming distance in small strand`` () =
    Assert.That(compute "ACT" "GGA", Is.EqualTo(3))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Hamming distance is off by one strand`` () =
    Assert.That(compute "GGACGGATTCTG" "AGGACGGATTCT", Is.EqualTo(9))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Smalling hamming distance in middle somewhere`` () =
    Assert.That(compute "GGACG" "GGTCG", Is.EqualTo(1))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Larger distance`` () =
    Assert.That(compute "ACCAGGG" "ACTATGG", Is.EqualTo(2))