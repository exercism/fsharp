source("./hello-world.R")
library(testthat)




test_that("Say Hi!", {
    hello |> should equal "Hello, World!"

