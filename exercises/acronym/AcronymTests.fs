module AcronymTests

open NUnit.Framework
open Acronym

[<TestFixture>]
type AcronymTests() =

    [<Test>]
    member tests.Empty_string_abbreviated_to_empty_string() =
        Assert.That(Acronym().abbreviate(""), Is.EqualTo(""))
        
    [<TestCase("Portable Network Graphics", ExpectedResult = "PNG", Ignore = true)>]
    [<TestCase("Ruby on Rails", ExpectedResult = "ROR", Ignore = true)>]
    [<TestCase("HyperText Markup Language", ExpectedResult = "HTML", Ignore = true)>]
    [<TestCase("First In, First Out", ExpectedResult = "FIFO", Ignore = true)>]
    [<TestCase("PHP: Hypertext Preprocessor", ExpectedResult = "PHP", Ignore = true)>]
    [<TestCase("Complementary metal-oxide semiconductor", ExpectedResult = "CMOS", Ignore = true)>]
    member tests.Phrase_abbreviated_to_acronym(phrase) =
        Acronym().abbreviate(phrase)