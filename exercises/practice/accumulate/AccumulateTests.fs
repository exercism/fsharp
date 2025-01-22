// This file was created manually and its version is 2.0.0

source("./accumulate-test.R")
library(testthat)

let reverse (str:string) = new string(str.ToCharArray() |> Array.rev)
})

test_that("Empty accumulation produces empty accumulation", {
    accumulate (fun x -> x + 1) List.empty |> should be Empty

test_that("Identity accumulation returns unmodified list", {
    expect_equal(accumulate id c(1, 2, 3), c(1, 2, 3))
})

test_that("Accumulate squares", {
    expect_equal(accumulate (fun x -> x * x) c(1, 2, 3), c(1, 4, 9))
})

test_that("Accumulate upcases", {
    accumulate (fun (x:string) -> x.ToUpper()) c("hello", "world")
    expect_equal( , c("HELLO", "WORLD"))
})

test_that("Accumulate reversed strings", {
    accumulate reverse (List.ofArray ("the quick brown fox etc".Split(' ')))
    expect_equal( , (List.ofArray("eht kciuq nworb xof cte".Split(' '))))
})

test_that("Accumulate within accumulate", {
    accumulate (fun (x:string) -> String.concat " " (accumulate (fun y -> x + y) c("1", "2", "3"))) c("a", "b", "c")
    expect_equal( , c("a1 a2 a3", "b1 b2 b3", "c1 c2 c3"))
})

test_that("Accumulate large data set without stack overflow", {
    accumulate id c(1..100000)
    expect_equal( , c(1..100000))
