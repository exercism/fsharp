module HammingTests

open NUnit.Framework
open Hamming

type HammingTests() =

    [<Test>]
    member tests.No_difference_between_empty_strands() =
        Assert.That(Hamming().compute("",""), Is.EqualTo(0))

    [<Test>]
    [<Ignore>]
    member tests.No_difference_between_identical_strands() =
        Assert.That(Hamming().compute("GGACTGA","GGACTGA"), Is.EqualTo(0))

    [<Test>]
    [<Ignore>]
    member tests.Complete_hamming_distance_in_small_strand() =
        Assert.That(Hamming().compute("ACT","GGA"), Is.EqualTo(3))

    [<Test>]
    [<Ignore>]
    member tests.Hamming_distance_is_off_by_one_strand() =
        Assert.That(Hamming().compute("GGACGGATTCTG","AGGACGGATTCT"), Is.EqualTo(9))

    [<Test>]
    [<Ignore>]
    member tests.Smalling_hamming_distance_in_middle_somewhere() =
        Assert.That(Hamming().compute("GGACG","GGTCG"), Is.EqualTo(1))

    [<Test>]
    [<Ignore>]
    member tests.Larger_distance() =
        Assert.That(Hamming().compute("ACCAGGG","ACTATGG"), Is.EqualTo(2))