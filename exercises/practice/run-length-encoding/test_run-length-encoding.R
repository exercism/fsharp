source("./run-length-encoding.R")
library(testthat)

test_that("Encode empty string", {
    encode "" |> should equal ""
})

test_that("Encode single characters only are encoded without count", {
    encode "XYZ" |> should equal "XYZ"
})

test_that("Encode string with no single characters", {
    encode "AABBBCCCC" |> should equal "2A3B4C"
})

test_that("Encode single characters mixed with repeated characters", {
    encode "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB" |> should equal "12WB12W3B24WB"
})

test_that("Encode multiple whitespace mixed in string", {
    encode "  hsqq qww  " |> should equal "2 hs2q q2w2 "
})

test_that("Encode lowercase characters", {
    encode "aabbbcccc" |> should equal "2a3b4c"
})

test_that("Decode empty string", {
    decode "" |> should equal ""
})

test_that("Decode single characters only", {
    decode "XYZ" |> should equal "XYZ"
})

test_that("Decode string with no single characters", {
    decode "2A3B4C" |> should equal "AABBBCCCC"
})

test_that("Decode single characters with repeated characters", {
    decode "12WB12W3B24WB" |> should equal "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"
})

test_that("Decode multiple whitespace mixed in string", {
    decode "2 hs2q q2w2 " |> should equal "  hsqq qww  "
})

test_that("Decode lowercase string", {
    decode "2a3b4c" |> should equal "aabbbcccc"
})

test_that("Encode followed by decode gives original string", {
    "zzz ZZ  zZ" |> encode |> decode |> should equal "zzz ZZ  zZ"

