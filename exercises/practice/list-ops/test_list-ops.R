source("./list-ops.R")
library(testthat)




test_that("append empty lists", {
    append [] [] |> should be Empty


test_that("append list to empty list", {
    append [] [1; 2; 3; 4] |> should equal [1; 2; 3; 4]


test_that("append empty list to list", {
    append [1; 2; 3; 4] [] |> should equal [1; 2; 3; 4]


test_that("append non-empty lists", {
    append [1; 2] [2; 3; 4; 5] |> should equal [1; 2; 2; 3; 4; 5]


test_that("concat empty list", {
    concat [] |> should be Empty


test_that("concat list of lists", {
    concat [[1; 2]; [3]; []; [4; 5; 6]] |> should equal [1; 2; 3; 4; 5; 6]


test_that("concat list of nested lists", {
    concat [[[1]; [2]]; [[3]]; [[]]; [[4; 5; 6]]] |> should equal [[1]; [2]; [3]; []; [4; 5; 6]]


test_that("filter empty list", {
    filter (fun acc -> acc % 2 = 1) [] |> should be Empty


test_that("filter non-empty list", {
    filter (fun acc -> acc % 2 = 1) [1; 2; 3; 5] |> should equal [1; 3; 5]


test_that("length empty list", {
    length [] |> should equal 0


test_that("length non-empty list", {
    length [1; 2; 3; 4] |> should equal 4


test_that("map empty list", {
    map (fun acc -> acc + 1) [] |> should be Empty


test_that("map non-empty list", {
    map (fun acc -> acc + 1) [1; 3; 5; 7] |> should equal [2; 4; 6; 8]


test_that("foldl empty list", {
    foldl (fun acc el -> el * acc) 2 [] |> should equal 2


test_that("foldl direction independent function applied to non-empty list", {
    foldl (fun acc el -> el + acc) 5 [1; 2; 3; 4] |> should equal 15


test_that("foldr empty list", {
    foldr (fun acc el -> el * acc) 2 [] |> should equal 2


test_that("foldr direction independent function applied to non-empty list", {
    foldr (fun acc el -> el + acc) 5 [1; 2; 3; 4] |> should equal 15


test_that("reverse empty list", {
    reverse [] |> should be Empty


test_that("reverse non-empty list", {
    reverse [1; 3; 5; 7] |> should equal [7; 5; 3; 1]


test_that("reverse list of lists is not flattened", {
    reverse [[1; 2]; [3]; []; [4; 5; 6]] |> should equal [[4; 5; 6]; []; [3]; [1; 2]]

