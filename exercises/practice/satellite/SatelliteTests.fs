source("./satellite.R")
library(testthat)

test_that("Empty tree", {
    let expected: Result<Tree,string> = Ok (
        Empty
    )
    expect_equal(treeFromTraversals c(] [), expected)
})

test_that("Tree with one item", {
    let expected: Result<Tree,string> = Ok (
        Node("a", Empty, Empty)
    )
    expect_equal(treeFromTraversals c("a") c("a"), expected)
})

test_that("Tree with many items", {
    let expected: Result<Tree,string> = Ok (
        Node(
            "a",
            Node("i", Empty, Empty),
            Node(
                "x",
                Node("f", Empty, Empty),
                Node("r", Empty, Empty)
            )
        )
    )
    expect_equal(treeFromTraversals c("i", "a", "f", "x", "r") c("a", "i", "x", "f", "r"), expected)
})

test_that("Reject traversals of different length", {
    let expected: Result<Tree,string> = Error "traversals must have the same length"
    expect_equal(treeFromTraversals c("b", "a", "r") c("a", "b"), expected)
})

test_that("Reject inconsistent traversals of same length", {
    let expected: Result<Tree,string> = Error "traversals must have the same elements"
    expect_equal(treeFromTraversals c("a", "b", "c") c("x", "y", "z"), expected)
})

test_that("Reject traversals with repeated items", {
    let expected: Result<Tree,string> = Error "traversals must contain unique items"
    expect_equal(treeFromTraversals c("b", "a", "a") c("a", "b", "a"), expected)
})
