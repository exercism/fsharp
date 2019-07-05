// This file was auto-generated based on version 2.0.0 of the canonical data.

module PangramTest

open FsUnit.Xunit
open Xunit

open Pangram

[<Fact>]
let ``Empty sentence`` () =
    isPangram "" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Perfect lower case`` () =
    isPangram "abcdefghijklmnopqrstuvwxyz" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Only lower case`` () =
    isPangram "the quick brown fox jumps over the lazy dog" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Missing the letter 'x'`` () =
    isPangram "a quick movement of the enemy will jeopardize five gunboats" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Missing the letter 'h'`` () =
    isPangram "five boxing wizards jump quickly at it" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``With underscores`` () =
    isPangram "the_quick_brown_fox_jumps_over_the_lazy_dog" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``With numbers`` () =
    isPangram "the 1 quick brown fox jumps over the 2 lazy dogs" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Missing letters replaced by numbers`` () =
    isPangram "7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Mixed case and punctuation`` () =
    isPangram "\"Five quacking Zephyrs jolt my wax bed.\"" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Case insensitive`` () =
    isPangram "the quick brown fox jumps over with lazy FX" |> should equal false

