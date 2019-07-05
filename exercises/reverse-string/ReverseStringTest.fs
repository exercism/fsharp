// This file was auto-generated based on version 1.2.0 of the canonical data.

module ReverseStringTest

open FsUnit.Xunit
open Xunit

open ReverseString

[<Fact>]
let ``An empty string`` () =
    reverse "" |> should equal ""

[<Fact(Skip = "Remove to run test")>]
let ``A word`` () =
    reverse "robot" |> should equal "tobor"

[<Fact(Skip = "Remove to run test")>]
let ``A capitalized word`` () =
    reverse "Ramen" |> should equal "nemaR"

[<Fact(Skip = "Remove to run test")>]
let ``A sentence with punctuation`` () =
    reverse "I'm hungry!" |> should equal "!yrgnuh m'I"

[<Fact(Skip = "Remove to run test")>]
let ``A palindrome`` () =
    reverse "racecar" |> should equal "racecar"

[<Fact(Skip = "Remove to run test")>]
let ``An even-sized word`` () =
    reverse "drawer" |> should equal "reward"

