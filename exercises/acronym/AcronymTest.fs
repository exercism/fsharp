module AcronymTest

open NUnit.Framework
open Acronym

[<Test>]
let ``Empty string abbreviated to empty string`` () =
    Assert.That(acronym "", Is.EqualTo(""))
        
[<TestCase("Portable Network Graphics", ExpectedResult = "PNG", Ignore = "Remove to run test case")>]
[<TestCase("Ruby on Rails", ExpectedResult = "ROR", Ignore = "Remove to run test case")>]
[<TestCase("HyperText Markup Language", ExpectedResult = "HTML", Ignore = "Remove to run test case")>]
[<TestCase("First In, First Out", ExpectedResult = "FIFO", Ignore = "Remove to run test case")>]
[<TestCase("PHP: Hypertext Preprocessor", ExpectedResult = "PHP", Ignore = "Remove to run test case")>]
[<TestCase("Complementary metal-oxide semiconductor", ExpectedResult = "CMOS", Ignore = "Remove to run test case")>]
let ``Phrase abbreviated to acronym`` (phrase: string) =
    acronym phrase