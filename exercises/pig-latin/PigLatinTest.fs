module PigLatinTest

open Xunit
open FsUnit
open PigLatin

[<TestCase("apple", ExpectedResult = "appleay")>]
[<TestCase("ear", ExpectedResult = "earay", Ignore = "Remove to run test case")>]
[<TestCase("igloo", ExpectedResult = "iglooay", Ignore = "Remove to run test case")>]
[<TestCase("object", ExpectedResult = "objectay", Ignore = "Remove to run test case")>]
[<TestCase("under", ExpectedResult = "underay", Ignore = "Remove to run test case")>]
let ``Ay is added to words that start with vowels`` (word) =
    translate word

[<TestCase("pig", ExpectedResult = "igpay", Ignore = "Remove to run test case")>]
[<TestCase("koala", ExpectedResult = "oalakay", Ignore = "Remove to run test case")>]
[<TestCase("yellow", ExpectedResult = "ellowyay", Ignore = "Remove to run test case")>]
[<TestCase("xenon", ExpectedResult = "enonxay", Ignore = "Remove to run test case")>]
let ``First letter and ay are moved to the end of words that start with consonants`` (word) =
    translate word

[<Test>]
[<Ignore("Remove to run test")>]
let ``Ch is treated like a single consonant`` () =
    translate "chair" |> should equal "airchay"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Qu is treated like a single consonant`` () =
    translate "queen" |> should equal "eenquay"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Qu and a single preceding consonant are treated like a single consonant`` () =
    translate "square" |> should equal "aresquay"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Th is treated like a single consonant`` () =
    translate "therapy" |> should equal "erapythay"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Thr is treated like a single consonant`` () =
    translate "thrush" |> should equal "ushthray"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sch is treated like a single consonant`` () =
    translate "school" |> should equal "oolschay"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Yt is treated like a single vowel`` () =
    translate "yttria" |> should equal "yttriaay"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Xr is treated like a single vowel`` () =
    translate "xray" |> should equal "xrayay"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Phrases are translated`` () =
    translate "quick fast run" |> should equal "ickquay astfay unray"