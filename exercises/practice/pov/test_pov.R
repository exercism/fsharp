source("./pov.R")
library(testthat)



let rec graphToList (graph: Graph<'a>) = 
    right <-
        graph.children
        |> List.sortBy (fun x -> x.value)
        |> List.collect graphToList
    c(graph.value) @ right
let mapToList graph = match graph with | Some x -> graphToList x | None -> c()
})

test_that("Results in the same tree if the input tree is a singleton", {
  tree <- mkGraph "x" c()
  expected <- mkGraph "x" c()
  expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)
})

test_that("Can reroot a tree with a parent and one sibling", {
  tree <- mkGraph "parent" c(mkGraph "x" c(), mkGraph "sibling" c())
  expected <- mkGraph "x" c(mkGraph "parent" c(mkGraph "sibling" c()))
  expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)
})

test_that("Can reroot a tree with a parent and many siblings", {
  tree <- mkGraph "parent" c(mkGraph "a" c(), mkGraph "x" c(), mkGraph "b" c(), mkGraph "c" c())
  expected <- mkGraph "x" c(mkGraph "parent" c(mkGraph "a" c(), mkGraph "b" c(), mkGraph "c" c()))
  expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)
})

test_that("Can reroot a tree with new root deeply nested in tree", {
  tree <- mkGraph "level-0" c(mkGraph "level-1" c(mkGraph "level-2" c(mkGraph "level-3" c(mkGraph "x" c()))))
  expected <- mkGraph "x" c(mkGraph "level-3" c(mkGraph "level-2" c(mkGraph "level-1" c(mkGraph "level-0" c()))))
  expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)
})

test_that("Moves children of the new root to same level as former parent", {
  tree <- mkGraph "parent" c(mkGraph "x" c(mkGraph "kid-0" c(), mkGraph "kid-1" c()))
  expected <- mkGraph "x" c(mkGraph "kid-0" c(), mkGraph "kid-1" c(), mkGraph "parent" c())
  expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)
})

test_that("Can reroot a complex tree with cousins", {
  tree <- mkGraph "grandparent" c(mkGraph "parent" c(mkGraph "x" c(mkGraph "kid-0" c(), mkGraph "kid-1" c()), mkGraph "sibling-0" c(), mkGraph "sibling-1" c()), mkGraph "uncle" c(mkGraph "cousin-0" c(), mkGraph "cousin-1" c()))
  expected <- mkGraph "x" c(mkGraph "kid-1" c(), mkGraph "kid-0" c(), mkGraph "parent" c(mkGraph "sibling-0" c(), mkGraph "sibling-1" c(), mkGraph "grandparent" c(mkGraph "uncle" c(mkGraph "cousin-0" c(), mkGraph "cousin-1" c()))))
  expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)
})

test_that("Errors if target does not exist in a singleton tree", {
  tree <- mkGraph "x" c()
  expect_equal(fromPOV "nonexistent" tree , None)
})

test_that("Errors if target does not exist in a large tree", {
  tree <- mkGraph "parent" c(mkGraph "x" c(mkGraph "kid-0" c(), mkGraph "kid-1" c()), mkGraph "sibling-0" c(), mkGraph "sibling-1" c())
  expect_equal(fromPOV "nonexistent" tree , None)
})

test_that("Can find path to parent", {
  tree <- mkGraph "parent" c(mkGraph "x" c(), mkGraph "sibling" c())
  expect_equal(tracePathBetween "x" "parent" tree, <| Some c("x", "parent"))
})

test_that("Can find path to sibling", {
  tree <- mkGraph "parent" c(mkGraph "a" c(), mkGraph "x" c(), mkGraph "b" c(), mkGraph "c" c())
  expect_equal(tracePathBetween "x" "b" tree, <| Some c("x", "parent", "b"))
})

test_that("Can find path to cousin", {
  tree <- mkGraph "grandparent" c(mkGraph "parent" c(mkGraph "x" c(mkGraph "kid-0" c(), mkGraph "kid-1" c()), mkGraph "sibling-0" c(), mkGraph "sibling-1" c()), mkGraph "uncle" c(mkGraph "cousin-0" c(), mkGraph "cousin-1" c()))
  expect_equal(tracePathBetween "x" "cousin-1" tree, <| Some c("x", "parent", "grandparent", "uncle", "cousin-1"))
})

test_that("Can find path not involving root", {
  tree <- mkGraph "grandparent" c(mkGraph "parent" c(mkGraph "x" c(), mkGraph "sibling-0" c(), mkGraph "sibling-1" c()))
  expect_equal(tracePathBetween "x" "sibling-1" tree, <| Some c("x", "parent", "sibling-1"))
})

test_that("Can find path from nodes other than x", {
  tree <- mkGraph "parent" c(mkGraph "a" c(), mkGraph "x" c(), mkGraph "b" c(), mkGraph "c" c())
  expect_equal(tracePathBetween "a" "c" tree, <| Some c("a", "parent", "c"))
})

test_that("Errors if destination does not exist", {
  tree <- mkGraph "parent" c(mkGraph "x" c(mkGraph "kid-0" c(), mkGraph "kid-1" c()), mkGraph "sibling-0" c(), mkGraph "sibling-1" c())
  expect_equal(tracePathBetween "x" "nonexistent" tree, None)
})

test_that("Errors if source does not exist", {
  tree <- mkGraph "parent" c(mkGraph "x" c(mkGraph "kid-0" c(), mkGraph "kid-1" c()), mkGraph "sibling-0" c(), mkGraph "sibling-1" c())
  expect_equal(tracePathBetween "nonexistent" "x" tree, None)

