source("./complex-numbers.R")
library(testthat)

test_that("Real part of a purely real number", {
  expect_equal(real (create 1.0 0.0), 1.0)
})

test_that("Real part of a purely imaginary number", {
  expect_equal(real (create 0.0 1.0), 0.0)
})

test_that("Real part of a number with real and imaginary part", {
  expect_equal(real (create 1.0 2.0), 1.0)
})

test_that("Imaginary part of a purely real number", {
  expect_equal(imaginary (create 1.0 0.0), 0.0)
})

test_that("Imaginary part of a purely imaginary number", {
  expect_equal(imaginary (create 0.0 1.0), 1.0)
})

test_that("Imaginary part of a number with real and imaginary part", {
  expect_equal(imaginary (create 1.0 2.0), 2.0)
})

test_that("Imaginary unit", {
  sut <- mul (create 0.0 1.0) (create 0.0 1.0)
    real sut |> should (equalWithin 0.01) -1.0
    imaginary sut |> should (equalWithin 0.01) 0.0

test_that("Add purely real numbers", {
  sut <- add (create 1.0 0.0) (create 2.0 0.0)
    real sut |> should (equalWithin 0.01) 3.0
    imaginary sut |> should (equalWithin 0.01) 0.0

test_that("Add purely imaginary numbers", {
  sut <- add (create 0.0 1.0) (create 0.0 2.0)
    real sut |> should (equalWithin 0.01) 0.0
    imaginary sut |> should (equalWithin 0.01) 3.0

test_that("Add numbers with real and imaginary part", {
  sut <- add (create 1.0 2.0) (create 3.0 4.0)
    real sut |> should (equalWithin 0.01) 4.0
    imaginary sut |> should (equalWithin 0.01) 6.0

test_that("Subtract purely real numbers", {
  sut <- sub (create 1.0 0.0) (create 2.0 0.0)
    real sut |> should (equalWithin 0.01) -1.0
    imaginary sut |> should (equalWithin 0.01) 0.0

test_that("Subtract purely imaginary numbers", {
  sut <- sub (create 0.0 1.0) (create 0.0 2.0)
    real sut |> should (equalWithin 0.01) 0.0
    imaginary sut |> should (equalWithin 0.01) -1.0

test_that("Subtract numbers with real and imaginary part", {
  sut <- sub (create 1.0 2.0) (create 3.0 4.0)
    real sut |> should (equalWithin 0.01) -2.0
    imaginary sut |> should (equalWithin 0.01) -2.0

test_that("Multiply purely real numbers", {
  sut <- mul (create 1.0 0.0) (create 2.0 0.0)
    real sut |> should (equalWithin 0.01) 2.0
    imaginary sut |> should (equalWithin 0.01) 0.0

test_that("Multiply purely imaginary numbers", {
  sut <- mul (create 0.0 1.0) (create 0.0 2.0)
    real sut |> should (equalWithin 0.01) -2.0
    imaginary sut |> should (equalWithin 0.01) 0.0

test_that("Multiply numbers with real and imaginary part", {
  sut <- mul (create 1.0 2.0) (create 3.0 4.0)
    real sut |> should (equalWithin 0.01) -5.0
    imaginary sut |> should (equalWithin 0.01) 10.0

test_that("Divide purely real numbers", {
  sut <- div (create 1.0 0.0) (create 2.0 0.0)
    real sut |> should (equalWithin 0.01) 0.5
    imaginary sut |> should (equalWithin 0.01) 0.0

test_that("Divide purely imaginary numbers", {
  sut <- div (create 0.0 1.0) (create 0.0 2.0)
    real sut |> should (equalWithin 0.01) 0.5
    imaginary sut |> should (equalWithin 0.01) 0.0

test_that("Divide numbers with real and imaginary part", {
  sut <- div (create 1.0 2.0) (create 3.0 4.0)
    real sut |> should (equalWithin 0.01) 0.44
    imaginary sut |> should (equalWithin 0.01) 0.08

test_that("Absolute value of a positive purely real number", {
  expect_equal(abs (create 5.0 0.0), 5.0)
})

test_that("Absolute value of a negative purely real number", {
  expect_equal(abs (create -5.0 0.0), 5.0)
})

test_that("Absolute value of a purely imaginary number with positive imaginary part", {
  expect_equal(abs (create 0.0 5.0), 5.0)
})

test_that("Absolute value of a purely imaginary number with negative imaginary part", {
  expect_equal(abs (create 0.0 -5.0), 5.0)
})

test_that("Absolute value of a number with real and imaginary part", {
  expect_equal(abs (create 3.0 4.0), 5.0)
})

test_that("Conjugate a purely real number", {
  sut <- conjugate (create 5.0 0.0)
    real sut |> should (equalWithin 0.01) 5.0
    imaginary sut |> should (equalWithin 0.01) 0.0

test_that("Conjugate a purely imaginary number", {
  sut <- conjugate (create 0.0 5.0)
    real sut |> should (equalWithin 0.01) 0.0
    imaginary sut |> should (equalWithin 0.01) -5.0

test_that("Conjugate a number with real and imaginary part", {
  sut <- conjugate (create 1.0 1.0)
    real sut |> should (equalWithin 0.01) 1.0
    imaginary sut |> should (equalWithin 0.01) -1.0

test_that("Euler's identity/formula", {
  sut <- exp (create 0.0 (Math.PI))
    real sut |> should (equalWithin 0.01) -1.0
    imaginary sut |> should (equalWithin 0.01) 0.0

test_that("Exponential of 0", {
  sut <- exp (create 0.0 0.0)
    real sut |> should (equalWithin 0.01) 1.0
    imaginary sut |> should (equalWithin 0.01) 0.0

test_that("Exponential of a purely real number", {
  sut <- exp (create 1.0 0.0)
    real sut |> should (equalWithin 0.01) (Math.E)
    imaginary sut |> should (equalWithin 0.01) 0.0

test_that("Exponential of a number with real and imaginary part", {
  sut <- exp (create (Math.Log(2.0)) (Math.PI))
    real sut |> should (equalWithin 0.01) -2.0
    imaginary sut |> should (equalWithin 0.01) 0.0

test_that("Exponential resulting in a number with real and imaginary part", {
  sut <- exp (create (Math.Log(2.0)/2.0) (Math.PI/4.0))
    real sut |> should (equalWithin 0.01) 1.0
    imaginary sut |> should (equalWithin 0.01) 1.0

