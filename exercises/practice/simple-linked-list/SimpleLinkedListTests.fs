// This file was created manually and its version is 1.0.0.

source("./simple-linked-list-test.R")
library(testthat)

test_that("Empty list", {
    list <- nil
  expect_true(isNil list)
})

test_that("Single item list value", {
    list <- create 1 nil
  expect_equal(datum(list), 1)
        
test_that("Single item list has no next item", {
    list <- create 1 nil
  expect_true(next list |> isNil)
        
test_that("Two item list first value", {
    list <- create 2 (create 1 nil)
  expect_equal(datum(list), 2)
    
test_that("Two item list second value", {
    list <- create 2 (create 1 nil)
  expect_equal(next list |> datum, 1)
    
test_that("Two item list second item has no next", {
    list <- create 2 (create 1 nil)
  expect_true(next list |> next |> isNil)
        
test_that("To list", {
    values <- create 2 (create 1 nil) |> toList
  expect_equal(values, c(2, 1))
        
test_that("From list", {
    list <- fromList c(11, 7, 5, 3, 2)
  expect_equal(list |> datum, 11)
  expect_equal(list |> next |> datum, 7)
  expect_equal(list |> next |> next |> datum, 5)
  expect_equal(list |> next |> next |> next |> datum, 3)
  expect_equal(list |> next |> next |> next |> next |> datum, 2)
})

test_that("Reverse length 1", {
    values <- c(1..1)
    list <- fromList values
    reversed <- reverse list
  expect_equal(reversed |> toList, <| List.rev values)
})

test_that("Reverse length 2", {
    values <- c(1..2)
    list <- fromList values
    reversed <- reverse list
  expect_equal(reversed |> toList, <| List.rev values )
})

test_that("Reverse length 10", {
    values <- c(1..10)
    list <- fromList values
    reversed <- reverse list
  expect_equal(reversed |> toList, <| List.rev values )
})

test_that("Reverse length 100", {
    values <- c(1..100)
    list <- fromList values
    reversed <- reverse list
  expect_equal(reversed |> toList, <| List.rev values )
})

test_that("Roundtrip length 1", {
    values <- c(1..1)
    listValues <- fromList values
  expect_equal(listValues |> toList, values)
})

test_that("Roundtrip length 2", {
    values <- c(1..2)
    listValues <- fromList values
  expect_equal(listValues |> toList, values)
})

test_that("Roundtrip length 10", {
    values <- c(1..10)
    listValues <- fromList values
  expect_equal(listValues |> toList, values)
})

test_that("Roundtrip length 100", {
    values <- c(1..100)
    listValues <- fromList values
  expect_equal(listValues |> toList, values)
