source("./rotational-cipher.R")
library(testthat)




test_that("Rotate a by 0, same output as input", {
    rotate 0 "a" |> should equal "a"


test_that("Rotate a by 1", {
    rotate 1 "a" |> should equal "b"


test_that("Rotate a by 26, same output as input", {
    rotate 26 "a" |> should equal "a"


test_that("Rotate m by 13", {
    rotate 13 "m" |> should equal "z"


test_that("Rotate n by 13 with wrap around alphabet", {
    rotate 13 "n" |> should equal "a"


test_that("Rotate capital letters", {
    rotate 5 "OMG" |> should equal "TRL"


test_that("Rotate spaces", {
    rotate 5 "O M G" |> should equal "T R L"


test_that("Rotate numbers", {
    rotate 4 "Testing 1 2 3 testing" |> should equal "Xiwxmrk 1 2 3 xiwxmrk"


test_that("Rotate punctuation", {
    rotate 21 "Let's eat, Grandma!" |> should equal "Gzo'n zvo, Bmviyhv!"


test_that("Rotate all letters", {
    rotate 13 "The quick brown fox jumps over the lazy dog." |> should equal "Gur dhvpx oebja sbk whzcf bire gur ynml qbt."

