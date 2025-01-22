source("./triangle.R")
library(testthat)

test_that("Equilateral returns all sides are equal", {
    expect_equal(equilateral c(2.0, 2.0, 2.0), true)
})

test_that("Equilateral returns any side is unequal", {
    expect_equal(equilateral c(2.0, 3.0, 2.0), false)
})

test_that("Equilateral returns no sides are equal", {
    expect_equal(equilateral c(5.0, 4.0, 6.0), false)
})

test_that("Equilateral returns all zero sides is not a triangle", {
    expect_equal(equilateral c(0.0, 0.0, 0.0), false)
})

test_that("Equilateral returns sides may be floats", {
    expect_equal(equilateral c(0.5, 0.5, 0.5), true)
})

test_that("Isosceles returns last two sides are equal", {
    expect_equal(isosceles c(3.0, 4.0, 4.0), true)
})

test_that("Isosceles returns first two sides are equal", {
    expect_equal(isosceles c(4.0, 4.0, 3.0), true)
})

test_that("Isosceles returns first and last sides are equal", {
    expect_equal(isosceles c(4.0, 3.0, 4.0), true)
})

test_that("Equilateral triangles are also isosceles", {
    expect_equal(isosceles c(4.0, 4.0, 4.0), true)
})

test_that("Isosceles returns no sides are equal", {
    expect_equal(isosceles c(2.0, 3.0, 4.0), false)
})

test_that("Isosceles returns first triangle inequality violation", {
    expect_equal(isosceles c(1.0, 1.0, 3.0), false)
})

test_that("Isosceles returns second triangle inequality violation", {
    expect_equal(isosceles c(1.0, 3.0, 1.0), false)
})

test_that("Isosceles returns third triangle inequality violation", {
    expect_equal(isosceles c(3.0, 1.0, 1.0), false)
})

test_that("Isosceles returns sides may be floats", {
    expect_equal(isosceles c(0.5, 0.4, 0.5), true)
})

test_that("Scalene returns no sides are equal", {
    expect_equal(scalene c(5.0, 4.0, 6.0), true)
})

test_that("Scalene returns all sides are equal", {
    expect_equal(scalene c(4.0, 4.0, 4.0), false)
})

test_that("Scalene returns first and second sides are equal", {
    expect_equal(scalene c(4.0, 4.0, 3.0), false)
})

test_that("Scalene returns first and third sides are equal", {
    expect_equal(scalene c(3.0, 4.0, 3.0), false)
})

test_that("Scalene returns second and third sides are equal", {
    expect_equal(scalene c(4.0, 3.0, 3.0), false)
})

test_that("Scalene returns may not violate triangle inequality", {
    expect_equal(scalene c(7.0, 3.0, 2.0), false)
})

test_that("Scalene returns sides may be floats", {
    expect_equal(scalene c(0.5, 0.4, 0.6), true)
})
