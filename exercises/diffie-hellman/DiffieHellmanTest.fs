// This file was auto-generated based on version 1.0.0 of the canonical data.

module DiffieHellmanTest

open FsUnit.Xunit
open Xunit

open DiffieHellman

[<Fact>]
let ``Private key is in range 1 .. p`` () =
    let p = 7919I
    let privateKeys = [for _ in 0 .. 10 -> privateKey p]
    privateKeys |> List.iter (fun x -> x |> should be (greaterThan 1I))
    privateKeys |> List.iter (fun x -> x |> should be (lessThan p))

[<Fact(Skip = "Remove to run test")>]
let ``Private key is random`` () =
    let p = 7919I
    let privateKeys = [for _ in 0 .. 10 -> privateKey p]
    List.distinct privateKeys |> List.length |> should equal (List.length privateKeys)

[<Fact(Skip = "Remove to run test")>]
let ``Can calculate public key using private key`` () =
    let p = 23I
    let g = 5I
    let privateKey = 6I
    publicKey p g privateKey |> should equal 8I

[<Fact(Skip = "Remove to run test")>]
let ``Can calculate secret using other party's public key`` () =
    let p = 23I
    let theirPublicKey = 19I
    let myPrivateKey = 6I
    secret p theirPublicKey myPrivateKey |> should equal 2I

[<Fact(Skip = "Remove to run test")>]
let ``Key exchange`` () =
    let p = 23I
    let g = 5I
    let alicePrivateKey = privateKey p
    let alicePublicKey = publicKey p g alicePrivateKey
    let bobPrivateKey = privateKey p
    let bobPublicKey = publicKey p g bobPrivateKey
    let secretA = secret p bobPublicKey alicePrivateKey
    let secretB = secret p alicePublicKey bobPrivateKey
    secretA |> should equal secretB

