source("./perfect-numbers.R")
library(testthat)




test_that("Smallest perfect number is classified correctly", {
    classify 6 |> should equal (Some Classification.Perfect)


test_that("Medium perfect number is classified correctly", {
    classify 28 |> should equal (Some Classification.Perfect)


test_that("Large perfect number is classified correctly", {
    classify 33550336 |> should equal (Some Classification.Perfect)


test_that("Smallest abundant number is classified correctly", {
    classify 12 |> should equal (Some Classification.Abundant)


test_that("Medium abundant number is classified correctly", {
    classify 30 |> should equal (Some Classification.Abundant)


test_that("Large abundant number is classified correctly", {
    classify 33550335 |> should equal (Some Classification.Abundant)


test_that("Smallest prime deficient number is classified correctly", {
    classify 2 |> should equal (Some Classification.Deficient)


test_that("Smallest non-prime deficient number is classified correctly", {
    classify 4 |> should equal (Some Classification.Deficient)


test_that("Medium deficient number is classified correctly", {
    classify 32 |> should equal (Some Classification.Deficient)


test_that("Large deficient number is classified correctly", {
    classify 33550337 |> should equal (Some Classification.Deficient)


test_that("Edge case (no factors other than itself) is classified correctly", {
    classify 1 |> should equal (Some Classification.Deficient)


test_that("Zero is rejected (as it is not a positive integer)", {
    classify 0 |> should equal None


test_that("Negative integer is rejected (as it is not a positive integer)", {
    classify -1 |> should equal None

