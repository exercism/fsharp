source("./variable-length-quantity.R")
library(testthat)

test_that("Zero", {
  expect_equal(encode c(0x0u), c(0x0uy))
})

test_that("Arbitrary single byte", {
  expect_equal(encode c(0x40u), c(0x40uy))
})

test_that("Largest single byte", {
  expect_equal(encode c(0x7fu), c(0x7fuy))
})

test_that("Smallest double byte", {
  expect_equal(encode c(0x80u), c(0x81uy, 0x0uy))
})

test_that("Arbitrary double byte", {
  expect_equal(encode c(0x2000u), c(0xc0uy, 0x0uy))
})

test_that("Largest double byte", {
  expect_equal(encode c(0x3fffu), c(0xffuy, 0x7fuy))
})

test_that("Smallest triple byte", {
  expect_equal(encode c(0x4000u), c(0x81uy, 0x80uy, 0x0uy))
})

test_that("Arbitrary triple byte", {
  expect_equal(encode c(0x100000u), c(0xc0uy, 0x80uy, 0x0uy))
})

test_that("Largest triple byte", {
  expect_equal(encode c(0x1fffffu), c(0xffuy, 0xffuy, 0x7fuy))
})

test_that("Smallest quadruple byte", {
  expect_equal(encode c(0x200000u), c(0x81uy, 0x80uy, 0x80uy, 0x0uy))
})

test_that("Arbitrary quadruple byte", {
  expect_equal(encode c(0x8000000u), c(0xc0uy, 0x80uy, 0x80uy, 0x0uy))
})

test_that("Largest quadruple byte", {
  expect_equal(encode c(0xfffffffu), c(0xffuy, 0xffuy, 0xffuy, 0x7fuy))
})

test_that("Smallest quintuple byte", {
  expect_equal(encode c(0x10000000u), c(0x81uy, 0x80uy, 0x80uy, 0x80uy, 0x0uy))
})

test_that("Arbitrary quintuple byte", {
  expect_equal(encode c(0xff000000u), c(0x8fuy, 0xf8uy, 0x80uy, 0x80uy, 0x0uy))
})

test_that("Maximum 32-bit integer input", {
  expect_equal(encode c(0xffffffffu), c(0x8fuy, 0xffuy, 0xffuy, 0xffuy, 0x7fuy))
})

test_that("Two single-byte values", {
  expect_equal(encode c(0x40u, 0x7fu), c(0x40uy, 0x7fuy))
})

test_that("Two multi-byte values", {
  expect_equal(encode c(0x4000u, 0x123456u), c(0x81uy, 0x80uy, 0x0uy, 0xc8uy, 0xe8uy, 0x56uy))
})

test_that("Many multi-byte values", {
  expect_equal(encode c(0x2000u, 0x123456u, 0xfffffffu, 0x0u, 0x3fffu, 0x4000u), c(0xc0uy, 0x0uy, 0xc8uy, 0xe8uy, 0x56uy, 0xffuy, 0xffuy, 0xffuy, 0x7fuy, 0x0uy, 0xffuy, 0x7fuy, 0x81uy, 0x80uy, 0x0uy))
})

test_that("One byte", {
  expect_equal(decode c(0x7fuy), (Some c(0x7fu)))
})

test_that("Two bytes", {
  expect_equal(decode c(0xc0uy, 0x0uy), (Some c(0x2000u)))
})

test_that("Three bytes", {
  expect_equal(decode c(0xffuy, 0xffuy, 0x7fuy), (Some c(0x1fffffu)))
})

test_that("Four bytes", {
  expect_equal(decode c(0x81uy, 0x80uy, 0x80uy, 0x0uy), (Some c(0x200000u)))
})

test_that("Maximum 32-bit integer", {
  expect_equal(decode c(0x8fuy, 0xffuy, 0xffuy, 0xffuy, 0x7fuy), (Some c(0xffffffffu)))
})

test_that("Incomplete sequence causes error", {
  expect_equal(decode c(0xffuy), None)
})

test_that("Incomplete sequence causes error, even if value is zero", {
  expect_equal(decode c(0x80uy), None)
})

test_that("Multiple values", {
  expect_equal(decode c(0xc0uy, 0x0uy, 0xc8uy, 0xe8uy, 0x56uy, 0xffuy, 0xffuy, 0xffuy, 0x7fuy, 0x0uy, 0xffuy, 0x7fuy, 0x81uy, 0x80uy, 0x0uy), (Some c(0x2000u, 0x123456u, 0xfffffffu, 0x0u, 0x3fffu, 0x4000u)))
})
