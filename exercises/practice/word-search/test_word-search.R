source("./word-search.R")
library(testthat)

test_that("Should accept an initial game grid and a target search word", {
    let grid = c("jefblpepre")
    let wordsToSearchFor = c("clojure")
  expected <- c(("clojure", Option<((int * int) * (int * int))>.None)) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate one word written left to right", {
    let grid = c("clojurermt")
    let wordsToSearchFor = c("clojure")
  expected <- c(("clojure", Some ((1, 1), (7, 1)))) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate the same word written left to right in a different position", {
    let grid = c("mtclojurer")
    let wordsToSearchFor = c("clojure")
  expected <- c(("clojure", Some ((3, 1), (9, 1)))) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate a different left to right word", {
    let grid = c("coffeelplx")
    let wordsToSearchFor = c("coffee")
  expected <- c(("coffee", Some ((1, 1), (6, 1)))) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate that different left to right word in a different position", {
    let grid = c("xcoffeezlp")
    let wordsToSearchFor = c("coffee")
  expected <- c(("coffee", Some ((2, 1), (7, 1)))) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate a left to right word in two line grid", {
    let grid = 
        c( "jefblpepre",
          "tclojurerm" )
    let wordsToSearchFor = c("clojure")
  expected <- c(("clojure", Some ((2, 2), (8, 2)))) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate a left to right word in three line grid", {
    let grid = 
        c( "camdcimgtc",
          "jefblpepre",
          "clojurermt" )
    let wordsToSearchFor = c("clojure")
  expected <- c(("clojure", Some ((1, 3), (7, 3)))) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate a left to right word in ten line grid", {
    let grid = 
        c( "jefblpepre",
          "camdcimgtc",
          "oivokprjsm",
          "pbwasqroua",
          "rixilelhrs",
          "wolcqlirpc",
          "screeaumgr",
          "alxhpburyi",
          "jalaycalmp",
          "clojurermt" )
    let wordsToSearchFor = c("clojure")
  expected <- c(("clojure", Some ((1, 10), (7, 10)))) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate that left to right word in a different position in a ten line grid", {
    let grid = 
        c( "jefblpepre",
          "camdcimgtc",
          "oivokprjsm",
          "pbwasqroua",
          "rixilelhrs",
          "wolcqlirpc",
          "screeaumgr",
          "alxhpburyi",
          "clojurermt",
          "jalaycalmp" )
    let wordsToSearchFor = c("clojure")
  expected <- c(("clojure", Some ((1, 9), (7, 9)))) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate a different left to right word in a ten line grid", {
    let grid = 
        c( "jefblpepre",
          "camdcimgtc",
          "oivokprjsm",
          "pbwasqroua",
          "rixilelhrs",
          "wolcqlirpc",
          "fortranftw",
          "alxhpburyi",
          "clojurermt",
          "jalaycalmp" )
    let wordsToSearchFor = c("fortran")
  expected <- c(("fortran", Some ((1, 7), (7, 7)))) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate multiple words", {
    let grid = 
        c( "jefblpepre",
          "camdcimgtc",
          "oivokprjsm",
          "pbwasqroua",
          "rixilelhrs",
          "wolcqlirpc",
          "fortranftw",
          "alxhpburyi",
          "jalaycalmp",
          "clojurermt" )
    let wordsToSearchFor = c("fortran", "clojure")
  expected <- 
        c( ("clojure", Some ((1, 10), (7, 10)));
          ("fortran", Some ((1, 7), (7, 7))) )
        |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate a single word written right to left", {
    let grid = c("rixilelhrs")
    let wordsToSearchFor = c("elixir")
  expected <- c(("elixir", Some ((6, 1), (1, 1)))) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate multiple words written in different horizontal directions", {
    let grid = 
        c( "jefblpepre",
          "camdcimgtc",
          "oivokprjsm",
          "pbwasqroua",
          "rixilelhrs",
          "wolcqlirpc",
          "screeaumgr",
          "alxhpburyi",
          "jalaycalmp",
          "clojurermt" )
    let wordsToSearchFor = c("elixir", "clojure")
  expected <- 
        c( ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5))) )
        |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate words written top to bottom", {
    let grid = 
        c( "jefblpepre",
          "camdcimgtc",
          "oivokprjsm",
          "pbwasqroua",
          "rixilelhrs",
          "wolcqlirpc",
          "screeaumgr",
          "alxhpburyi",
          "jalaycalmp",
          "clojurermt" )
    let wordsToSearchFor = c("clojure", "elixir", "ecmascript")
  expected <- 
        c( ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10))) )
        |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate words written bottom to top", {
    let grid = 
        c( "jefblpepre",
          "camdcimgtc",
          "oivokprjsm",
          "pbwasqroua",
          "rixilelhrs",
          "wolcqlirpc",
          "screeaumgr",
          "alxhpburyi",
          "jalaycalmp",
          "clojurermt" )
    let wordsToSearchFor = c("clojure", "elixir", "ecmascript", "rust")
  expected <- 
        c( ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2))) )
        |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate words written top left to bottom right", {
    let grid = 
        c( "jefblpepre",
          "camdcimgtc",
          "oivokprjsm",
          "pbwasqroua",
          "rixilelhrs",
          "wolcqlirpc",
          "screeaumgr",
          "alxhpburyi",
          "jalaycalmp",
          "clojurermt" )
    let wordsToSearchFor = c("clojure", "elixir", "ecmascript", "rust", "java")
  expected <- 
        c( ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4))) )
        |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate words written bottom right to top left", {
    let grid = 
        c( "jefblpepre",
          "camdcimgtc",
          "oivokprjsm",
          "pbwasqroua",
          "rixilelhrs",
          "wolcqlirpc",
          "screeaumgr",
          "alxhpburyi",
          "jalaycalmp",
          "clojurermt" )
    let wordsToSearchFor = c("clojure", "elixir", "ecmascript", "rust", "java", "lua")
  expected <- 
        c( ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4)));
          ("lua", Some ((8, 9), (6, 7))) )
        |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate words written bottom left to top right", {
    let grid = 
        c( "jefblpepre",
          "camdcimgtc",
          "oivokprjsm",
          "pbwasqroua",
          "rixilelhrs",
          "wolcqlirpc",
          "screeaumgr",
          "alxhpburyi",
          "jalaycalmp",
          "clojurermt" )
    let wordsToSearchFor = c("clojure", "elixir", "ecmascript", "rust", "java", "lua", "lisp")
  expected <- 
        c( ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4)));
          ("lua", Some ((8, 9), (6, 7)));
          ("lisp", Some ((3, 6), (6, 3))) )
        |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should locate words written top right to bottom left", {
    let grid = 
        c( "jefblpepre",
          "camdcimgtc",
          "oivokprjsm",
          "pbwasqroua",
          "rixilelhrs",
          "wolcqlirpc",
          "screeaumgr",
          "alxhpburyi",
          "jalaycalmp",
          "clojurermt" )
    let wordsToSearchFor = c("clojure", "elixir", "ecmascript", "rust", "java", "lua", "lisp", "ruby")
  expected <- 
        c( ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4)));
          ("lua", Some ((8, 9), (6, 7)));
          ("lisp", Some ((3, 6), (6, 3)));
          ("ruby", Some ((8, 6), (5, 9))) )
        |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should fail to locate a word that is not in the puzzle", {
    let grid = 
        c( "jefblpepre",
          "camdcimgtc",
          "oivokprjsm",
          "pbwasqroua",
          "rixilelhrs",
          "wolcqlirpc",
          "screeaumgr",
          "alxhpburyi",
          "jalaycalmp",
          "clojurermt" )
    let wordsToSearchFor = c("clojure", "elixir", "ecmascript", "rust", "java", "lua", "lisp", "ruby", "haskell")
  expected <- 
        c( ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4)));
          ("lua", Some ((8, 9), (6, 7)));
          ("lisp", Some ((3, 6), (6, 3)));
          ("ruby", Some ((8, 6), (5, 9)));
          ("haskell", Option<((int * int) * (int * int))>.None) )
        |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should fail to locate words that are not on horizontal, vertical, or diagonal lines", {
    let grid = 
        c( "abc",
          "def" )
    let wordsToSearchFor = c("aef", "ced", "abf", "cbd")
  expected <- 
        c( ("aef", Option<((int * int) * (int * int))>.None);
          ("ced", Option<((int * int) * (int * int))>.None);
          ("abf", Option<((int * int) * (int * int))>.None);
          ("cbd", Option<((int * int) * (int * int))>.None) )
        |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should not concatenate different lines to find a horizontal word", {
    let grid = 
        c( "abceli",
          "xirdfg" )
    let wordsToSearchFor = c("elixir")
  expected <- c(("elixir", Option<((int * int) * (int * int))>.None)) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should not wrap around horizontally to find a word", {
    let grid = c("silabcdefp")
    let wordsToSearchFor = c("lisp")
  expected <- c(("lisp", Option<((int * int) * (int * int))>.None)) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})

test_that("Should not wrap around vertically to find a word", {
    let grid = 
        c( "s",
          "u",
          "r",
          "a",
          "b",
          "c",
          "t" )
    let wordsToSearchFor = c("rust")
  expected <- c(("rust", Option<((int * int) * (int * int))>.None)) |> Map.ofList
  expect_equal(search grid wordsToSearchFor, expected)
})