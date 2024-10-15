source("./pov.R")
library(testthat)



let rec graphToList (graph: Graph<'a>) = 
    let right =
        graph.children
        |> List.sortBy (fun x -> x.value)
        |> List.collect graphToList
    [graph.value] @ right
let mapToList graph = match graph with | Some x -> graphToList x | None -> []
})

test_that("Results in the same tree if the input tree is a singleton", {
    let tree = mkGraph "x" []
    let expected = mkGraph "x" []
  expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)
})

test_that("Can reroot a tree with a parent and one sibling", {
    let tree = mkGraph "parent" [mkGraph "x" []; mkGraph "sibling" []]
    let expected = mkGraph "x" [mkGraph "parent" [mkGraph "sibling" []]]
  expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)
})

test_that("Can reroot a tree with a parent and many siblings", {
    let tree = mkGraph "parent" [mkGraph "a" []; mkGraph "x" []; mkGraph "b" []; mkGraph "c" []]
    let expected = mkGraph "x" [mkGraph "parent" [mkGraph "a" []; mkGraph "b" []; mkGraph "c" []]]
  expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)
})

test_that("Can reroot a tree with new root deeply nested in tree", {
    let tree = mkGraph "level-0" [mkGraph "level-1" [mkGraph "level-2" [mkGraph "level-3" [mkGraph "x" []]]]]
    let expected = mkGraph "x" [mkGraph "level-3" [mkGraph "level-2" [mkGraph "level-1" [mkGraph "level-0" []]]]]
  expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)
})

test_that("Moves children of the new root to same level as former parent", {
    let tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]]
    let expected = mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []; mkGraph "parent" []]
  expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)
})

test_that("Can reroot a complex tree with cousins", {
    let tree = mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]; mkGraph "uncle" [mkGraph "cousin-0" []; mkGraph "cousin-1" []]]
    let expected = mkGraph "x" [mkGraph "kid-1" []; mkGraph "kid-0" []; mkGraph "parent" [mkGraph "sibling-0" []; mkGraph "sibling-1" []; mkGraph "grandparent" [mkGraph "uncle" [mkGraph "cousin-0" []; mkGraph "cousin-1" []]]]]
  expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)
})

test_that("Errors if target does not exist in a singleton tree", {
    let tree = mkGraph "x" []
  expect_equal(fromPOV "nonexistent" tree , None)
})

test_that("Errors if target does not exist in a large tree", {
    let tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]
  expect_equal(fromPOV "nonexistent" tree , None)
})

test_that("Can find path to parent", {
    let tree = mkGraph "parent" [mkGraph "x" []; mkGraph "sibling" []]
  expect_equal(tracePathBetween "x" "parent" tree, <| Some ["x"; "parent"])
})

test_that("Can find path to sibling", {
    let tree = mkGraph "parent" [mkGraph "a" []; mkGraph "x" []; mkGraph "b" []; mkGraph "c" []]
  expect_equal(tracePathBetween "x" "b" tree, <| Some ["x"; "parent"; "b"])
})

test_that("Can find path to cousin", {
    let tree = mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]; mkGraph "uncle" [mkGraph "cousin-0" []; mkGraph "cousin-1" []]]
  expect_equal(tracePathBetween "x" "cousin-1" tree, <| Some ["x"; "parent"; "grandparent"; "uncle"; "cousin-1"])
})

test_that("Can find path not involving root", {
    let tree = mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" []; mkGraph "sibling-0" []; mkGraph "sibling-1" []]]
  expect_equal(tracePathBetween "x" "sibling-1" tree, <| Some ["x"; "parent"; "sibling-1"])
})

test_that("Can find path from nodes other than x", {
    let tree = mkGraph "parent" [mkGraph "a" []; mkGraph "x" []; mkGraph "b" []; mkGraph "c" []]
  expect_equal(tracePathBetween "a" "c" tree, <| Some ["a"; "parent"; "c"])
})

test_that("Errors if destination does not exist", {
    let tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]
  expect_equal(tracePathBetween "x" "nonexistent" tree, None)
})

test_that("Errors if source does not exist", {
    let tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]
  expect_equal(tracePathBetween "nonexistent" "x" tree, None)

