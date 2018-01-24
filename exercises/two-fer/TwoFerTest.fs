// This file was auto-generated based on version 1.2.0 of the canonical data.

module TwoFerTest

open FsUnit.Xunit
open Xunit

open TwoFer

[<Fact>]
let ``No name given`` () =
    twoFer None |> should equal "One for you, one for me."

[<Fact(Skip = "Remove to run test")>]
let ``A name given`` () =
    twoFer (Some "Alice") |> should equal "One for Alice, one for me."

[<Fact(Skip = "Remove to run test")>]
let ``Another name given`` () =
    twoFer (Some "Bob") |> should equal "One for Bob, one for me."

