source("./run-length-encoding.R")
library(testthat)

test_that("Encode empty string", {
    expect_equal(encode "", "")

test_that("Encode single characters only are encoded without count", {
    expect_equal(encode "XYZ", "XYZ")

test_that("Encode string with no single characters", {
    expect_equal(encode "AABBBCCCC", "2A3B4C")

test_that("Encode single characters mixed with repeated characters", {
    expect_equal(encode "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB", "12WB12W3B24WB")

test_that("Encode multiple whitespace mixed in string", {
    expect_equal(encode "  hsqq qww  ", "2 hs2q q2w2 ")

test_that("Encode lowercase characters", {
    expect_equal(encode "aabbbcccc", "2a3b4c")

test_that("Decode empty string", {
    expect_equal(decode "", "")

test_that("Decode single characters only", {
    expect_equal(decode "XYZ", "XYZ")

test_that("Decode string with no single characters", {
    expect_equal(decode "2A3B4C", "AABBBCCCC")

test_that("Decode single characters with repeated characters", {
    expect_equal(decode "12WB12W3B24WB", "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB")

test_that("Decode multiple whitespace mixed in string", {
    expect_equal(decode "2 hs2q q2w2 ", "  hsqq qww  ")

test_that("Decode lowercase string", {
    expect_equal(decode "2a3b4c", "aabbbcccc")

test_that("Encode followed by decode gives original string", {
    expect_equal("zzz ZZ  zZ" |> encode |> decode, "zzz ZZ  zZ")

