source("./linked-list.R")
library(testthat)
test_that("Push and pop are first in last out order", {
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    let val1 = pop linkedList
    let val2 = pop linkedList

  expect_equal(val1, 20)
  expect_equal(val2, 10)
})

test_that("Push and shift are first in first out order", {
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    let val1 = shift linkedList
    let val2 = shift linkedList

  expect_equal(val1, 10)
  expect_equal(val2, 20)
})

test_that("Unshift and shift are last in first out order", {
    let linkedList = mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20

    let val1 = shift linkedList
    let val2 = shift linkedList

  expect_equal(val1, 20)
  expect_equal(val2, 10)
})

test_that("Unshift and pop are last in last out order", {
    let linkedList = mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20

    let val1 = pop linkedList
    let val2 = pop linkedList

  expect_equal(val1, 10)
  expect_equal(val2, 20)
})

test_that("Push and pop can handle multiple values", {
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20
    linkedList |> push 30

    let val1 = pop linkedList
    let val2 = pop linkedList
    let val3 = pop linkedList

  expect_equal(val1, 30)
  expect_equal(val2, 20)
  expect_equal(val3, 10)
})

test_that("Unshift and shift can handle multiple values", {
    let linkedList = mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20
    linkedList |> unshift 30

    let val1 = shift linkedList
    let val2 = shift linkedList
    let val3 = shift linkedList

  expect_equal(val1, 30)
  expect_equal(val2, 20)
  expect_equal(val3, 10)
})

test_that("All methods of manipulating the linkedList can be used together", {
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    let val1 = pop linkedList

  expect_equal(val1, 20)

    linkedList |> push 30
    let val2 = shift linkedList

  expect_equal(val2, 10)

    linkedList |> unshift 40
    linkedList |> push 50

    let val3 = shift linkedList
    let val4 = pop linkedList
    let val5 = shift linkedList

  expect_equal(val3, 40)
  expect_equal(val4, 50)
  expect_equal(val5, 30)