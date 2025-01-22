source("./list-ops.R")
library(testthat)

test_that("append empty lists", {
    append [] [] |> should be Empty

test_that("append list to empty list", {
    expect_equal(append [] [1; 2; 3; 4], [1; 2; 3; 4])

test_that("append empty list to list", {
    expect_equal(append [1; 2; 3; 4] [], [1; 2; 3; 4])

test_that("append non-empty lists", {
    expect_equal(append [1; 2] [2; 3; 4; 5], [1; 2; 2; 3; 4; 5])

test_that("concat empty list", {
    concat [] |> should be Empty

test_that("concat list of lists", {
    expect_equal(concat [[1; 2]; [3]; []; [4; 5; 6]], [1; 2; 3; 4; 5; 6])

test_that("concat list of nested lists", {
    expect_equal(concat [[[1]; [2]]; [[3]]; [[]]; [[4; 5; 6]]], [[1]; [2]; [3]; []; [4; 5; 6]])

test_that("filter empty list", {
    filter (fun acc -> acc % 2 = 1) [] |> should be Empty

test_that("filter non-empty list", {
    expect_equal(filter (fun acc -> acc % 2 = 1) [1; 2; 3; 5], [1; 3; 5])

test_that("length empty list", {
    expect_equal(length [], 0)

test_that("length non-empty list", {
    expect_equal(length [1; 2; 3; 4], 4)

test_that("map empty list", {
    map (fun acc -> acc + 1) [] |> should be Empty

test_that("map non-empty list", {
    expect_equal(map (fun acc -> acc + 1) [1; 3; 5; 7], [2; 4; 6; 8])

test_that("foldl empty list", {
    expect_equal(foldl (fun acc el -> el * acc) 2 [], 2)

test_that("foldl direction independent function applied to non-empty list", {
    expect_equal(foldl (fun acc el -> el + acc) 5 [1; 2; 3; 4], 15)

test_that("foldr empty list", {
    expect_equal(foldr (fun acc el -> el * acc) 2 [], 2)

test_that("foldr direction independent function applied to non-empty list", {
    expect_equal(foldr (fun acc el -> el + acc) 5 [1; 2; 3; 4], 15)

test_that("reverse empty list", {
    reverse [] |> should be Empty

test_that("reverse non-empty list", {
    expect_equal(reverse [1; 3; 5; 7], [7; 5; 3; 1])

test_that("reverse list of lists is not flattened", {
    expect_equal(reverse [[1; 2]; [3]; []; [4; 5; 6]], [[4; 5; 6]; []; [3]; [1; 2]])

