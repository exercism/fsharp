// This file was auto-generated based on version 1.4.0 of the canonical data.

module PangramTest

open FsUnit.Xunit
open Xunit

open Pangram

[<Fact>]
let ``Sentence empty`` () =
    isPangram "" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes a perfect lower case pangram`` () =
    isPangram "abcdefghijklmnopqrstuvwxyz" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Pangram with only lower case`` () =
    isPangram "the quick brown fox jumps over the lazy dog" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Missing character 'x'`` () =
    isPangram "a quick movement of the enemy will jeopardize five gunboats" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Another missing character, e.g. 'h'`` () =
    isPangram "five boxing wizards jump quickly at it" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Pangram with underscores`` () =
    isPangram "the_quick_brown_fox_jumps_over_the_lazy_dog" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Pangram with numbers`` () =
    isPangram "the 1 quick brown fox jumps over the 2 lazy dogs" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Missing letters replaced by numbers`` () =
    isPangram "7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Pangram with mixed case and punctuation`` () =
    isPangram "\"Five quacking Zephyrs jolt my wax bed.\"" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Upper and lower case versions of the same character should not be counted separately`` () =
    isPangram "the quick brown fox jumps over with lazy FX" |> should equal false

