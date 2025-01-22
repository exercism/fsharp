source("./say.R")
library(testthat)

test_that("Zero", {
    expect_equal(say 0L, (Some "zero"))
})

test_that("One", {
    expect_equal(say 1L, (Some "one"))
})

test_that("Fourteen", {
    expect_equal(say 14L, (Some "fourteen"))
})

test_that("Twenty", {
    expect_equal(say 20L, (Some "twenty"))
})

test_that("Twenty-two", {
    expect_equal(say 22L, (Some "twenty-two"))
})

test_that("Thirty", {
    expect_equal(say 30L, (Some "thirty"))
})

test_that("Ninety-nine", {
    expect_equal(say 99L, (Some "ninety-nine"))
})

test_that("One hundred", {
    expect_equal(say 100L, (Some "one hundred"))
})

test_that("One hundred twenty-three", {
    expect_equal(say 123L, (Some "one hundred twenty-three"))
})

test_that("Two hundred", {
    expect_equal(say 200L, (Some "two hundred"))
})

test_that("Nine hundred ninety-nine", {
    expect_equal(say 999L, (Some "nine hundred ninety-nine"))
})

test_that("One thousand", {
    expect_equal(say 1000L, (Some "one thousand"))
})

test_that("One thousand two hundred thirty-four", {
    expect_equal(say 1234L, (Some "one thousand two hundred thirty-four"))
})

test_that("One million", {
    expect_equal(say 1000000L, (Some "one million"))
})

test_that("One million two thousand three hundred forty-five", {
    expect_equal(say 1002345L, (Some "one million two thousand three hundred forty-five"))
})

test_that("One billion", {
    expect_equal(say 1000000000L, (Some "one billion"))
})

test_that("A big number", {
    expect_equal(say 987654321123L, (Some "nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three"))
})

test_that("Numbers below zero are out of range", {
    expect_equal(say -1L, None)
})

test_that("Numbers above 999,999,999,999 are out of range", {
    expect_equal(say 1000000000000L, None)
})
