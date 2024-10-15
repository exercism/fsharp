source("./rectangles.R")
library(testthat)




test_that("No rows", {
    let strings = []
    rectangles strings |> should equal 0


test_that("No columns", {
    let strings = [""]
    rectangles strings |> should equal 0


test_that("No rectangles", {
    let strings = [" "]
    rectangles strings |> should equal 0


test_that("One rectangle", {
    let strings = 
        [ "+-+";
          "| |";
          "+-+" ]
    rectangles strings |> should equal 1


test_that("Two rectangles without shared parts", {
    let strings = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| |  ";
          "+-+  " ]
    rectangles strings |> should equal 2


test_that("Five rectangles with shared parts", {
    let strings = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| | |";
          "+-+-+" ]
    rectangles strings |> should equal 5


test_that("Rectangle of height 1 is counted", {
    let strings = 
        [ "+--+";
          "+--+" ]
    rectangles strings |> should equal 1


test_that("Rectangle of width 1 is counted", {
    let strings = 
        [ "++";
          "||";
          "++" ]
    rectangles strings |> should equal 1


test_that("1x1 square is counted", {
    let strings = 
        [ "++";
          "++" ]
    rectangles strings |> should equal 1


test_that("Only complete rectangles are counted", {
    let strings = 
        [ "  +-+";
          "    |";
          "+-+-+";
          "| | -";
          "+-+-+" ]
    rectangles strings |> should equal 1


test_that("Rectangles can be of different sizes", {
    let strings = 
        [ "+------+----+";
          "|      |    |";
          "+---+--+    |";
          "|   |       |";
          "+---+-------+" ]
    rectangles strings |> should equal 3


test_that("Corner is required for a rectangle to be complete", {
    let strings = 
        [ "+------+----+";
          "|      |    |";
          "+------+    |";
          "|   |       |";
          "+---+-------+" ]
    rectangles strings |> should equal 2


test_that("Large input with many rectangles", {
    let strings = 
        [ "+---+--+----+";
          "|   +--+----+";
          "+---+--+    |";
          "|   +--+----+";
          "+---+--+--+-+";
          "+---+--+--+-+";
          "+------+  | |";
          "          +-+" ]
    rectangles strings |> should equal 60


test_that("Rectangles must have four sides", {
    let strings = 
        [ "+-+ +-+";
          "| | | |";
          "+-+-+-+";
          "  | |  ";
          "+-+-+-+";
          "| | | |";
          "+-+ +-+" ]
    rectangles strings |> should equal 5

