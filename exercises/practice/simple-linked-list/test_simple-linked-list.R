source("./simple-linked-list.R")
library(testthat)

test_that("Empty list", {
    let list = nil
  expect_equal(isNil list, true)
})

test_that("Single item list value", {
    let list = create 1 nil
  expect_equal(datum list, 1)
        

test_that("Single item list has no next item", {
    let list = create 1 nil
  expect_equal(next list |> isNil, true)
        

test_that("Two item list first value", {
    let list = create 2 (create 1 nil)
  expect_equal(datum list, 2)
    

test_that("Two item list second value", {
    let list = create 2 (create 1 nil)
  expect_equal(next list |> datum, 1)
    

test_that("Two item list second item has no next", {
    let list = create 2 (create 1 nil)
  expect_equal(next list |> next |> isNil, true)
        

test_that("To list", {
    let values = create 2 (create 1 nil) |> toList
  expect_equal(values, [2; 1])
        

test_that("From list", {
    let list = fromList [11; 7; 5; 3; 2]
  expect_equal(list |> datum, 11)
  expect_equal(list |> next |> datum, 7)
  expect_equal(list |> next |> next |> datum, 5)
  expect_equal(list |> next |> next |> next |> datum, 3)
  expect_equal(list |> next |> next |> next |> next |> datum, 2)
})

test_that("Reverse length 1", {
    let values = [1..1]
    let list = fromList values
    let reversed = reverse list
  expect_equal(reversed |> toList, <| List.rev values)
})

test_that("Reverse length 2", {
    let values = [1..2]
    let list = fromList values
    let reversed = reverse list
  expect_equal(reversed |> toList, <| List.rev values )
})

test_that("Reverse length 10", {
    let values = [1..10]
    let list = fromList values
    let reversed = reverse list
  expect_equal(reversed |> toList, <| List.rev values )
})

test_that("Reverse length 100", {
    let values = [1..100]
    let list = fromList values
    let reversed = reverse list
  expect_equal(reversed |> toList, <| List.rev values )
})

test_that("Roundtrip length 1", {
    let values = [1..1]
    let listValues = fromList values
  expect_equal(listValues |> toList, values)
})

test_that("Roundtrip length 2", {
    let values = [1..2]
    let listValues = fromList values
  expect_equal(listValues |> toList, values)
})

test_that("Roundtrip length 10", {
    let values = [1..10]
    let listValues = fromList values
  expect_equal(listValues |> toList, values)
})

test_that("Roundtrip length 100", {
    let values = [1..100]
    let listValues = fromList values
  expect_equal(listValues |> toList, values)
