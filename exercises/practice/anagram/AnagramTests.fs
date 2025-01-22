source("./anagram.R")
library(testthat)

test_that("No matches", {
    candidates <- ["hello"; "world"; "zombies"; "pants"]
    findAnagrams candidates "diaper" |> should be Empty

test_that("Detects two anagrams", {
    candidates <- ["lemons"; "cherry"; "melons"]
    expect_equal(findAnagrams candidates "solemn", ["lemons"; "melons"])
})

test_that("Does not detect anagram subsets", {
    candidates <- ["dog"; "goody"]
    findAnagrams candidates "good" |> should be Empty

test_that("Detects anagram", {
    candidates <- ["enlists"; "google"; "inlets"; "banana"]
    expect_equal(findAnagrams candidates "listen", ["inlets"])
})

test_that("Detects three anagrams", {
    candidates <- ["gallery"; "ballerina"; "regally"; "clergy"; "largely"; "leading"]
    expect_equal(findAnagrams candidates "allergy", ["gallery"; "regally"; "largely"])
})

test_that("Detects multiple anagrams with different case", {
    candidates <- ["Eons"; "ONES"]
    expect_equal(findAnagrams candidates "nose", ["Eons"; "ONES"])
})

test_that("Does not detect non-anagrams with identical checksum", {
    candidates <- ["last"]
    findAnagrams candidates "mass" |> should be Empty

test_that("Detects anagrams case-insensitively", {
    candidates <- ["cashregister"; "Carthorse"; "radishes"]
    expect_equal(findAnagrams candidates "Orchestra", ["Carthorse"])
})

test_that("Detects anagrams using case-insensitive subject", {
    candidates <- ["cashregister"; "carthorse"; "radishes"]
    expect_equal(findAnagrams candidates "Orchestra", ["carthorse"])
})

test_that("Detects anagrams using case-insensitive possible matches", {
    candidates <- ["cashregister"; "Carthorse"; "radishes"]
    expect_equal(findAnagrams candidates "orchestra", ["Carthorse"])
})

test_that("Does not detect an anagram if the original word is repeated", {
    candidates <- ["go Go GO"]
    findAnagrams candidates "go" |> should be Empty

test_that("Anagrams must use all letters exactly once", {
    candidates <- ["patter"]
    findAnagrams candidates "tapper" |> should be Empty

test_that("Words are not anagrams of themselves", {
    candidates <- ["BANANA"]
    findAnagrams candidates "BANANA" |> should be Empty

test_that("Words are not anagrams of themselves even if letter case is partially different", {
    candidates <- ["Banana"]
    findAnagrams candidates "BANANA" |> should be Empty

test_that("Words are not anagrams of themselves even if letter case is completely different", {
    candidates <- ["banana"]
    findAnagrams candidates "BANANA" |> should be Empty

test_that("Words other than themselves can be anagrams", {
    candidates <- ["LISTEN"; "Silent"]
    expect_equal(findAnagrams candidates "LISTEN", ["Silent"])
})
