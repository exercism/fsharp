// This file was auto-generated based on version 1.1.0 of the canonical data.

module PigLatinTest

open FsUnit.Xunit
open Xunit

open PigLatin

[<Fact>]
let ``word beginning with a`` () =
    translate "apple" |> should equal "appleay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with e`` () =
    translate "ear" |> should equal "earay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with i`` () =
    translate "igloo" |> should equal "iglooay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with o`` () =
    translate "object" |> should equal "objectay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with u`` () =
    translate "under" |> should equal "underay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with a vowel and followed by a qu`` () =
    translate "equal" |> should equal "equalay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with p`` () =
    translate "pig" |> should equal "igpay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with k`` () =
    translate "koala" |> should equal "oalakay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with x`` () =
    translate "xenon" |> should equal "enonxay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with q without a following u`` () =
    translate "qat" |> should equal "atqay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with ch`` () =
    translate "chair" |> should equal "airchay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with qu`` () =
    translate "queen" |> should equal "eenquay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with qu and a preceding consonant`` () =
    translate "square" |> should equal "aresquay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with th`` () =
    translate "therapy" |> should equal "erapythay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with thr`` () =
    translate "thrush" |> should equal "ushthray"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with sch`` () =
    translate "school" |> should equal "oolschay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with yt`` () =
    translate "yttria" |> should equal "yttriaay"

[<Fact(Skip = "Remove to run test")>]
let ``word beginning with xr`` () =
    translate "xray" |> should equal "xrayay"

[<Fact(Skip = "Remove to run test")>]
let ``y is treated like a consonant at the beginning of a word`` () =
    translate "yellow" |> should equal "ellowyay"

[<Fact(Skip = "Remove to run test")>]
let ``y is treated like a vowel at the end of a consonant cluster`` () =
    translate "rhythm" |> should equal "ythmrhay"

[<Fact(Skip = "Remove to run test")>]
let ``y as second letter in two letter word`` () =
    translate "my" |> should equal "ymay"

[<Fact(Skip = "Remove to run test")>]
let ``a whole phrase`` () =
    translate "quick fast run" |> should equal "ickquay astfay unray"

