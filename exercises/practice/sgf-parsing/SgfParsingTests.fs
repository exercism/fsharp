source("./sgf-parsing.R")
library(testthat)

test_that("Empty input", {
    expected <- None
    expect_equal(parse "", expected)
})

test_that("Tree with no nodes", {
    expected <- None
    expect_equal(parse "()", expected)
})

test_that("Node without tree", {
    expected <- None
    expect_equal(parse ";", expected)
})

test_that("Node without properties", {
    expected <- Some (Node (Map.ofList [], []))
    expect_equal(parse "(;)", expected)
})

test_that("Single node tree", {
    expected <- Some (Node (Map.ofList [("A", ["B"])], []))
    expect_equal(parse "(;A[B])", expected)
})

test_that("Multiple properties", {
    expected <- Some (Node (Map.ofList [("A", ["b"]); ("C", ["d"])], []))
    expect_equal(parse "(;A[b]C[d])", expected)
})

test_that("Properties without delimiter", {
    expected <- None
    expect_equal(parse "(;A)", expected)
})

test_that("All lowercase property", {
    expected <- None
    expect_equal(parse "(;a[b])", expected)
})

test_that("Upper and lowercase property", {
    expected <- None
    expect_equal(parse "(;Aa[b])", expected)
})

test_that("Two nodes", {
    expected <- Some (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], [])]))
    expect_equal(parse "(;A[B];B[C])", expected)
})

test_that("Two child trees", {
    expected <- Some (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], []); Node (Map.ofList [("C", ["D"])], [])]))
    expect_equal(parse "(;A[B](;B[C])(;C[D]))", expected)
})

test_that("Multiple property values", {
    expected <- Some (Node (Map.ofList [("A", ["b"; "c"; "d"])], []))
    expect_equal(parse "(;A[b][c][d])", expected)
})

test_that("Semicolon in property value doesn't need to be escaped", {
    expected <- Some (Node (Map.ofList [("A", ["a;b"; "foo"]); ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
    expect_equal(parse "(;A[a;b][foo]B[bar];C[baz])", expected)
})

test_that("Parentheses in property value don't need to be escaped", {
    expected <- Some (Node (Map.ofList [("A", ["x(y)z"; "foo"]); ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
    expect_equal(parse "(;A[x(y)z][foo]B[bar];C[baz])", expected)
})
