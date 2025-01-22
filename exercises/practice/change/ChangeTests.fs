source("./change.R")
library(testthat)

test_that("Change for 1 cent", {
    coins <- [1; 5; 10; 25]
    target <- 1
    expected <- Some [1]
    expect_equal(findFewestCoins coins target, expected)

test_that("Single coin change", {
    coins <- [1; 5; 10; 25; 100]
    target <- 25
    expected <- Some [25]
    expect_equal(findFewestCoins coins target, expected)

test_that("Multiple coin change", {
    coins <- [1; 5; 10; 25; 100]
    target <- 15
    expected <- Some [5; 10]
    expect_equal(findFewestCoins coins target, expected)

test_that("Change with Lilliputian Coins", {
    coins <- [1; 4; 15; 20; 50]
    target <- 23
    expected <- Some [4; 4; 15]
    expect_equal(findFewestCoins coins target, expected)

test_that("Change with Lower Elbonia Coins", {
    coins <- [1; 5; 10; 21; 25]
    target <- 63
    expected <- Some [21; 21; 21]
    expect_equal(findFewestCoins coins target, expected)

test_that("Large target values", {
    coins <- [1; 2; 5; 10; 20; 50; 100]
    target <- 999
    expected <- Some [2; 2; 5; 20; 20; 50; 100; 100; 100; 100; 100; 100; 100; 100; 100]
    expect_equal(findFewestCoins coins target, expected)

test_that("Possible change without unit coins available", {
    coins <- [2; 5; 10; 20; 50]
    target <- 21
    expected <- Some [2; 2; 2; 5; 10]
    expect_equal(findFewestCoins coins target, expected)

test_that("Another possible change without unit coins available", {
    coins <- [4; 5]
    target <- 27
    expected <- Some [4; 4; 4; 5; 5; 5]
    expect_equal(findFewestCoins coins target, expected)

test_that("No coins make 0 change", {
    coins <- [1; 5; 10; 21; 25]
    target <- 0
    let expected: int list option = Some []
    expect_equal(findFewestCoins coins target, expected)

test_that("Error testing for change smaller than the smallest of coins", {
    coins <- [5; 10]
    target <- 3
    expected <- None
    expect_equal(findFewestCoins coins target, expected)

test_that("Error if no combination can add up to target", {
    coins <- [5; 10]
    target <- 94
    expected <- None
    expect_equal(findFewestCoins coins target, expected)

test_that("Cannot find negative change values", {
    coins <- [1; 2; 5]
    target <- -5
    expected <- None
    expect_equal(findFewestCoins coins target, expected)

