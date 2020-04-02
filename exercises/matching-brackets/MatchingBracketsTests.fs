// This file was auto-generated based on version 2.0.0 of the canonical data.

module MatchingBracketsTests

open FsUnit.Xunit
open Xunit

open MatchingBrackets

[<Fact>]
let ``Paired square brackets`` () =
    isPaired "[]" |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Empty string`` () =
    isPaired "" |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Unpaired brackets`` () =
    isPaired "[[" |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Wrong ordered brackets`` () =
    isPaired "}{" |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Wrong closing bracket`` () =
    isPaired "{]" |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Paired with whitespace`` () =
    isPaired "{ }" |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Partially paired brackets`` () =
    isPaired "{[])" |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Simple nested brackets`` () =
    isPaired "{[]}" |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Several paired brackets`` () =
    isPaired "{}[]" |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Paired and nested brackets`` () =
    isPaired "([{}({}[])])" |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Unopened closing brackets`` () =
    isPaired "{[)][]}" |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Unpaired and nested brackets`` () =
    isPaired "([{])" |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Paired and wrong nested brackets`` () =
    isPaired "[({]})" |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Paired and incomplete brackets`` () =
    isPaired "{}[" |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Too many closing brackets`` () =
    isPaired "[]]" |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Math expression`` () =
    isPaired "(((185 + 223.85) * 15) - 543)/2" |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Complex latex expression`` () =
    isPaired "\left(\begin{array}{cc} \frac{1}{3} & x\\ \mathrm{e}^{x} &... x^2 \end{array}\right)" |> should equal true

