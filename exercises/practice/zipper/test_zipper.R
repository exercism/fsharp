source("./zipper.R")
library(testthat)



let subTree value left right = Some (tree value left right)
let leaf value = subTree value None None
})

test_that("Data is retained", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- tree 1 (subTree 2 None (leaf 3)) (leaf 4)
    let actual = zipper |> toTree
  expect_equal(actual, expected)
})

test_that("Left, right and value", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- 3
    let actual = zipper |> left |> Option.get |> right |> Option.get |> value
  expect_equal(actual, expected)
})

test_that("Dead end", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- None
    let actual = zipper |> left |> Option.get |> left
  expect_equal(actual, expected)
})

test_that("Tree from deep focus", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- tree 1 (subTree 2 None (leaf 3)) (leaf 4)
    let actual = zipper |> left |> Option.get |> right |> Option.get |> toTree
  expect_equal(actual, expected)
})

test_that("Traversing up from top", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- None
    let actual = zipper |> up
  expect_equal(actual, expected)
})

test_that("Left, right, and up", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- 3
    let actual = zipper |> left |> Option.get |> up |> Option.get |> right |> Option.get |> up |> Option.get |> left |> Option.get |> right |> Option.get |> value
  expect_equal(actual, expected)
})

test_that("Test ability to descend multiple levels and return", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- 1
    let actual = zipper |> left |> Option.get |> right |> Option.get |> up |> Option.get |> up |> Option.get |> value
  expect_equal(actual, expected)
})

test_that("Set value", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- tree 1 (subTree 5 None (leaf 3)) (leaf 4)
    let actual = zipper |> left |> Option.get |> setValue 5 |> toTree
  expect_equal(actual, expected)
})

test_that("Set value after traversing up", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- tree 1 (subTree 5 None (leaf 3)) (leaf 4)
    let actual = zipper |> left |> Option.get |> right |> Option.get |> up |> Option.get |> setValue 5 |> toTree
  expect_equal(actual, expected)
})

test_that("Set left with leaf", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- tree 1 (subTree 2 (leaf 5) (leaf 3)) (leaf 4)
    let actual = zipper |> left |> Option.get |> setLeft (Some (tree 5 None None)) |> toTree
  expect_equal(actual, expected)
})

test_that("Set right with null", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- tree 1 (leaf 2) (leaf 4)
    let actual = zipper |> left |> Option.get |> setRight None |> toTree
  expect_equal(actual, expected)
})

test_that("Set right with subtree", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- tree 1 (subTree 2 None (leaf 3)) (subTree 6 (leaf 7) (leaf 8))
    let actual = zipper |> setRight (Some (tree 6 (leaf 7) (leaf 8))) |> toTree
  expect_equal(actual, expected)
})

test_that("Set value on deep focus", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- tree 1 (subTree 2 None (leaf 5)) (leaf 4)
    let actual = zipper |> left |> Option.get |> right |> Option.get |> setValue 5 |> toTree
  expect_equal(actual, expected)
})

test_that("Different paths to same zipper", {
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
  expected <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4)) |> right
    let actual = zipper |> left |> Option.get |> up |> Option.get |> right
  expect_equal(actual, expected)
})