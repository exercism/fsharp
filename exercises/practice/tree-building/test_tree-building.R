source("./tree-building.R")
library(testthat)


test_that("One node", {
    let input =
        [
            { RecordId = 0; ParentId = 0 }
        ]

    let tree = buildTree input

  expect_equal(isBranch tree, FALSE)
  expect_equal(recordId tree, 0)
    children tree |> should be Empty
})

test_that("Three nodes in order", {
    let input =
        [
            { RecordId = 0; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
        ]

    let tree = buildTree input

  expect_equal(isBranch tree, TRUE)
  expect_equal(recordId tree, 0)
  expect_equal(children tree |> List.length, 2)

  expect_equal(children tree |> List.item 0 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 0 |> recordId, 1)

  expect_equal(children tree |> List.item 1 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 1 |> recordId, 2)
})

test_that("Three nodes in reverse order", {
    let input =
        [
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
        ]

    let tree = buildTree input

  expect_equal(isBranch tree, TRUE)
  expect_equal(recordId tree, 0)
  expect_equal(children tree |> List.length, 2)

  expect_equal(children tree |> List.item 0 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 0 |> recordId, 1)

  expect_equal(children tree |> List.item 1 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 1 |> recordId, 2)
})

test_that("More than two children", {
    let input =
        [
            { RecordId = 3; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
        ]

    let tree = buildTree input

  expect_equal(isBranch tree, TRUE)
  expect_equal(recordId tree, 0)
  expect_equal(children tree |> List.length, 3)

  expect_equal(children tree |> List.item 0 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 0 |> recordId, 1)

  expect_equal(children tree |> List.item 1 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 1 |> recordId, 2)

  expect_equal(children tree |> List.item 2 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 2 |> recordId, 3)
})

test_that("Binary tree", {
    let input =
        [
            { RecordId = 5; ParentId = 1 };
            { RecordId = 3; ParentId = 2 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 4; ParentId = 1 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
            { RecordId = 6; ParentId = 2 }
        ]

    let tree = buildTree input

  expect_equal(isBranch tree, TRUE)
  expect_equal(recordId tree, 0)
  expect_equal(children tree |> List.length, 2)

  expect_equal(children tree |> List.item 0 |> isBranch, TRUE)
  expect_equal(children tree |> List.item 0 |> recordId, 1)
  expect_equal(children tree |> List.item 0 |> children |> List.length, 2)

  expect_equal(children tree |> List.item 0 |> children |> List.item 0 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 0 |> children |> List.item 0 |> recordId, 4)

  expect_equal(children tree |> List.item 0 |> children |> List.item 1 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 0 |> children |> List.item 1 |> recordId, 5)

  expect_equal(children tree |> List.item 1 |> isBranch, TRUE)
  expect_equal(children tree |> List.item 1 |> recordId, 2)
  expect_equal(children tree |> List.item 1 |> children |> List.length, 2)

  expect_equal(children tree |> List.item 1 |> children |> List.item 0 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 1 |> children |> List.item 0 |> recordId, 3)

  expect_equal(children tree |> List.item 1 |> children |> List.item 1 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 1 |> children |> List.item 1 |> recordId, 6)
})

test_that("Unbalanced tree", {
    let input =
        [
            { RecordId = 5; ParentId = 2 };
            { RecordId = 3; ParentId = 2 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 4; ParentId = 1 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
            { RecordId = 6; ParentId = 2 }
        ]

    let tree = buildTree input

  expect_equal(isBranch tree, TRUE)
  expect_equal(recordId tree, 0)
  expect_equal(children tree |> List.length, 2)

  expect_equal(children tree |> List.item 0 |> isBranch, TRUE)
  expect_equal(children tree |> List.item 0 |> recordId, 1)
  expect_equal(children tree |> List.item 0 |> children |> List.length, 1)

  expect_equal(children tree |> List.item 0 |> children |> List.item 0 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 0 |> children |> List.item 0 |> recordId, 4)

  expect_equal(children tree |> List.item 1 |> isBranch, TRUE)
  expect_equal(children tree |> List.item 1 |> recordId, 2)
  expect_equal(children tree |> List.item 1 |> children |> List.length, 3)

  expect_equal(children tree |> List.item 1 |> children |> List.item 0 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 1 |> children |> List.item 0 |> recordId, 3)

  expect_equal(children tree |> List.item 1 |> children |> List.item 1 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 1 |> children |> List.item 1 |> recordId, 5)

  expect_equal(children tree |> List.item 1 |> children |> List.item 2 |> isBranch, FALSE)
  expect_equal(children tree |> List.item 1 |> children |> List.item 2 |> recordId, 6)
})

test_that("Empty input", {
    let input = []
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>
})

test_that("Root node has parent", {
    let input =
        [ { RecordId = 0; ParentId = 1 };
          { RecordId = 1; ParentId = 0 } ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>
})

test_that("No root node", {
    let input = [ { RecordId = 1; ParentId = 0 } ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>
})

test_that("Out of bounds record id", {
    let input =
        [
            { RecordId = 2; ParentId = 0 };
            { RecordId = 4; ParentId = 2 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>
})

test_that("Cycle directly", {
    let input =
        [
            { RecordId = 5; ParentId = 2 };
            { RecordId = 3; ParentId = 2 };
            { RecordId = 2; ParentId = 2 };
            { RecordId = 4; ParentId = 1 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
            { RecordId = 6; ParentId = 3 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>
})

test_that("Cycle indirectly", {
    let input =
        [
            { RecordId = 5; ParentId = 2 };
            { RecordId = 3; ParentId = 2 };
            { RecordId = 2; ParentId = 6 };
            { RecordId = 4; ParentId = 1 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
            { RecordId = 6; ParentId = 3 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>
})

test_that("Higher id parent of lower id", {
    let input =
        [
            { RecordId = 0; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 2 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>
