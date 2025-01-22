source("./diffie-hellman.R")
library(testthat)

let ``Private key is greater than 1 and less than p`` () =
    p <- 7919I
    privateKeys <- [for _ in 0 .. 10 -> privateKey p]
    privateKeys |> List.iter (fun x -> x |> should be (greaterThan 1I))
    privateKeys |> List.iter (fun x -> x |> should be (lessThan p))

let ``Private key is random`` () =
    p <- 7919I
    privateKeys <- [for _ in 0 .. 10 -> privateKey p]
    List.distinct privateKeys |> List.length |> should equal (List.length privateKeys)

let ``Can calculate public key using private key`` () =
    p <- 23I
    g <- 5I
    privateKey <- 6I
    publicKey p g privateKey |> should equal 8I

let ``Can calculate public key when given a different private key`` () =
    p <- 23I
    g <- 5I
    privateKey <- 15I
    publicKey p g privateKey |> should equal 19I

let ``Can calculate secret using other party's public key`` () =
    p <- 23I
    theirPublicKey <- 19I
    myPrivateKey <- 6I
    secret p theirPublicKey myPrivateKey |> should equal 2I

let ``Key exchange`` () =
    p <- 23I
    g <- 5I
    alicePrivateKey <- privateKey p
    alicePublicKey <- publicKey p g alicePrivateKey
    bobPrivateKey <- privateKey p
    bobPublicKey <- publicKey p g bobPrivateKey
    secretA <- secret p bobPublicKey alicePrivateKey
    secretB <- secret p alicePublicKey bobPrivateKey
    secretA |> should equal secretB

