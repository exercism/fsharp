source("./tournament.R")
library(testthat)

test_that("Just the header if no input", {
    rows <- []
    expected <- ["Team                           | MP |  W |  D |  L |  P"]
    expect_equal(tally rows, expected)

test_that("A win is three points, a loss is zero points", {
    rows <- ["Allegoric Alaskans;Blithering Badgers;win"]
    expected <- 
        [ "Team                           | MP |  W |  D |  L |  P";
          "Allegoric Alaskans             |  1 |  1 |  0 |  0 |  3";
          "Blithering Badgers             |  1 |  0 |  0 |  1 |  0" ]
    expect_equal(tally rows, expected)

test_that("A win can also be expressed as a loss", {
    rows <- ["Blithering Badgers;Allegoric Alaskans;loss"]
    expected <- 
        [ "Team                           | MP |  W |  D |  L |  P";
          "Allegoric Alaskans             |  1 |  1 |  0 |  0 |  3";
          "Blithering Badgers             |  1 |  0 |  0 |  1 |  0" ]
    expect_equal(tally rows, expected)

test_that("A different team can win", {
    rows <- ["Blithering Badgers;Allegoric Alaskans;win"]
    expected <- 
        [ "Team                           | MP |  W |  D |  L |  P";
          "Blithering Badgers             |  1 |  1 |  0 |  0 |  3";
          "Allegoric Alaskans             |  1 |  0 |  0 |  1 |  0" ]
    expect_equal(tally rows, expected)

test_that("A draw is one point each", {
    rows <- ["Allegoric Alaskans;Blithering Badgers;draw"]
    expected <- 
        [ "Team                           | MP |  W |  D |  L |  P";
          "Allegoric Alaskans             |  1 |  0 |  1 |  0 |  1";
          "Blithering Badgers             |  1 |  0 |  1 |  0 |  1" ]
    expect_equal(tally rows, expected)

test_that("There can be more than one match", {
    rows <- 
        [ "Allegoric Alaskans;Blithering Badgers;win";
          "Allegoric Alaskans;Blithering Badgers;win" ]
    expected <- 
        [ "Team                           | MP |  W |  D |  L |  P";
          "Allegoric Alaskans             |  2 |  2 |  0 |  0 |  6";
          "Blithering Badgers             |  2 |  0 |  0 |  2 |  0" ]
    expect_equal(tally rows, expected)

test_that("There can be more than one winner", {
    rows <- 
        [ "Allegoric Alaskans;Blithering Badgers;loss";
          "Allegoric Alaskans;Blithering Badgers;win" ]
    expected <- 
        [ "Team                           | MP |  W |  D |  L |  P";
          "Allegoric Alaskans             |  2 |  1 |  0 |  1 |  3";
          "Blithering Badgers             |  2 |  1 |  0 |  1 |  3" ]
    expect_equal(tally rows, expected)

test_that("There can be more than two teams", {
    rows <- 
        [ "Allegoric Alaskans;Blithering Badgers;win";
          "Blithering Badgers;Courageous Californians;win";
          "Courageous Californians;Allegoric Alaskans;loss" ]
    expected <- 
        [ "Team                           | MP |  W |  D |  L |  P";
          "Allegoric Alaskans             |  2 |  2 |  0 |  0 |  6";
          "Blithering Badgers             |  2 |  1 |  0 |  1 |  3";
          "Courageous Californians        |  2 |  0 |  0 |  2 |  0" ]
    expect_equal(tally rows, expected)

test_that("Typical input", {
    rows <- 
        [ "Allegoric Alaskans;Blithering Badgers;win";
          "Devastating Donkeys;Courageous Californians;draw";
          "Devastating Donkeys;Allegoric Alaskans;win";
          "Courageous Californians;Blithering Badgers;loss";
          "Blithering Badgers;Devastating Donkeys;loss";
          "Allegoric Alaskans;Courageous Californians;win" ]
    expected <- 
        [ "Team                           | MP |  W |  D |  L |  P";
          "Devastating Donkeys            |  3 |  2 |  1 |  0 |  7";
          "Allegoric Alaskans             |  3 |  2 |  0 |  1 |  6";
          "Blithering Badgers             |  3 |  1 |  0 |  2 |  3";
          "Courageous Californians        |  3 |  0 |  1 |  2 |  1" ]
    expect_equal(tally rows, expected)

test_that("Incomplete competition (not all pairs have played)", {
    rows <- 
        [ "Allegoric Alaskans;Blithering Badgers;loss";
          "Devastating Donkeys;Allegoric Alaskans;loss";
          "Courageous Californians;Blithering Badgers;draw";
          "Allegoric Alaskans;Courageous Californians;win" ]
    expected <- 
        [ "Team                           | MP |  W |  D |  L |  P";
          "Allegoric Alaskans             |  3 |  2 |  0 |  1 |  6";
          "Blithering Badgers             |  2 |  1 |  1 |  0 |  4";
          "Courageous Californians        |  2 |  0 |  1 |  1 |  1";
          "Devastating Donkeys            |  1 |  0 |  0 |  1 |  0" ]
    expect_equal(tally rows, expected)

test_that("Ties broken alphabetically", {
    rows <- 
        [ "Courageous Californians;Devastating Donkeys;win";
          "Allegoric Alaskans;Blithering Badgers;win";
          "Devastating Donkeys;Allegoric Alaskans;loss";
          "Courageous Californians;Blithering Badgers;win";
          "Blithering Badgers;Devastating Donkeys;draw";
          "Allegoric Alaskans;Courageous Californians;draw" ]
    expected <- 
        [ "Team                           | MP |  W |  D |  L |  P";
          "Allegoric Alaskans             |  3 |  2 |  1 |  0 |  7";
          "Courageous Californians        |  3 |  2 |  1 |  0 |  7";
          "Blithering Badgers             |  3 |  0 |  1 |  2 |  1";
          "Devastating Donkeys            |  3 |  0 |  1 |  2 |  1" ]
    expect_equal(tally rows, expected)

test_that("Ensure points sorted numerically", {
    rows <- 
        [ "Devastating Donkeys;Blithering Badgers;win";
          "Devastating Donkeys;Blithering Badgers;win";
          "Devastating Donkeys;Blithering Badgers;win";
          "Devastating Donkeys;Blithering Badgers;win";
          "Blithering Badgers;Devastating Donkeys;win" ]
    expected <- 
        [ "Team                           | MP |  W |  D |  L |  P";
          "Devastating Donkeys            |  5 |  4 |  0 |  1 | 12";
          "Blithering Badgers             |  5 |  1 |  0 |  4 |  3" ]
    expect_equal(tally rows, expected)

