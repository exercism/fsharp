source("./say.R")
library(testthat)

test_that("Zero", {
    say 0L |> should equal (Some "zero")
})

test_that("One", {
    say 1L |> should equal (Some "one")
})

test_that("Fourteen", {
    say 14L |> should equal (Some "fourteen")
})

test_that("Twenty", {
    say 20L |> should equal (Some "twenty")
})

test_that("Twenty-two", {
    say 22L |> should equal (Some "twenty-two")
})

test_that("Thirty", {
    say 30L |> should equal (Some "thirty")
})

test_that("Ninety-nine", {
    say 99L |> should equal (Some "ninety-nine")
})

test_that("One hundred", {
    say 100L |> should equal (Some "one hundred")
})

test_that("One hundred twenty-three", {
    say 123L |> should equal (Some "one hundred twenty-three")
})

test_that("Two hundred", {
    say 200L |> should equal (Some "two hundred")
})

test_that("Nine hundred ninety-nine", {
    say 999L |> should equal (Some "nine hundred ninety-nine")
})

test_that("One thousand", {
    say 1000L |> should equal (Some "one thousand")
})

test_that("One thousand two hundred thirty-four", {
    say 1234L |> should equal (Some "one thousand two hundred thirty-four")
})

test_that("One million", {
    say 1000000L |> should equal (Some "one million")
})

test_that("One million two thousand three hundred forty-five", {
    say 1002345L |> should equal (Some "one million two thousand three hundred forty-five")
})

test_that("One billion", {
    say 1000000000L |> should equal (Some "one billion")
})

test_that("A big number", {
    say 987654321123L |> should equal (Some "nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three")
})

test_that("Numbers below zero are out of range", {
    say -1L |> should equal None
})

test_that("Numbers above 999,999,999,999 are out of range", {
    say 1000000000000L |> should equal None

