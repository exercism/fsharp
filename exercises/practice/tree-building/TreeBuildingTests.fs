// This file was created manually and its version is 2.0.0.

source("./tree-building-test.R")
library(testthat)

test_that("One node", {
    input <-
        [
            { RecordId = 0, ParentId = 0 }
        ]

    tree <- buildTree input

  expect_false(isBranch tree)
  expect_equal(recordId(tree), 0)
    children tree |> should be Empty

test_that("Three nodes in order", {
    input <-
        [
            { RecordId = 0, ParentId = 0 };
            { RecordId = 1, ParentId = 0 };
            { RecordId = 2, ParentId = 0 };
        ]

    tree <- buildTree input

  expect_true(isBranch tree)
  expect_equal(recordId(tree), 0)
  expect_equal(children tree |> List.length, 2)

  expect_false(children tree |> List.item 0 |> isBranch)
  expect_equal(children tree |> List.item 0 |> recordId, 1)

  expect_false(children tree |> List.item 1 |> isBranch)
  expect_equal(children tree |> List.item 1 |> recordId, 2)
})

test_that("Three nodes in reverse order", {
    input <-
        [
            { RecordId = 2, ParentId = 0 };
            { RecordId = 1, ParentId = 0 };
            { RecordId = 0, ParentId = 0 };
        ]

    tree <- buildTree input

  expect_true(isBranch tree)
  expect_equal(recordId(tree), 0)
  expect_equal(children tree |> List.length, 2)

  expect_false(children tree |> List.item 0 |> isBranch)
  expect_equal(children tree |> List.item 0 |> recordId, 1)

  expect_false(children tree |> List.item 1 |> isBranch)
  expect_equal(children tree |> List.item 1 |> recordId, 2)
})

test_that("More than two children", {
    input <-
        [
            { RecordId = 3, ParentId = 0 };
            { RecordId = 2, ParentId = 0 };
            { RecordId = 1, ParentId = 0 };
            { RecordId = 0, ParentId = 0 };
        ]

    tree <- buildTree input

  expect_true(isBranch tree)
  expect_equal(recordId(tree), 0)
  expect_equal(children tree |> List.length, 3)

  expect_false(children tree |> List.item 0 |> isBranch)
  expect_equal(children tree |> List.item 0 |> recordId, 1)

  expect_false(children tree |> List.item 1 |> isBranch)
  expect_equal(children tree |> List.item 1 |> recordId, 2)

  expect_false(children tree |> List.item 2 |> isBranch)
  expect_equal(children tree |> List.item 2 |> recordId, 3)
})

test_that("Binary tree", {
    input <-
        [
            { RecordId = 5, ParentId = 1 };
            { RecordId = 3, ParentId = 2 };
            { RecordId = 2, ParentId = 0 };
            { RecordId = 4, ParentId = 1 };
            { RecordId = 1, ParentId = 0 };
            { RecordId = 0, ParentId = 0 };
            { RecordId = 6, ParentId = 2 }
        ]

    tree <- buildTree input

  expect_true(isBranch tree)
  expect_equal(recordId(tree), 0)
  expect_equal(children tree |> List.length, 2)

  expect_true(children tree |> List.item 0 |> isBranch)
  expect_equal(children tree |> List.item 0 |> recordId, 1)
  expect_equal(children tree |> List.item 0 |> children |> List.length, 2)

  expect_false(children tree |> List.item 0 |> children |> List.item 0 |> isBranch)
  expect_equal(children tree |> List.item 0 |> children |> List.item 0 |> recordId, 4)

  expect_false(children tree |> List.item 0 |> children |> List.item 1 |> isBranch)
  expect_equal(children tree |> List.item 0 |> children |> List.item 1 |> recordId, 5)

  expect_true(children tree |> List.item 1 |> isBranch)
  expect_equal(children tree |> List.item 1 |> recordId, 2)
  expect_equal(children tree |> List.item 1 |> children |> List.length, 2)

  expect_false(children tree |> List.item 1 |> children |> List.item 0 |> isBranch)
  expect_equal(children tree |> List.item 1 |> children |> List.item 0 |> recordId, 3)

  expect_false(children tree |> List.item 1 |> children |> List.item 1 |> isBranch)
  expect_equal(children tree |> List.item 1 |> children |> List.item 1 |> recordId, 6)
})

test_that("Unbalanced tree", {
    input <-
        [
            { RecordId = 5, ParentId = 2 };
            { RecordId = 3, ParentId = 2 };
            { RecordId = 2, ParentId = 0 };
            { RecordId = 4, ParentId = 1 };
            { RecordId = 1, ParentId = 0 };
            { RecordId = 0, ParentId = 0 };
            { RecordId = 6, ParentId = 2 }
        ]

    tree <- buildTree input

  expect_true(isBranch tree)
  expect_equal(recordId(tree), 0)
  expect_equal(children tree |> List.length, 2)

  expect_true(children tree |> List.item 0 |> isBranch)
  expect_equal(children tree |> List.item 0 |> recordId, 1)
  expect_equal(children tree |> List.item 0 |> children |> List.length, 1)

  expect_false(children tree |> List.item 0 |> children |> List.item 0 |> isBranch)
  expect_equal(children tree |> List.item 0 |> children |> List.item 0 |> recordId, 4)

  expect_true(children tree |> List.item 1 |> isBranch)
  expect_equal(children tree |> List.item 1 |> recordId, 2)
  expect_equal(children tree |> List.item 1 |> children |> List.length, 3)

  expect_false(children tree |> List.item 1 |> children |> List.item 0 |> isBranch)
  expect_equal(children tree |> List.item 1 |> children |> List.item 0 |> recordId, 3)

  expect_false(children tree |> List.item 1 |> children |> List.item 1 |> isBranch)
  expect_equal(children tree |> List.item 1 |> children |> List.item 1 |> recordId, 5)

  expect_false(children tree |> List.item 1 |> children |> List.item 2 |> isBranch)
  expect_equal(children tree |> List.item 1 |> children |> List.item 2 |> recordId, 6)
})

test_that("Empty input", {
    input <- []
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

test_that("Root node has parent", {
    input <-
        [ { RecordId = 0, ParentId = 1 };
          { RecordId = 1, ParentId = 0 } ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

test_that("No root node", {
    input <- c( { RecordId = 1, ParentId = 0 } )
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

test_that("Out of bounds record id", {
    input <-
        [
            { RecordId = 2, ParentId = 0 };
            { RecordId = 4, ParentId = 2 };
            { RecordId = 1, ParentId = 0 };
            { RecordId = 0, ParentId = 0 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

test_that("Cycle directly", {
    input <-
        [
            { RecordId = 5, ParentId = 2 };
            { RecordId = 3, ParentId = 2 };
            { RecordId = 2, ParentId = 2 };
            { RecordId = 4, ParentId = 1 };
            { RecordId = 1, ParentId = 0 };
            { RecordId = 0, ParentId = 0 };
            { RecordId = 6, ParentId = 3 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

test_that("Cycle indirectly", {
    input <-
        [
            { RecordId = 5, ParentId = 2 };
            { RecordId = 3, ParentId = 2 };
            { RecordId = 2, ParentId = 6 };
            { RecordId = 4, ParentId = 1 };
            { RecordId = 1, ParentId = 0 };
            { RecordId = 0, ParentId = 0 };
            { RecordId = 6, ParentId = 3 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

test_that("Higher id parent of lower id", {
    input <-
        [
            { RecordId = 0, ParentId = 0 };
            { RecordId = 2, ParentId = 0 };
            { RecordId = 1, ParentId = 2 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>
