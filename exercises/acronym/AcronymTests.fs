module AcronymTests

open NUnit.Framework
open Acronym

[<TestFixture>]
type AcronymTests() =

    [<Test>]
    member tests.Empty_string_abbreviated_to_empty_string() =
        Assert.That(Acronym().abbreviate(""), Is.EqualTo(""))
        
    [<TestCase("Portable Network Graphics", Result = "PNG", Ignore = true)>]
    [<TestCase("Ruby on Rails", Result = "ROR", Ignore = true)>]
    [<TestCase("HyperText Markup Language", Result = "HTML", Ignore = true)>]
    [<TestCase("First In, First Out", Result = "FIFO", Ignore = true)>]
    [<TestCase("PHP: Hypertext Preprocessor", Result = "PHP", Ignore = true)>]
    [<TestCase("Complementary metal-oxide semiconductor", Result = "CMOS", Ignore = true)>]
    member tests.Phrase_abbreviated_to_acronym(phrase) =
        Acronym().abbreviate(phrase)