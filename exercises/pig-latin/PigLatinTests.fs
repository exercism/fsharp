module PigLatinTests

open NUnit.Framework
open PigLatin

[<TestFixture>]
type PigLatinTests() =
    
    [<TestCase("apple", ExpectedResult = "appleay")>]
    [<TestCase("ear", ExpectedResult = "earay", Ignore = true)>]
    [<TestCase("igloo", ExpectedResult = "iglooay", Ignore = true)>]
    [<TestCase("object", ExpectedResult = "objectay", Ignore = true)>]
    [<TestCase("under", ExpectedResult = "underay", Ignore = true)>]
    member tests.Ay_is_added_to_words_that_start_with_vowels(word) =
        PigLatin().translate(word)

    [<TestCase("pig", ExpectedResult = "igpay", Ignore = true)>]
    [<TestCase("koala", ExpectedResult = "oalakay", Ignore = true)>]
    [<TestCase("yellow", ExpectedResult = "ellowyay", Ignore = true)>]
    [<TestCase("xenon", ExpectedResult = "enonxay", Ignore = true)>]
    member tests.First_letter_and_ay_are_moved_to_the_end_of_words_that_start_with_consonants(word) =
        PigLatin().translate(word)

    [<Test>]
    [<Ignore>]
    member tests.Ch_is_treated_like_a_single_consonant() =
        Assert.That(PigLatin().translate("chair"), Is.EqualTo("airchay"))

    [<Test>]
    [<Ignore>]
    member tests.Qu_is_treated_like_a_single_consonant() =
        Assert.That(PigLatin().translate("queen"), Is.EqualTo("eenquay"))

    [<Test>]
    [<Ignore>]
    member tests.Qu_and_a_single_preceding_consonant_are_treated_like_a_single_consonant() =
        Assert.That(PigLatin().translate("square"), Is.EqualTo("aresquay"))

    [<Test>]
    [<Ignore>]
    member tests.Th_is_treated_like_a_single_consonant() =
        Assert.That(PigLatin().translate("therapy"), Is.EqualTo("erapythay"))

    [<Test>]
    [<Ignore>]
    member tests.Thr_is_treated_like_a_single_consonant() =
        Assert.That(PigLatin().translate("thrush"), Is.EqualTo("ushthray"))

    [<Test>]
    [<Ignore>]
    member tests.Sch_is_treated_like_a_single_consonant() =
        Assert.That(PigLatin().translate("school"), Is.EqualTo("oolschay"))

    [<Test>]
    [<Ignore>]
    member tests.Yt_is_treated_like_a_single_vowel() =
        Assert.That(PigLatin().translate("yttria"), Is.EqualTo("yttriaay"))

    [<Test>]
    [<Ignore>]
    member tests.Xr_is_treated_like_a_single_vowel() =
        Assert.That(PigLatin().translate("xray"), Is.EqualTo("xrayay"))

    [<Test>]
    [<Ignore>]
    member tests.Phrases_are_translated() =
        Assert.That(PigLatin().translate("quick fast run"), Is.EqualTo("ickquay astfay unray"))
