// This file was auto-generated based on version 2.0.0 of the canonical data.

module CryptoSquareTest

open FsUnit.Xunit
open Xunit

open CryptoSquare

[<Fact>]
let ``Lowercase`` () =
    normalizedPlaintext "Hello" |> should equal "hello"

[<Fact(Skip = "Remove to run test")>]
let ``Remove spaces`` () =
    normalizedPlaintext "Hi there" |> should equal "hithere"

[<Fact(Skip = "Remove to run test")>]
let ``Remove punctuation`` () =
    normalizedPlaintext "@1, 2%, 3 Go!" |> should equal "123go"

[<Fact(Skip = "Remove to run test")>]
let ``Empty plaintext results in an empty rectangle`` () =
    plaintextSegments "" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``4 character plaintext results in an 2x2 rectangle`` () =
    plaintextSegments "Ab Cd" |> should equal ["ab"; "cd"]

[<Fact(Skip = "Remove to run test")>]
let ``9 character plaintext results in an 3x3 rectangle`` () =
    plaintextSegments "This is fun!" |> should equal ["thi"; "sis"; "fun"]

[<Fact(Skip = "Remove to run test")>]
let ``54 character plaintext results in an 8x7 rectangle`` () =
    plaintextSegments "If man was meant to stay on the ground, god would have given us roots." |> should equal ["ifmanwas"; "meanttos"; "tayonthe"; "groundgo"; "dwouldha"; "vegivenu";
 "sroots"]

[<Fact(Skip = "Remove to run test")>]
let ``Empty plaintext results in an empty encode`` () =
    encoded "" |> should equal ""

[<Fact(Skip = "Remove to run test")>]
let ``Non-empty plaintext results in the combined plaintext segments`` () =
    encoded "If man was meant to stay on the ground, god would have given us roots." |> should equal "imtgdvsfearwermayoogoanouuiontnnlvtwttddesaohghnsseoau"

[<Fact(Skip = "Remove to run test")>]
let ``Empty plaintext results in an empty ciphertext`` () =
    ciphertext "" |> should equal ""

[<Fact(Skip = "Remove to run test")>]
let ``9 character plaintext results in 3 chunks of 3 characters`` () =
    ciphertext "This is fun!" |> should equal "tsf hiu isn"

[<Fact(Skip = "Remove to run test")>]
let ``54 character plaintext results in 7 chunks, the last two padded with spaces`` () =
    ciphertext "If man was meant to stay on the ground, god would have given us roots." |> should equal "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn  sseoau "

