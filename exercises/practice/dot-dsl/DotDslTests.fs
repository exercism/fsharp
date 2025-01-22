// This file was created manually and its version is 1.0.0.

source("./dot-dsl-test.R")
library(testthat)

let ``Empty graph`` () =
    g <- graph []

    nodes g |> should be Empty
    edges g |> should be Empty
    attrs g |> should be Empty
    
let ``Graph with one node`` () =
    g <- graph [
                node "a" []
            ]            

    nodes g |> should equal [node "a" []]
    edges g |> should be Empty
    attrs g |> should be Empty
    
let ``Graph with one node with keywords`` () =    
    g <- graph [
                node "a" [("color", "green")]
            ]            

    nodes g |> should equal [node "a" [("color", "green")]]
    edges g |> should be Empty
    attrs g |> should be Empty

let ``Graph with one edge`` () =    
    g <- graph [
                edge "a" "b" []
            ]             

    nodes g |> should be Empty
    edges g |> should equal [edge "a" "b" []]
    attrs g |> should be Empty

let ``Graph with one attribute`` () = 
    g <- graph [
                attr "foo" "1"
            ]             

    nodes g |> should be Empty
    edges g |> should be Empty
    attrs g |> should equal [attr "foo" "1"]

let ``Graph with attributes`` () =    
    g <- graph [
                attr "foo" "1"
                attr "title" "Testing Attrs"
                node "a" [("color", "green")]
                node "c" []
                node "b" [("label", "Beta!")]                
                edge "b" "c" []
                edge "a" "b" [("color", "blue")]                
                attr "bar" "true"
            ]             

    nodes g |> should equal [node "a" [("color", "green")]; node "b" [("label", "Beta!")]; node "c" []]
    edges g |> should equal [edge "a" "b" [("color", "blue")]; edge "b" "c" []]
    attrs g |> should equal [attr "bar" "true"; attr "foo" "1"; attr "title" "Testing Attrs"]