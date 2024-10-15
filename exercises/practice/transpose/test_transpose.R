source("./transpose.R")
library(testthat)

test_that("Empty string", {
    let lines: string list = []
    let expected: string list = []
  expect_equal(transpose lines, expected)
})

test_that("Two characters in a row", {
    let lines = ["A1"]
    let expected = 
        [ "A";
          "1" ]
  expect_equal(transpose lines, expected)
})

test_that("Two characters in a column", {
    let lines = 
        [ "A";
          "1" ]
    let expected = ["A1"]
  expect_equal(transpose lines, expected)
})

test_that("Simple", {
    let lines = 
        [ "ABC";
          "123" ]
    let expected = 
        [ "A1";
          "B2";
          "C3" ]
  expect_equal(transpose lines, expected)
})

test_that("Single line", {
    let lines = ["Single line."]
    let expected = 
        [ "S";
          "i";
          "n";
          "g";
          "l";
          "e";
          " ";
          "l";
          "i";
          "n";
          "e";
          "." ]
  expect_equal(transpose lines, expected)
})

test_that("First line longer than second line", {
    let lines = 
        [ "The fourth line.";
          "The fifth line." ]
    let expected = 
        [ "TT";
          "hh";
          "ee";
          "  ";
          "ff";
          "oi";
          "uf";
          "rt";
          "th";
          "h ";
          " l";
          "li";
          "in";
          "ne";
          "e.";
          "." ]
  expect_equal(transpose lines, expected)
})

test_that("Second line longer than first line", {
    let lines = 
        [ "The first line.";
          "The second line." ]
    let expected = 
        [ "TT";
          "hh";
          "ee";
          "  ";
          "fs";
          "ie";
          "rc";
          "so";
          "tn";
          " d";
          "l ";
          "il";
          "ni";
          "en";
          ".e";
          " ." ]
  expect_equal(transpose lines, expected)
})

test_that("Mixed line length", {
    let lines = 
        [ "The longest line.";
          "A long line.";
          "A longer line.";
          "A line." ]
    let expected = 
        [ "TAAA";
          "h   ";
          "elll";
          " ooi";
          "lnnn";
          "ogge";
          "n e.";
          "glr";
          "ei ";
          "snl";
          "tei";
          " .n";
          "l e";
          "i .";
          "n";
          "e";
          "." ]
  expect_equal(transpose lines, expected)
})

test_that("Square", {
    let lines = 
        [ "HEART";
          "EMBER";
          "ABUSE";
          "RESIN";
          "TREND" ]
    let expected = 
        [ "HEART";
          "EMBER";
          "ABUSE";
          "RESIN";
          "TREND" ]
  expect_equal(transpose lines, expected)
})

test_that("Rectangle", {
    let lines = 
        [ "FRACTURE";
          "OUTLINED";
          "BLOOMING";
          "SEPTETTE" ]
    let expected = 
        [ "FOBS";
          "RULE";
          "ATOP";
          "CLOT";
          "TIME";
          "UNIT";
          "RENT";
          "EDGE" ]
  expect_equal(transpose lines, expected)
})

test_that("Triangle", {
    let lines = 
        [ "T";
          "EE";
          "AAA";
          "SSSS";
          "EEEEE";
          "RRRRRR" ]
    let expected = 
        [ "TEASER";
          " EASER";
          "  ASER";
          "   SER";
          "    ER";
          "     R" ]
  expect_equal(transpose lines, expected)
})

test_that("Jagged triangle", {
    let lines = 
        [ "11";
          "2";
          "3333";
          "444";
          "555555";
          "66666" ]
    let expected = 
        [ "123456";
          "1 3456";
          "  3456";
          "  3 56";
          "    56";
          "    5" ]
  expect_equal(transpose lines, expected)

