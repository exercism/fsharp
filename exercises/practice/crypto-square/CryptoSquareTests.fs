source("./crypto-square.R")
library(testthat)

test_that("Empty plaintext results in an empty ciphertext", {
    expect_equal(ciphertext "", "")

test_that("Lowercase", {
    expect_equal(ciphertext "A", "a")

test_that("Remove spaces", {
    expect_equal(ciphertext "  b ", "b")

test_that("Remove punctuation", {
    expect_equal(ciphertext "@1,%!", "1")

test_that("9 character plaintext results in 3 chunks of 3 characters", {
    expect_equal(ciphertext "This is fun!", "tsf hiu isn")

test_that("8 character plaintext results in 3 chunks, the last one with a trailing space", {
    expect_equal(ciphertext "Chill out.", "clu hlt io ")

test_that("54 character plaintext results in 7 chunks, the last two with trailing spaces", {
    expect_equal(ciphertext "If man was meant to stay on the ground, god would have given us roots.", "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn  sseoau ")

