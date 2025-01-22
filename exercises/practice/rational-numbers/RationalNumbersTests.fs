source("./rational-numbers.R")
library(testthat)

test_that("Add two positive rational numbers", {
  expect_equal(add (create 1 2) (create 2 3), (create 7 6))
})

test_that("Add a positive rational number and a negative rational number", {
  expect_equal(add (create 1 2) (create -2 3), (create -1 6))
})

test_that("Add two negative rational numbers", {
  expect_equal(add (create -1 2) (create -2 3), (create -7 6))
})

test_that("Add a rational number to its additive inverse", {
  expect_equal(add (create 1 2) (create -1 2), (create 0 1))
})

test_that("Subtract two positive rational numbers", {
  expect_equal(sub (create 1 2) (create 2 3), (create -1 6))
})

test_that("Subtract a positive rational number and a negative rational number", {
  expect_equal(sub (create 1 2) (create -2 3), (create 7 6))
})

test_that("Subtract two negative rational numbers", {
  expect_equal(sub (create -1 2) (create -2 3), (create 1 6))
})

test_that("Subtract a rational number from itself", {
  expect_equal(sub (create 1 2) (create 1 2), (create 0 1))
})

test_that("Multiply two positive rational numbers", {
  expect_equal(mul (create 1 2) (create 2 3), (create 1 3))
})

test_that("Multiply a negative rational number by a positive rational number", {
  expect_equal(mul (create -1 2) (create 2 3), (create -1 3))
})

test_that("Multiply two negative rational numbers", {
  expect_equal(mul (create -1 2) (create -2 3), (create 1 3))
})

test_that("Multiply a rational number by its reciprocal", {
  expect_equal(mul (create 1 2) (create 2 1), (create 1 1))
})

test_that("Multiply a rational number by 1", {
  expect_equal(mul (create 1 2) (create 1 1), (create 1 2))
})

test_that("Multiply a rational number by 0", {
  expect_equal(mul (create 1 2) (create 0 1), (create 0 1))
})

test_that("Divide two positive rational numbers", {
  expect_equal(div (create 1 2) (create 2 3), (create 3 4))
})

test_that("Divide a positive rational number by a negative rational number", {
  expect_equal(div (create 1 2) (create -2 3), (create -3 4))
})

test_that("Divide two negative rational numbers", {
  expect_equal(div (create -1 2) (create -2 3), (create 3 4))
})

test_that("Divide a rational number by 1", {
  expect_equal(div (create 1 2) (create 1 1), (create 1 2))
})

test_that("Absolute value of a positive rational number", {
  expect_equal(abs (create 1 2), (create 1 2))
})

test_that("Absolute value of a positive rational number with negative numerator and denominator", {
  expect_equal(abs (create -1 -2), (create 1 2))
})

test_that("Absolute value of a negative rational number", {
  expect_equal(abs (create -1 2), (create 1 2))
})

test_that("Absolute value of a negative rational number with negative denominator", {
  expect_equal(abs (create 1 -2), (create 1 2))
})

test_that("Absolute value of zero", {
  expect_equal(abs (create 0 1), (create 0 1))
})

test_that("Absolute value of a rational number is reduced to lowest terms", {
  expect_equal(abs (create 2 4), (create 1 2))
})

test_that("Raise a positive rational number to a positive integer power", {
  expect_equal(exprational 3 (create 1 2), (create 1 8))
})

test_that("Raise a negative rational number to a positive integer power", {
  expect_equal(exprational 3 (create -1 2), (create -1 8))
})

test_that("Raise a positive rational number to a negative integer power", {
  expect_equal(exprational -2 (create 3 5), (create 25 9))
})

test_that("Raise a negative rational number to an even negative integer power", {
  expect_equal(exprational -2 (create -3 5), (create 25 9))
})

test_that("Raise a negative rational number to an odd negative integer power", {
  expect_equal(exprational -3 (create -3 5), (create -125 27))
})

test_that("Raise zero to an integer power", {
  expect_equal(exprational 5 (create 0 1), (create 0 1))
})

test_that("Raise one to an integer power", {
  expect_equal(exprational 4 (create 1 1), (create 1 1))
})

test_that("Raise a positive rational number to the power of zero", {
  expect_equal(exprational 0 (create 1 2), (create 1 1))
})

test_that("Raise a negative rational number to the power of zero", {
  expect_equal(exprational 0 (create -1 2), (create 1 1))
})

test_that("Raise a real number to a positive rational number", {
    expreal (create 4 3) 8 |> should (equalWithin 0.01) 16

test_that("Raise a real number to a negative rational number", {
    expreal (create -1 2) 9 |> should (equalWithin 0.01) 0.3333333333333333

test_that("Raise a real number to a zero rational number", {
    expreal (create 0 1) 2 |> should (equalWithin 0.01) 1

test_that("Reduce a positive rational number to lowest terms", {
  expect_equal(reduce (create 2 4), (create 1 2))
})

test_that("Reduce places the minus sign on the numerator", {
  expect_equal(reduce (create 3 -4), (create -3 4))
})

test_that("Reduce a negative rational number to lowest terms", {
  expect_equal(reduce (create -4 6), (create -2 3))
})

test_that("Reduce a rational number with a negative denominator to lowest terms", {
  expect_equal(reduce (create 3 -9), (create -1 3))
})

test_that("Reduce zero to lowest terms", {
  expect_equal(reduce (create 0 6), (create 0 1))
})

test_that("Reduce an integer to lowest terms", {
  expect_equal(reduce (create -14 7), (create -2 1))
})

test_that("Reduce one to lowest terms", {
  expect_equal(reduce (create 13 13), (create 1 1))
})
