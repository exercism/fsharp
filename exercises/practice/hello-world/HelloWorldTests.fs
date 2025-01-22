source("./hello-world.R")
library(testthat)

test_that("Say Hi!", {
  expect_equal(hello, "Hello, World!")
})
