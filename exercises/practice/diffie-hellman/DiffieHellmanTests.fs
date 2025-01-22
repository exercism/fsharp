source("./diffie-hellman.R")
library(testthat)

test_that("Private key is greater than 1 and less than p", {
    p <- 7919I
    privateKeys <- [for _ in 0 .. 10 -> privateKey p]
    privateKeys |> List.iter (fun x -> x |> should be (greaterThan 1I))
    privateKeys |> List.iter (fun x -> x |> should be (lessThan p))

test_that("Private key is random", {
    p <- 7919I
    privateKeys <- [for _ in 0 .. 10 -> privateKey p]
    expect_equal(List.distinct privateKeys |> List.length, (List.length privateKeys))

test_that("Can calculate public key using private key", {
    p <- 23I
    g <- 5I
    privateKey <- 6I
    expect_equal(publicKey p g privateKey, 8I)

test_that("Can calculate public key when given a different private key", {
    p <- 23I
    g <- 5I
    privateKey <- 15I
    expect_equal(publicKey p g privateKey, 19I)

test_that("Can calculate secret using other party's public key", {
    p <- 23I
    theirPublicKey <- 19I
    myPrivateKey <- 6I
    expect_equal(secret p theirPublicKey myPrivateKey, 2I)

test_that("Key exchange", {
    p <- 23I
    g <- 5I
    alicePrivateKey <- privateKey p
    alicePublicKey <- publicKey p g alicePrivateKey
    bobPrivateKey <- privateKey p
    bobPublicKey <- publicKey p g bobPrivateKey
    secretA <- secret p bobPublicKey alicePrivateKey
    secretB <- secret p alicePublicKey bobPrivateKey
    expect_equal(secretA, secretB)

