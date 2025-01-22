source("./word-search.R")
library(testthat)

test_that("Should accept an initial game grid and a target search word", {
    grid <- ["jefblpepre"]
    wordsToSearchFor <- ["clojure"]
    expected <- [("clojure", Option<((int * int) * (int * int))>.None)] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate one word written left to right", {
    grid <- ["clojurermt"]
    wordsToSearchFor <- ["clojure"]
    expected <- [("clojure", Some ((1, 1), (7, 1)))] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate the same word written left to right in a different position", {
    grid <- ["mtclojurer"]
    wordsToSearchFor <- ["clojure"]
    expected <- [("clojure", Some ((3, 1), (9, 1)))] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate a different left to right word", {
    grid <- ["coffeelplx"]
    wordsToSearchFor <- ["coffee"]
    expected <- [("coffee", Some ((1, 1), (6, 1)))] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate that different left to right word in a different position", {
    grid <- ["xcoffeezlp"]
    wordsToSearchFor <- ["coffee"]
    expected <- [("coffee", Some ((2, 1), (7, 1)))] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate a left to right word in two line grid", {
    grid <- 
        [ "jefblpepre";
          "tclojurerm" ]
    wordsToSearchFor <- ["clojure"]
    expected <- [("clojure", Some ((2, 2), (8, 2)))] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate a left to right word in three line grid", {
    grid <- 
        [ "camdcimgtc";
          "jefblpepre";
          "clojurermt" ]
    wordsToSearchFor <- ["clojure"]
    expected <- [("clojure", Some ((1, 3), (7, 3)))] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate a left to right word in ten line grid", {
    grid <- 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    wordsToSearchFor <- ["clojure"]
    expected <- [("clojure", Some ((1, 10), (7, 10)))] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate that left to right word in a different position in a ten line grid", {
    grid <- 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "clojurermt";
          "jalaycalmp" ]
    wordsToSearchFor <- ["clojure"]
    expected <- [("clojure", Some ((1, 9), (7, 9)))] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate a different left to right word in a ten line grid", {
    grid <- 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "fortranftw";
          "alxhpburyi";
          "clojurermt";
          "jalaycalmp" ]
    wordsToSearchFor <- ["fortran"]
    expected <- [("fortran", Some ((1, 7), (7, 7)))] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate multiple words", {
    grid <- 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "fortranftw";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    wordsToSearchFor <- ["fortran"; "clojure"]
    expected <- 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("fortran", Some ((1, 7), (7, 7))) ]
        |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate a single word written right to left", {
    grid <- ["rixilelhrs"]
    wordsToSearchFor <- ["elixir"]
    expected <- [("elixir", Some ((6, 1), (1, 1)))] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate multiple words written in different horizontal directions", {
    grid <- 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    wordsToSearchFor <- ["elixir"; "clojure"]
    expected <- 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5))) ]
        |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate words written top to bottom", {
    grid <- 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    wordsToSearchFor <- ["clojure"; "elixir"; "ecmascript"]
    expected <- 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10))) ]
        |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate words written bottom to top", {
    grid <- 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    wordsToSearchFor <- ["clojure"; "elixir"; "ecmascript"; "rust"]
    expected <- 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2))) ]
        |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate words written top left to bottom right", {
    grid <- 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    wordsToSearchFor <- ["clojure"; "elixir"; "ecmascript"; "rust"; "java"]
    expected <- 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4))) ]
        |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate words written bottom right to top left", {
    grid <- 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    wordsToSearchFor <- ["clojure"; "elixir"; "ecmascript"; "rust"; "java"; "lua"]
    expected <- 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4)));
          ("lua", Some ((8, 9), (6, 7))) ]
        |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate words written bottom left to top right", {
    grid <- 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    wordsToSearchFor <- ["clojure"; "elixir"; "ecmascript"; "rust"; "java"; "lua"; "lisp"]
    expected <- 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4)));
          ("lua", Some ((8, 9), (6, 7)));
          ("lisp", Some ((3, 6), (6, 3))) ]
        |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should locate words written top right to bottom left", {
    grid <- 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    wordsToSearchFor <- ["clojure"; "elixir"; "ecmascript"; "rust"; "java"; "lua"; "lisp"; "ruby"]
    expected <- 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4)));
          ("lua", Some ((8, 9), (6, 7)));
          ("lisp", Some ((3, 6), (6, 3)));
          ("ruby", Some ((8, 6), (5, 9))) ]
        |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should fail to locate a word that is not in the puzzle", {
    grid <- 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    wordsToSearchFor <- ["clojure"; "elixir"; "ecmascript"; "rust"; "java"; "lua"; "lisp"; "ruby"; "haskell"]
    expected <- 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4)));
          ("lua", Some ((8, 9), (6, 7)));
          ("lisp", Some ((3, 6), (6, 3)));
          ("ruby", Some ((8, 6), (5, 9)));
          ("haskell", Option<((int * int) * (int * int))>.None) ]
        |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should fail to locate words that are not on horizontal, vertical, or diagonal lines", {
    grid <- 
        [ "abc";
          "def" ]
    wordsToSearchFor <- ["aef"; "ced"; "abf"; "cbd"]
    expected <- 
        [ ("aef", Option<((int * int) * (int * int))>.None);
          ("ced", Option<((int * int) * (int * int))>.None);
          ("abf", Option<((int * int) * (int * int))>.None);
          ("cbd", Option<((int * int) * (int * int))>.None) ]
        |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should not concatenate different lines to find a horizontal word", {
    grid <- 
        [ "abceli";
          "xirdfg" ]
    wordsToSearchFor <- ["elixir"]
    expected <- [("elixir", Option<((int * int) * (int * int))>.None)] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should not wrap around horizontally to find a word", {
    grid <- ["silabcdefp"]
    wordsToSearchFor <- ["lisp"]
    expected <- [("lisp", Option<((int * int) * (int * int))>.None)] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

test_that("Should not wrap around vertically to find a word", {
    grid <- 
        [ "s";
          "u";
          "r";
          "a";
          "b";
          "c";
          "t" ]
    wordsToSearchFor <- ["rust"]
    expected <- [("rust", Option<((int * int) * (int * int))>.None)] |> Map.ofList
    expect_equal(search grid wordsToSearchFor, expected)

