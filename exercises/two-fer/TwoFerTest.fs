// This file was auto-generated based on version 1.1.0 of the canonical data.

module TwoFerTest

open FsUnit.Xunit
open Xunit

open TwoFer

[<Fact>]
let ``No name given`` () =
    name None |> should equal "One for you, one for me."

[<Fact(Skip = "Remove to run test")>]
let ``A name given`` () =
    name (Some "Alice") |> should equal "One for Alice, one for me."

[<Fact(Skip = "Remove to run test")>]
let ``Another name given`` () =
    name (Some "Bob") |> should equal "One for Bob, one for me."

