source("./collatz-conjecture.R")
library(testthat)




test_that("Zero steps for one", {
    steps 1 |> should equal (Some 0)


test_that("Divide if even", {
    steps 16 |> should equal (Some 4)


test_that("Even and odd steps", {
    steps 12 |> should equal (Some 9)


test_that("Large number of even and odd steps", {
    steps 1000000 |> should equal (Some 152)


test_that("Zero is an error", {
    steps 0 |> should equal None


test_that("Negative value is an error", {
    steps -15 |> should equal None

