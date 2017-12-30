// This file was auto-generated based on version 3.2.0 of the canonical data.

module CryptoSquareTest

open FsUnit.Xunit
open Xunit

open CryptoSquare

[<Fact>]
let ``Empty plaintext results in an empty ciphertext`` () =
    ciphertext "" |> should equal ""

[<Fact(Skip = "Remove to run test")>]
let ``Lowercase`` () =
    ciphertext "A" |> should equal "a"

[<Fact(Skip = "Remove to run test")>]
let ``Remove spaces`` () =
    ciphertext "  b " |> should equal "b"

[<Fact(Skip = "Remove to run test")>]
let ``Remove punctuation`` () =
    ciphertext "@1,%!" |> should equal "1"

[<Fact(Skip = "Remove to run test")>]
let ``9 character plaintext results in 3 chunks of 3 characters`` () =
    ciphertext "This is fun!" |> should equal "tsf hiu isn"

[<Fact(Skip = "Remove to run test")>]
let ``8 character plaintext results in 3 chunks, the last one with a trailing space`` () =
    ciphertext "Chill out." |> should equal "clu hlt io "

[<Fact(Skip = "Remove to run test")>]
let ``54 character plaintext results in 7 chunks, the last two with trailing spaces`` () =
    ciphertext "If man was meant to stay on the ground, god would have given us roots." |> should equal "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn  sseoau "

