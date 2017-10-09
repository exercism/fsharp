// This file was auto-generated based on version 3.0.0 of the canonical data.

module CryptoSquareTest

open FsUnit.Xunit
open Xunit

open CryptoSquare

[<Fact>]
let ``Lowercase`` () =
    ciphertext "A" |> should equal "a"

[<Fact(Skip = "Remove to run test")>]
let ``Remove spaces`` () =
    ciphertext "  b " |> should equal "b"

[<Fact(Skip = "Remove to run test")>]
let ``Remove punctuation`` () =
    ciphertext "@1,%!" |> should equal "1"

[<Fact(Skip = "Remove to run test")>]
let ``Empty plaintext results in an empty ciphertext`` () =
    ciphertext "" |> should equal ""

[<Fact(Skip = "Remove to run test")>]
let ``9 character plaintext results in 3 chunks of 3 characters`` () =
    ciphertext "This is fun!" |> should equal "tsf hiu isn"

[<Fact(Skip = "Remove to run test")>]
let ``54 character plaintext results in 7 chunks, the last two padded with spaces`` () =
    ciphertext "If man was meant to stay on the ground, god would have given us roots." |> should equal "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn  sseoau "

