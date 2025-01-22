source("./triangle.R")
library(testthat)

test_that("Equilateral returns all sides are equal", {
    expect_equal(equilateral [2.0; 2.0; 2.0], true)
})

test_that("Equilateral returns any side is unequal", {
    expect_equal(equilateral [2.0; 3.0; 2.0], false)
})

test_that("Equilateral returns no sides are equal", {
    expect_equal(equilateral [5.0; 4.0; 6.0], false)
})

test_that("Equilateral returns all zero sides is not a triangle", {
    expect_equal(equilateral [0.0; 0.0; 0.0], false)
})

test_that("Equilateral returns sides may be floats", {
    expect_equal(equilateral [0.5; 0.5; 0.5], true)
})

test_that("Isosceles returns last two sides are equal", {
    expect_equal(isosceles [3.0; 4.0; 4.0], true)
})

test_that("Isosceles returns first two sides are equal", {
    expect_equal(isosceles [4.0; 4.0; 3.0], true)
})

test_that("Isosceles returns first and last sides are equal", {
    expect_equal(isosceles [4.0; 3.0; 4.0], true)
})

test_that("Equilateral triangles are also isosceles", {
    expect_equal(isosceles [4.0; 4.0; 4.0], true)
})

test_that("Isosceles returns no sides are equal", {
    expect_equal(isosceles [2.0; 3.0; 4.0], false)
})

test_that("Isosceles returns first triangle inequality violation", {
    expect_equal(isosceles [1.0; 1.0; 3.0], false)
})

test_that("Isosceles returns second triangle inequality violation", {
    expect_equal(isosceles [1.0; 3.0; 1.0], false)
})

test_that("Isosceles returns third triangle inequality violation", {
    expect_equal(isosceles [3.0; 1.0; 1.0], false)
})

test_that("Isosceles returns sides may be floats", {
    expect_equal(isosceles [0.5; 0.4; 0.5], true)
})

test_that("Scalene returns no sides are equal", {
    expect_equal(scalene [5.0; 4.0; 6.0], true)
})

test_that("Scalene returns all sides are equal", {
    expect_equal(scalene [4.0; 4.0; 4.0], false)
})

test_that("Scalene returns first and second sides are equal", {
    expect_equal(scalene [4.0; 4.0; 3.0], false)
})

test_that("Scalene returns first and third sides are equal", {
    expect_equal(scalene [3.0; 4.0; 3.0], false)
})

test_that("Scalene returns second and third sides are equal", {
    expect_equal(scalene [4.0; 3.0; 3.0], false)
})

test_that("Scalene returns may not violate triangle inequality", {
    expect_equal(scalene [7.0; 3.0; 2.0], false)
})

test_that("Scalene returns sides may be floats", {
    expect_equal(scalene [0.5; 0.4; 0.6], true)
})
