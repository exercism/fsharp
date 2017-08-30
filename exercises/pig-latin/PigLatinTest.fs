module PigLatinTest

open Xunit
open FsUnit
open PigLatin

[<Theory(Skip = "Remove to run test")>]
[<InlineData("apple", "appleay")>]
[<InlineData("ear", "earay")>]
[<InlineData("igloo", "iglooay")>]
[<InlineData("object", "objectay")>]
[<InlineData("under", "underay")>]
let ``Ay is added to words that start with vowels`` (word, expected) =
    translate word |> should equal expected

[<Theory(Skip = "Remove to run test")>]
[<InlineData("pig", "igpay")>]
[<InlineData("koala", "oalakay")>]
[<InlineData("yellow", "ellowyay")>]
[<InlineData("xenon", "enonxay")>]
let ``First letter and ay are moved to the end of words that start with consonants`` (word, expected) =
    translate word |> should equal expected


[<Fact(Skip = "Remove to run test")>]
let ``Ch is treated like a single consonant`` () =
    translate "chair" |> should equal "airchay"

[<Fact(Skip = "Remove to run test")>]
let ``Qu is treated like a single consonant`` () =
    translate "queen" |> should equal "eenquay"

[<Fact(Skip = "Remove to run test")>]
let ``Qu and a single preceding consonant are treated like a single consonant`` () =
    translate "square" |> should equal "aresquay"

[<Fact(Skip = "Remove to run test")>]
let ``Th is treated like a single consonant`` () =
    translate "therapy" |> should equal "erapythay"

[<Fact(Skip = "Remove to run test")>]
let ``Thr is treated like a single consonant`` () =
    translate "thrush" |> should equal "ushthray"

[<Fact(Skip = "Remove to run test")>]
let ``Sch is treated like a single consonant`` () =
    translate "school" |> should equal "oolschay"

[<Fact(Skip = "Remove to run test")>]
let ``Yt is treated like a single vowel`` () =
    translate "yttria" |> should equal "yttriaay"

[<Fact(Skip = "Remove to run test")>]
let ``Xr is treated like a single vowel`` () =
    translate "xray" |> should equal "xrayay"

[<Fact(Skip = "Remove to run test")>]
let ``Phrases are translated`` () =
    translate "quick fast run" |> should equal "ickquay astfay unray"