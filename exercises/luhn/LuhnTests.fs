// This file was auto-generated based on version 1.7.0 of the canonical data.

module LuhnTests

open FsUnit.Xunit
open Xunit

open Luhn

[<Fact>]
let ``Single digit strings can not be valid`` () =
    valid "1" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``A single zero is invalid`` () =
    valid "0" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``A simple valid SIN that remains valid if reversed`` () =
    valid "059" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``A simple valid SIN that becomes invalid if reversed`` () =
    valid "59" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``A valid Canadian SIN`` () =
    valid "055 444 285" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Invalid Canadian SIN`` () =
    valid "055 444 286" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Invalid credit card`` () =
    valid "8273 1232 7352 0569" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Invalid long number with an even remainder`` () =
    valid "1 2345 6789 1234 5678 9012" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Valid number with an even number of digits`` () =
    valid "095 245 88" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Valid number with an odd number of spaces`` () =
    valid "234 567 891 234" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Valid strings with a non-digit added at the end become invalid`` () =
    valid "059a" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Valid strings with punctuation included become invalid`` () =
    valid "055-444-285" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Valid strings with symbols included become invalid`` () =
    valid "055# 444$ 285" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Single zero with space is invalid`` () =
    valid " 0" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``More than a single zero is valid`` () =
    valid "0000 0" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Input digit 9 is correctly converted to output digit 9`` () =
    valid "091" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Using ascii value for non-doubled non-digit isn't allowed`` () =
    valid "055b 444 285" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Using ascii value for doubled non-digit isn't allowed`` () =
    valid ":9" |> should equal false

