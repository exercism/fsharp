// This file was auto-generated based on version 1.2.0 of the canonical data.

module RotationalCipherTest

open FsUnit.Xunit
open Xunit

open RotationalCipher

[<Fact>]
let ``Rotate a by 0, same output as input`` () =
    rotate 0 "a" |> should equal "a"

[<Fact(Skip = "Remove to run test")>]
let ``Rotate a by 1`` () =
    rotate 1 "a" |> should equal "b"

[<Fact(Skip = "Remove to run test")>]
let ``Rotate a by 26, same output as input`` () =
    rotate 26 "a" |> should equal "a"

[<Fact(Skip = "Remove to run test")>]
let ``Rotate m by 13`` () =
    rotate 13 "m" |> should equal "z"

[<Fact(Skip = "Remove to run test")>]
let ``Rotate n by 13 with wrap around alphabet`` () =
    rotate 13 "n" |> should equal "a"

[<Fact(Skip = "Remove to run test")>]
let ``Rotate capital letters`` () =
    rotate 5 "OMG" |> should equal "TRL"

[<Fact(Skip = "Remove to run test")>]
let ``Rotate spaces`` () =
    rotate 5 "O M G" |> should equal "T R L"

[<Fact(Skip = "Remove to run test")>]
let ``Rotate numbers`` () =
    rotate 4 "Testing 1 2 3 testing" |> should equal "Xiwxmrk 1 2 3 xiwxmrk"

[<Fact(Skip = "Remove to run test")>]
let ``Rotate punctuation`` () =
    rotate 21 "Let's eat, Grandma!" |> should equal "Gzo'n zvo, Bmviyhv!"

[<Fact(Skip = "Remove to run test")>]
let ``Rotate all letters`` () =
    rotate 13 "The quick brown fox jumps over the lazy dog." |> should equal "Gur dhvpx oebja sbk whzcf bire gur ynml qbt."

