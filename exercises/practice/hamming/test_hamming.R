source("./hamming.R")
library(testthat)




test_that("Empty strands", {
    distance "" "" |> should equal (Some 0)


test_that("Single letter identical strands", {
    distance "A" "A" |> should equal (Some 0)


test_that("Single letter different strands", {
    distance "G" "T" |> should equal (Some 1)


test_that("Long identical strands", {
    distance "GGACTGAAATCTG" "GGACTGAAATCTG" |> should equal (Some 0)


test_that("Long different strands", {
    distance "GGACGGATTCTG" "AGGACGGATTCT" |> should equal (Some 9)


test_that("Disallow first strand longer", {
    distance "AATG" "AAA" |> should equal None


test_that("Disallow second strand longer", {
    distance "ATA" "AGTG" |> should equal None


test_that("Disallow empty first strand", {
    distance "" "G" |> should equal None


test_that("Disallow empty second strand", {
    distance "G" "" |> should equal None

