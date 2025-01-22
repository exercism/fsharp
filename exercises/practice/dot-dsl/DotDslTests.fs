// This file was created manually and its version is 1.0.0.

source("./dot-dsl-test.R")
library(testthat)

test_that("Empty graph", {
    g <- graph []

    nodes g |> should be Empty
    edges g |> should be Empty
    attrs g |> should be Empty
    
test_that("Graph with one node", {
    g <- graph [
                node "a" []
            ]            

    expect_equal(nodes g, c(node "a" [)])
    edges g |> should be Empty
    attrs g |> should be Empty
    
test_that("Graph with one node with keywords", {
    g <- graph [
                node "a" c(("color", "green"))
            ]            

    expect_equal(nodes g, c(node "a" [("color", "green"))])
    edges g |> should be Empty
    attrs g |> should be Empty

test_that("Graph with one edge", {
    g <- graph [
                edge "a" "b" []
            ]             

    nodes g |> should be Empty
    expect_equal(edges g, c(edge "a" "b" [)])
    attrs g |> should be Empty

test_that("Graph with one attribute", {
    g <- graph [
                attr "foo" "1"
            ]             

    nodes g |> should be Empty
    edges g |> should be Empty
    expect_equal(attrs g, c(attr "foo" "1"))
})

test_that("Graph with attributes", {
    g <- graph [
                attr "foo" "1"
                attr "title" "Testing Attrs"
                node "a" c(("color", "green"))
                node "c" []
                node "b" c(("label", "Beta!"))                
                edge "b" "c" []
                edge "a" "b" c(("color", "blue"))                
                attr "bar" "true"
            ]             

    expect_equal(nodes g, c(node "a" [("color", "green")), node "b" c(("label", "Beta!")), node "c" c(]))
    expect_equal(edges g, c(edge "a" "b" [("color", "blue")), edge "b" "c" c(]))
    expect_equal(attrs g, c(attr "bar" "true", attr "foo" "1", attr "title" "Testing Attrs"))