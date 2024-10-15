module ReverseStringTests

open FsUnit.Xunit
open Xunit

open ReverseString

[<Fact>]
let ``An empty string`` () =
    reverse "" |> should equal ""

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``A word`` () =
    reverse "robot" |> should equal "tobor"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``A capitalized word`` () =
    reverse "Ramen" |> should equal "nemaR"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``A sentence with punctuation`` () =
    reverse "I'm hungry!" |> should equal "!yrgnuh m'I"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``A palindrome`` () =
    reverse "racecar" |> should equal "racecar"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``An even-sized word`` () =
    reverse "drawer" |> should equal "reward"

