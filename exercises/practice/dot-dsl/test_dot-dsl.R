source("./dot-dsl.R")
library(testthat)

test_that("Empty graph", {
    let g = graph c()

    nodes g |> should be Empty
    edges g |> should be Empty
    attrs g |> should be Empty
    

test_that("Graph with one node", {
    let g = graph c(
                node "a" c()
            )            

  expect_equal(nodes g, c(node "a" c()))
    edges g |> should be Empty
    attrs g |> should be Empty
    

test_that("Graph with one node with keywords", {    
    let g = graph c(
                node("a" c(("color"), "green"))
            )            

  expect_equal(nodes g, c(node("a" c(("color"), "green"))))
    edges g |> should be Empty
    attrs g |> should be Empty
})

test_that("Graph with one edge", {    
    let g = graph c(
                edge "a" "b" c()
            )             

    nodes g |> should be Empty
  expect_equal(edges g, c(edge "a" "b" c()))
    attrs g |> should be Empty
})

test_that("Graph with one attribute", { 
    let g = graph c(
                attr "foo" "1"
            )             

    nodes g |> should be Empty
    edges g |> should be Empty
  expect_equal(attrs g, c(attr "foo" "1"))
})

test_that("Graph with attributes", {    
    let g = graph c(
                attr "foo" "1"
                attr "title" "Testing Attrs"
                node("a" c(("color"), "green"))
                node "c" c()
                node("b" c(("label"), "Beta!"))                
                edge "b" "c" c()
                edge("a" "b" c(("color"), "blue"))                
                attr "bar" "true"
            )             

  expect_equal(nodes g, c(node("a" c(("color"), "green")), node("b" c(("label"), "Beta!")), node "c" c()))
  expect_equal(edges g, c(edge("a" "b" c(("color"), "blue")), edge "b" "c" c()))
  expect_equal(attrs g, c(attr "bar" "true", attr "foo" "1", attr "title" "Testing Attrs"))