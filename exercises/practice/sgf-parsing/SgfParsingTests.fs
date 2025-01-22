source("./sgf-parsing.R")
library(testthat)

test_that("Empty input", {
    expected <- None
    expect_equal(parse("", expected))
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
    expected <- (Node (Map.ofList c(], [)))
    expect_equal(parse "(;)", expected)
})

test_that("Single node tree", {
    expected <- (Node (Map.ofList c(("A", ["B"))], []))
    expect_equal(parse "(;Ac(B))", expected)
})

test_that("Multiple properties", {
    expected <- (Node (Map.ofList c(("A", ["b")), ("C", c("d"))], []))
    expect_equal(parse "(;Ac(b)Cc(d))", expected)
})

test_that("Properties without delimiter", {
    expected <- None
    expect_equal(parse "(;A)", expected)
})

test_that("All lowercase property", {
    expected <- None
    expect_equal(parse "(;ac(b))", expected)
})

test_that("Upper and lowercase property", {
    expected <- None
    expect_equal(parse "(;Aac(b))", expected)
})

test_that("Two nodes", {
    expected <- (Node (Map.ofList c(("A", ["B"))], c(Node (Map.ofList [("B", ["C"))], c(]))))
    expect_equal(parse "(;Ac(B);Bc(C))", expected)
})

test_that("Two child trees", {
    expected <- (Node (Map.ofList c(("A", ["B"))], c(Node (Map.ofList [("B", ["C"))], c(]), Node (Map.ofList [("C", ["D"))], c(]))))
    expect_equal(parse "(;Ac(B)(;Bc(C))(;Cc(D)))", expected)
})

test_that("Multiple property values", {
    expected <- (Node (Map.ofList c(("A", ["b", "c", "d"))], []))
    expect_equal(parse "(;Ac(b)c(c)c(d))", expected)
})

test_that("Semicolon in property value doesn't need to be escaped", {
    expected <- (Node (Map.ofList c(("A", ["a;b", "foo")), ("B", c("bar"))], c(Node (Map.ofList [("C", ["baz"))], c(]))))
    expect_equal(parse "(;Ac(a;b)c(foo)Bc(bar);Cc(baz))", expected)
})

test_that("Parentheses in property value don't need to be escaped", {
    expected <- (Node (Map.ofList c(("A", ["x(y)z", "foo")), ("B", c("bar"))], c(Node (Map.ofList [("C", ["baz"))], c(]))))
    expect_equal(parse "(;Ac(x(y)z)c(foo)Bc(bar);Cc(baz))", expected)
})
