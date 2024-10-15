source("./word-count.R")
library(testthat)

test_that("Count one word", {
    let expected = [("word", 1)] |> Map.ofList
  expect_equal(countWords "word", expected)
})

test_that("Count one of each word", {
    let expected = 
        [ ("one", 1);
          ("of", 1);
          ("each", 1) ]
        |> Map.ofList
  expect_equal(countWords "one of each", expected)
})

test_that("Multiple occurrences of a word", {
    let expected = 
        [ ("one", 1);
          ("fish", 4);
          ("two", 1);
          ("red", 1);
          ("blue", 1) ]
        |> Map.ofList
  expect_equal(countWords "one fish two fish red fish blue fish", expected)
})

test_that("Handles cramped lists", {
    let expected = 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
  expect_equal(countWords "one,two,three", expected)
})

test_that("Handles expanded lists", {
    let expected = 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
  expect_equal(countWords "one,\ntwo,\nthree", expected)
})

test_that("Ignore punctuation", {
    let expected = 
        [ ("car", 1);
          ("carpet", 1);
          ("as", 1);
          ("java", 1);
          ("javascript", 1) ]
        |> Map.ofList
  expect_equal(countWords "car: carpet as java: javascript!!&@$%^&", expected)
})

test_that("Include numbers", {
    let expected = 
        [ ("testing", 2);
          ("1", 1);
          ("2", 1) ]
        |> Map.ofList
  expect_equal(countWords "testing, 1, 2 testing", expected)
})

test_that("Normalize case", {
    let expected = 
        [ ("go", 3);
          ("stop", 2) ]
        |> Map.ofList
  expect_equal(countWords "go Go GO Stop stop", expected)
})

test_that("With apostrophes", {
    let expected = 
        [ ("first", 1);
          ("don't", 2);
          ("laugh", 1);
          ("then", 1);
          ("cry", 1);
          ("you're", 1);
          ("getting", 1);
          ("it", 1) ]
        |> Map.ofList
  expect_equal(countWords "'First: don't laugh. Then: don't cry. You're getting it.'", expected)
})

test_that("With quotations", {
    let expected = 
        [ ("joe", 1);
          ("can't", 1);
          ("tell", 1);
          ("between", 1);
          ("large", 2);
          ("and", 1) ]
        |> Map.ofList
  expect_equal(countWords "Joe can't tell between 'large' and large.", expected)
})

test_that("Substrings from the beginning", {
    let expected = 
        [ ("joe", 1);
          ("can't", 1);
          ("tell", 1);
          ("between", 1);
          ("app", 1);
          ("apple", 1);
          ("and", 1);
          ("a", 1) ]
        |> Map.ofList
  expect_equal(countWords "Joe can't tell between app, apple and a.", expected)
})

test_that("Multiple spaces not detected as a word", {
    let expected = 
        [ ("multiple", 1);
          ("whitespaces", 1) ]
        |> Map.ofList
  expect_equal(countWords " multiple   whitespaces", expected)
})

test_that("Alternating word separators not detected as a word", {
    let expected = 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
  expect_equal(countWords ",\n,one,\n ,two \n 'three'", expected)
})

test_that("Quotation for word with apostrophe", {
    let expected = 
        [ ("can", 1);
          ("can't", 2) ]
        |> Map.ofList
  expect_equal(countWords "can, can't, 'can't'", expected)

