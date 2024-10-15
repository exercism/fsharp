source("./accumulate.R")
library(testthat)


let reverse (str:string) = new string(str.ToCharArray() |> Array.rev)


test_that("Empty accumulation produces empty accumulation", {
    accumulate (fun x -> x + 1) List.empty |> should be Empty


test_that("Identity accumulation returns unmodified list", {
    accumulate id [1; 2; 3] |> should equal [1; 2; 3]


test_that("Accumulate squares", {
    accumulate (fun x -> x * x) [1; 2; 3] |> should equal [1; 4; 9]


test_that("Accumulate upcases", {
    accumulate (fun (x:string) -> x.ToUpper()) ["hello"; "world"]
    |> should equal ["HELLO"; "WORLD"]


test_that("Accumulate reversed strings", {
    accumulate reverse (List.ofArray ("the quick brown fox etc".Split(' ')))
    |> should equal (List.ofArray("eht kciuq nworb xof cte".Split(' ')))


test_that("Accumulate within accumulate", {
    accumulate (fun (x:string) -> String.concat " " (accumulate (fun y -> x + y) ["1"; "2"; "3"])) ["a"; "b"; "c"]
    |> should equal ["a1 a2 a3"; "b1 b2 b3"; "c1 c2 c3"]


test_that("Accumulate large data set without stack overflow", {
    accumulate id [1..100000]
    |> should equal [1..100000]
