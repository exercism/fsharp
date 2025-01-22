source("./pangram.R")
library(testthat)

test_that("Empty sentence", {
    expect_equal(isPangram "", false)

test_that("Perfect lower case", {
    expect_equal(isPangram "abcdefghijklmnopqrstuvwxyz", true)

test_that("Only lower case", {
    expect_equal(isPangram "the quick brown fox jumps over the lazy dog", true)

test_that("Missing the letter 'x'", {
    expect_equal(isPangram "a quick movement of the enemy will jeopardize five gunboats", false)

test_that("Missing the letter 'h'", {
    expect_equal(isPangram "five boxing wizards jump quickly at it", false)

test_that("With underscores", {
    expect_equal(isPangram "the_quick_brown_fox_jumps_over_the_lazy_dog", true)

test_that("With numbers", {
    expect_equal(isPangram "the 1 quick brown fox jumps over the 2 lazy dogs", true)

test_that("Missing letters replaced by numbers", {
    expect_equal(isPangram "7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog", false)

test_that("Mixed case and punctuation", {
    expect_equal(isPangram "\"Five quacking Zephyrs jolt my wax bed.\"", true)

test_that("A-m and A-M are 26 different characters but not a pangram", {
    expect_equal(isPangram "abcdefghijklm ABCDEFGHIJKLM", false)

