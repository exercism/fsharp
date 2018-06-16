// This file was auto-generated based on version 1.0.0 of the canonical data.

module SimpleCipherTest

open FsUnit.Xunit
open Xunit
open System.Text.RegularExpressions
open System

open SimpleCipher

[<Fact>]
let ``Random key cipher - Can encode`` () =
    let sut = SimpleCipher()
    sut.Encode("aaaaaaaaaa") |> should equal sut.Key.[0..9]

[<Fact(Skip = "Remove to run test")>]
let ``Random key cipher - Can decode`` () =
    let sut = SimpleCipher()
    sut.Decode(sut.Key.[0..9]) |> should equal "aaaaaaaaaa"

[<Fact(Skip = "Remove to run test")>]
let ``Random key cipher - Is reversible. I.e., if you apply decode in a encoded result, you must see the same plaintext encode parameter as a result of the decode method`` () =
    let sut = SimpleCipher()
    sut.Decode(sut.Encode("abcdefghij")) |> should equal "abcdefghij"

[<Fact(Skip = "Remove to run test")>]
let ``Random key cipher - Key is made only of lowercase letters`` () =
    let sut = SimpleCipher()
    Regex.IsMatch(sut.Key, "^[a-z]+$") |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Substitution cipher - Can encode`` () =
    let sut = SimpleCipher("abcdefghij")
    sut.Encode("aaaaaaaaaa") |> should equal "abcdefghij"

[<Fact(Skip = "Remove to run test")>]
let ``Substitution cipher - Can decode`` () =
    let sut = SimpleCipher("abcdefghij")
    sut.Decode("abcdefghij") |> should equal "aaaaaaaaaa"

[<Fact(Skip = "Remove to run test")>]
let ``Substitution cipher - Is reversible. I.e., if you apply decode in a encoded result, you must see the same plaintext encode parameter as a result of the decode method`` () =
    let sut = SimpleCipher("abcdefghij")
    sut.Decode(sut.Encode("abcdefghij")) |> should equal "abcdefghij"

[<Fact(Skip = "Remove to run test")>]
let ``Substitution cipher - Can double shift encode`` () =
    let sut = SimpleCipher("iamapandabear")
    sut.Encode("iamapandabear") |> should equal "qayaeaagaciai"

[<Fact(Skip = "Remove to run test")>]
let ``Substitution cipher - Can wrap on encode`` () =
    let sut = SimpleCipher("abcdefghij")
    sut.Encode("zzzzzzzzzz") |> should equal "zabcdefghi"

[<Fact(Skip = "Remove to run test")>]
let ``Substitution cipher - Can wrap on decode`` () =
    let sut = SimpleCipher("abcdefghij")
    sut.Decode("zabcdefghi") |> should equal "zzzzzzzzzz"

[<Fact(Skip = "Remove to run test")>]
let ``Substitution cipher - Can handle messages longer than the key`` () =
    let sut = SimpleCipher("abc")
    sut.Encode("iamapandabear") |> should equal "iboaqcnecbfcr"

[<Fact(Skip = "Remove to run test")>]
let ``Incorrect key cipher - Throws an error with an all uppercase key`` () =
    (fun () -> SimpleCipher("ABCDEF") |> ignore) |> should throw typeof<ArgumentException>

[<Fact(Skip = "Remove to run test")>]
let ``Incorrect key cipher - Throws an error with a numeric key`` () =
    (fun () -> SimpleCipher("12345") |> ignore) |> should throw typeof<ArgumentException>

[<Fact(Skip = "Remove to run test")>]
let ``Incorrect key cipher - Throws an error with empty key`` () =
    (fun () -> SimpleCipher("") |> ignore) |> should throw typeof<ArgumentException>

