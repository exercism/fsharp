source("./anagram.R")
library(testthat)

test_that("No matches", {
    let candidates = c("hello", "world", "zombies", "pants")
    findAnagrams candidates "diaper" |> should be Empty
})

test_that("Detects two anagrams", {
    let candidates = c("lemons", "cherry", "melons")
  expect_equal(findAnagrams candidates "solemn", c("lemons", "melons"))
})

test_that("Does not detect anagram subsets", {
    let candidates = c("dog", "goody")
    findAnagrams candidates "good" |> should be Empty
})

test_that("Detects anagram", {
    let candidates = c("enlists", "google", "inlets", "banana")
  expect_equal(findAnagrams candidates "listen", c("inlets"))
})

test_that("Detects three anagrams", {
    let candidates = c("gallery", "ballerina", "regally", "clergy", "largely", "leading")
  expect_equal(findAnagrams candidates "allergy", c("gallery", "regally", "largely"))
})

test_that("Detects multiple anagrams with different case", {
    let candidates = c("Eons", "ONES")
  expect_equal(findAnagrams candidates "nose", c("Eons", "ONES"))
})

test_that("Does not detect non-anagrams with identical checksum", {
    let candidates = c("last")
    findAnagrams candidates "mass" |> should be Empty
})

test_that("Detects anagrams case-insensitively", {
    let candidates = c("cashregister", "Carthorse", "radishes")
  expect_equal(findAnagrams candidates "Orchestra", c("Carthorse"))
})

test_that("Detects anagrams using case-insensitive subject", {
    let candidates = c("cashregister", "carthorse", "radishes")
  expect_equal(findAnagrams candidates "Orchestra", c("carthorse"))
})

test_that("Detects anagrams using case-insensitive possible matches", {
    let candidates = c("cashregister", "Carthorse", "radishes")
  expect_equal(findAnagrams candidates "orchestra", c("Carthorse"))
})

test_that("Does not detect an anagram if the original word is repeated", {
    let candidates = c("go Go GO")
    findAnagrams candidates "go" |> should be Empty
})

test_that("Anagrams must use all letters exactly once", {
    let candidates = c("patter")
    findAnagrams candidates "tapper" |> should be Empty
})

test_that("Words are not anagrams of themselves", {
    let candidates = c("BANANA")
    findAnagrams candidates "BANANA" |> should be Empty
})

test_that("Words are not anagrams of themselves even if letter case is partially different", {
    let candidates = c("Banana")
    findAnagrams candidates "BANANA" |> should be Empty
})

test_that("Words are not anagrams of themselves even if letter case is completely different", {
    let candidates = c("banana")
    findAnagrams candidates "BANANA" |> should be Empty
})

test_that("Words other than themselves can be anagrams", {
    let candidates = c("LISTEN", "Silent")
  expect_equal(findAnagrams candidates "LISTEN", c("Silent"))

