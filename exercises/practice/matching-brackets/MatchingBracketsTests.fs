source("./matching-brackets.R")
library(testthat)

test_that("Paired square brackets", {
    expect_equal(isPaired "[]", true)
})

test_that("Empty string", {
    expect_equal(isPaired "", true)
})

test_that("Unpaired brackets", {
    expect_equal(isPaired "[[", false)
})

test_that("Wrong ordered brackets", {
    expect_equal(isPaired "}{", false)
})

test_that("Wrong closing bracket", {
    expect_equal(isPaired "{]", false)
})

test_that("Paired with whitespace", {
    expect_equal(isPaired "{ }", true)
})

test_that("Partially paired brackets", {
    expect_equal(isPaired "{[])", false)
})

test_that("Simple nested brackets", {
    expect_equal(isPaired "{[]}", true)
})

test_that("Several paired brackets", {
    expect_equal(isPaired "{}[]", true)
})

test_that("Paired and nested brackets", {
    expect_equal(isPaired "([{}({}[])])", true)
})

test_that("Unopened closing brackets", {
    expect_equal(isPaired "{[)][]}", false)
})

test_that("Unpaired and nested brackets", {
    expect_equal(isPaired "([{])", false)
})

test_that("Paired and wrong nested brackets", {
    expect_equal(isPaired "[({]})", false)
})

test_that("Paired and wrong nested brackets but innermost are correct", {
    expect_equal(isPaired "[({}])", false)
})

test_that("Paired and incomplete brackets", {
    expect_equal(isPaired "{}[", false)
})

test_that("Too many closing brackets", {
    expect_equal(isPaired "[]]", false)
})

test_that("Early unexpected brackets", {
    expect_equal(isPaired ")()", false)
})

test_that("Early mismatched brackets", {
    expect_equal(isPaired "{)()", false)
})

test_that("Math expression", {
    expect_equal(isPaired "(((185 + 223.85) * 15) - 543)/2", true)
})

test_that("Complex latex expression", {
    expect_equal(isPaired "\left(\begin{array}{cc} \frac{1}{3} & x\\ \mathrm{e}^{x} &... x^2 \end{array}\right)", true)
})
