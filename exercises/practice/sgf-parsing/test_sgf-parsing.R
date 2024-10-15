source("./sgf-parsing.R")
library(testthat)

test_that("Empty input", {
    expected <-None
  expect_equal(parse "", expected)
})

test_that("Tree with no nodes", {
    expected <-None
  expect_equal(parse "()", expected)
})

test_that("Node without tree", {
    expected <-None
  expect_equal(parse ";", expected)
})

test_that("Node without properties", {
    expected <-Some (Node (Map.ofList c(), c()))
  expect_equal(parse "(;)", expected)
})

test_that("Single node tree", {
    expected <-Some (Node (Map.ofList c(("A", c("B"))), c()))
  expect_equal(parse "(;Ac(B))", expected)
})

test_that("Multiple properties", {
    expected <-Some (Node (Map.ofList c(("A", c("b")), ("C", c("d"))), c()))
  expect_equal(parse "(;Ac(b)Cc(d))", expected)
})

test_that("Properties without delimiter", {
    expected <-None
  expect_equal(parse "(;A)", expected)
})

test_that("All lowercase property", {
    expected <-None
  expect_equal(parse "(;ac(b))", expected)
})

test_that("Upper and lowercase property", {
    expected <-None
  expect_equal(parse "(;Aac(b))", expected)
})

test_that("Two nodes", {
    expected <-Some (Node (Map.ofList c(("A", c("B"))), c(Node (Map.ofList c(("B", c("C"))), c()))))
  expect_equal(parse "(;Ac(B);Bc(C))", expected)
})

test_that("Two child trees", {
    expected <-Some (Node (Map.ofList c(("A", c("B"))), c(Node (Map.ofList c(("B", c("C"))), c()), Node (Map.ofList c(("C", c("D"))), c()))))
  expect_equal(parse "(;Ac(B)(;Bc(C))(;Cc(D)))", expected)
})

test_that("Multiple property values", {
    expected <-Some (Node (Map.ofList c(("A", c("b", "c", "d"))), c()))
  expect_equal(parse "(;Ac(b)c(c)c(d))", expected)
})

test_that("Semicolon in property value doesn't need to be escaped", {
    expected <-Some (Node (Map.ofList c(("A", c("a;b", "foo")), ("B", c("bar"))), c(Node (Map.ofList c(("C", c("baz"))), c()))))
  expect_equal(parse "(;Ac(a;b)c(foo)Bc(bar);Cc(baz))", expected)
})

test_that("Parentheses in property value don't need to be escaped", {
    expected <-Some (Node (Map.ofList c(("A", c("x(y)z", "foo")), ("B", c("bar"))), c(Node (Map.ofList c(("C", c("baz"))), c()))))
  expect_equal(parse "(;Ac(x(y)z)c(foo)Bc(bar);Cc(baz))", expected)

