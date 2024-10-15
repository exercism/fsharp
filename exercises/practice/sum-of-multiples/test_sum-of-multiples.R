source("./sum-of-multiples.R")
library(testthat)




test_that("No multiples within limit", {
    sum [3; 5] 1 |> should equal 0


test_that("One factor has multiples within limit", {
    sum [3; 5] 4 |> should equal 3


test_that("More than one multiple within limit", {
    sum [3] 7 |> should equal 9


test_that("More than one factor with multiples within limit", {
    sum [3; 5] 10 |> should equal 23


test_that("Each multiple is only counted once", {
    sum [3; 5] 100 |> should equal 2318


test_that("A much larger limit", {
    sum [3; 5] 1000 |> should equal 233168


test_that("Three factors", {
    sum [7; 13; 17] 20 |> should equal 51


test_that("Factors not relatively prime", {
    sum [4; 6] 15 |> should equal 30


test_that("Some pairs of factors relatively prime and some not", {
    sum [5; 6; 8] 150 |> should equal 4419


test_that("One factor is a multiple of another", {
    sum [5; 25] 51 |> should equal 275


test_that("Much larger factors", {
    sum [43; 47] 10000 |> should equal 2203160


test_that("All numbers are multiples of 1", {
    sum [1] 100 |> should equal 4950


test_that("No factors means an empty sum", {
    sum [] 10000 |> should equal 0


test_that("The only multiple of 0 is 0", {
    sum [0] 1 |> should equal 0


test_that("The factor 0 does not affect the sum of multiples of other factors", {
    sum [3; 0] 4 |> should equal 3


test_that("Solutions using include-exclude must extend to cardinality greater than 3", {
    sum [2; 3; 5; 7; 11] 10000 |> should equal 39614537

