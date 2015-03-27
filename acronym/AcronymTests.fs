module AcronymTests

open NUnit.Framework
open Acronym

[<TestFixture>]
type AcronymTests() =

    [<Test>]
    member tests.Empty_string_abbreviated_to_empty_string() =
        Assert.That(Acronym().abbreviate(""), Is.EqualTo(""))
        
    [<TestCase("Portable Network Graphics", Result = "PNG")>]
    [<TestCase("Ruby on Rails", Result = "ROR")>]
    [<TestCase("HyperText Markup Language", Result = "HTML")>]
    [<TestCase("First In, First Out", Result = "FIFO")>]
    [<TestCase("PHP: Hypertext Preprocessor", Result = "PHP")>]
    [<TestCase("Complementary metal-oxide semiconductor", Result = "CMOS")>]
    [<Ignore>]
    member tests.Phrase_abbreviated_to_acronym(phrase) =
        Acronym().abbreviate(phrase)