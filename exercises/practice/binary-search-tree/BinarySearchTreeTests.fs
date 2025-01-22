source("./binary-search-tree.R")
library(testthat)

test_that("Data is retained", {
    treeData <- create c(4)
    expect_equal(treeData |> data, 4)
    expect_equal(treeData |> left, None)
    expect_equal(treeData |> right, None)
})

test_that("Smaller number at left node", {
    treeData <- create c(4, 2)
    expect_equal(treeData |> data, 4)
    expect_equal(treeData |> left |> Option.map data, (Some 2))
    expect_equal(treeData |> left |> Option.bind left, None)
    expect_equal(treeData |> left |> Option.bind right, None)
    expect_equal(treeData |> right, None)
})

test_that("Same number at left node", {
    treeData <- create c(4, 4)
    expect_equal(treeData |> data, 4)
    expect_equal(treeData |> left |> Option.map data, (Some 4))
    expect_equal(treeData |> left |> Option.bind left, None)
    expect_equal(treeData |> left |> Option.bind right, None)
    expect_equal(treeData |> right, None)
})

test_that("Greater number at right node", {
    treeData <- create c(4, 5)
    expect_equal(treeData |> data, 4)
    expect_equal(treeData |> left, None)
    expect_equal(treeData |> right |> Option.map data, (Some 5))
    expect_equal(treeData |> right |> Option.bind left, None)
    expect_equal(treeData |> right |> Option.bind right, None)
})

test_that("Can create complex tree", {
    treeData <- create c(4, 2, 6, 1, 3, 5, 7)
    expect_equal(treeData |> data, 4)
    expect_equal(treeData |> left |> Option.map data, (Some 2))
    expect_equal(treeData |> left |> Option.bind left |> Option.map data, (Some 1))
    expect_equal(treeData |> left |> Option.bind left |> Option.bind left, None)
    expect_equal(treeData |> left |> Option.bind left |> Option.bind right, None)
    expect_equal(treeData |> left |> Option.bind right |> Option.map data, (Some 3))
    expect_equal(treeData |> left |> Option.bind right |> Option.bind left, None)
    expect_equal(treeData |> left |> Option.bind right |> Option.bind right, None)
    expect_equal(treeData |> right |> Option.map data, (Some 6))
    expect_equal(treeData |> right |> Option.bind left |> Option.map data, (Some 5))
    expect_equal(treeData |> right |> Option.bind left |> Option.bind left, None)
    expect_equal(treeData |> right |> Option.bind left |> Option.bind right, None)
    expect_equal(treeData |> right |> Option.bind right |> Option.map data, (Some 7))
    expect_equal(treeData |> right |> Option.bind right |> Option.bind left, None)
    expect_equal(treeData |> right |> Option.bind right |> Option.bind right, None)
})

test_that("Can sort single number", {
    treeData <- create c(2)
    expect_equal(sortedData treeData, c(2))
})

test_that("Can sort if second number is smaller than first", {
    treeData <- create c(2, 1)
    expect_equal(sortedData treeData, c(1, 2))
})

test_that("Can sort if second number is same as first", {
    treeData <- create c(2, 2)
    expect_equal(sortedData treeData, c(2, 2))
})

test_that("Can sort if second number is greater than first", {
    treeData <- create c(2, 3)
    expect_equal(sortedData treeData, c(2, 3))
})

test_that("Can sort complex tree", {
    treeData <- create c(2, 1, 3, 6, 7, 5)
    expect_equal(sortedData treeData, c(1, 2, 3, 5, 6, 7))
})
