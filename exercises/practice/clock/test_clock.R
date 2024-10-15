source("./clock.R")
library(testthat)

test_that("On the hour", {
    let clock = create 8 0
  expect_equal(display clock, "08:00")
})

test_that("Past the hour", {
    let clock = create 11 9
  expect_equal(display clock, "11:09")
})

test_that("Midnight is zero hours", {
    let clock = create 24 0
  expect_equal(display clock, "00:00")
})

test_that("Hour rolls over", {
    let clock = create 25 0
  expect_equal(display clock, "01:00")
})

test_that("Hour rolls over continuously", {
    let clock = create 100 0
  expect_equal(display clock, "04:00")
})

test_that("Sixty minutes is next hour", {
    let clock = create 1 60
  expect_equal(display clock, "02:00")
})

test_that("Minutes roll over", {
    let clock = create 0 160
  expect_equal(display clock, "02:40")
})

test_that("Minutes roll over continuously", {
    let clock = create 0 1723
  expect_equal(display clock, "04:43")
})

test_that("Hour and minutes roll over", {
    let clock = create 25 160
  expect_equal(display clock, "03:40")
})

test_that("Hour and minutes roll over continuously", {
    let clock = create 201 3001
  expect_equal(display clock, "11:01")
})

test_that("Hour and minutes roll over to exactly midnight", {
    let clock = create 72 8640
  expect_equal(display clock, "00:00")
})

test_that("Negative hour", {
    let clock = create -1 15
  expect_equal(display clock, "23:15")
})

test_that("Negative hour rolls over", {
    let clock = create -25 0
  expect_equal(display clock, "23:00")
})

test_that("Negative hour rolls over continuously", {
    let clock = create -91 0
  expect_equal(display clock, "05:00")
})

test_that("Negative minutes", {
    let clock = create 1 -40
  expect_equal(display clock, "00:20")
})

test_that("Negative minutes roll over", {
    let clock = create 1 -160
  expect_equal(display clock, "22:20")
})

test_that("Negative minutes roll over continuously", {
    let clock = create 1 -4820
  expect_equal(display clock, "16:40")
})

test_that("Negative sixty minutes is previous hour", {
    let clock = create 2 -60
  expect_equal(display clock, "01:00")
})

test_that("Negative hour and minutes both roll over", {
    let clock = create -25 -160
  expect_equal(display clock, "20:20")
})

test_that("Negative hour and minutes both roll over continuously", {
    let clock = create -121 -5810
  expect_equal(display clock, "22:10")
})

test_that("Add minutes", {
    let clock = create 10 0
  expect_equal(add 3 clock |> display, "10:03")
})

test_that("Add no minutes", {
    let clock = create 6 41
  expect_equal(add 0 clock |> display, "06:41")
})

test_that("Add to next hour", {
    let clock = create 0 45
  expect_equal(add 40 clock |> display, "01:25")
})

test_that("Add more than one hour", {
    let clock = create 10 0
  expect_equal(add 61 clock |> display, "11:01")
})

test_that("Add more than two hours with carry", {
    let clock = create 0 45
  expect_equal(add 160 clock |> display, "03:25")
})

test_that("Add across midnight", {
    let clock = create 23 59
  expect_equal(add 2 clock |> display, "00:01")
})

test_that("Add more than one day (1500 min = 25 hrs)", {
    let clock = create 5 32
  expect_equal(add 1500 clock |> display, "06:32")
})

test_that("Add more than two days", {
    let clock = create 1 1
  expect_equal(add 3500 clock |> display, "11:21")
})

test_that("Subtract minutes", {
    let clock = create 10 3
  expect_equal(subtract 3 clock |> display, "10:00")
})

test_that("Subtract to previous hour", {
    let clock = create 10 3
  expect_equal(subtract 30 clock |> display, "09:33")
})

test_that("Subtract more than an hour", {
    let clock = create 10 3
  expect_equal(subtract 70 clock |> display, "08:53")
})

test_that("Subtract across midnight", {
    let clock = create 0 3
  expect_equal(subtract 4 clock |> display, "23:59")
})

test_that("Subtract more than two hours", {
    let clock = create 0 0
  expect_equal(subtract 160 clock |> display, "21:20")
})

test_that("Subtract more than two hours with borrow", {
    let clock = create 6 15
  expect_equal(subtract 160 clock |> display, "03:35")
})

test_that("Subtract more than one day (1500 min = 25 hrs)", {
    let clock = create 5 32
  expect_equal(subtract 1500 clock |> display, "04:32")
})

test_that("Subtract more than two days", {
    let clock = create 2 20
  expect_equal(subtract 3000 clock |> display, "00:20")
})

test_that("Clocks with same time", {
    let clock1 = create 15 37
    let clock2 = create 15 37
  expect_equal(clock1 = clock2, TRUE)
})

test_that("Clocks a minute apart", {
    let clock1 = create 15 36
    let clock2 = create 15 37
  expect_equal(clock1 = clock2, FALSE)
})

test_that("Clocks an hour apart", {
    let clock1 = create 14 37
    let clock2 = create 15 37
  expect_equal(clock1 = clock2, FALSE)
})

test_that("Clocks with hour overflow", {
    let clock1 = create 10 37
    let clock2 = create 34 37
  expect_equal(clock1 = clock2, TRUE)
})

test_that("Clocks with hour overflow by several days", {
    let clock1 = create 3 11
    let clock2 = create 99 11
  expect_equal(clock1 = clock2, TRUE)
})

test_that("Clocks with negative hour", {
    let clock1 = create 22 40
    let clock2 = create -2 40
  expect_equal(clock1 = clock2, TRUE)
})

test_that("Clocks with negative hour that wraps", {
    let clock1 = create 17 3
    let clock2 = create -31 3
  expect_equal(clock1 = clock2, TRUE)
})

test_that("Clocks with negative hour that wraps multiple times", {
    let clock1 = create 13 49
    let clock2 = create -83 49
  expect_equal(clock1 = clock2, TRUE)
})

test_that("Clocks with minute overflow", {
    let clock1 = create 0 1
    let clock2 = create 0 1441
  expect_equal(clock1 = clock2, TRUE)
})

test_that("Clocks with minute overflow by several days", {
    let clock1 = create 2 2
    let clock2 = create 2 4322
  expect_equal(clock1 = clock2, TRUE)
})

test_that("Clocks with negative minute", {
    let clock1 = create 2 40
    let clock2 = create 3 -20
  expect_equal(clock1 = clock2, TRUE)
})

test_that("Clocks with negative minute that wraps", {
    let clock1 = create 4 10
    let clock2 = create 5 -1490
  expect_equal(clock1 = clock2, TRUE)
})

test_that("Clocks with negative minute that wraps multiple times", {
    let clock1 = create 6 15
    let clock2 = create 6 -4305
  expect_equal(clock1 = clock2, TRUE)
})

test_that("Clocks with negative hours and minutes", {
    let clock1 = create 7 32
    let clock2 = create -12 -268
  expect_equal(clock1 = clock2, TRUE)
})

test_that("Clocks with negative hours and minutes that wrap", {
    let clock1 = create 18 7
    let clock2 = create -54 -11513
  expect_equal(clock1 = clock2, TRUE)
})

test_that("Full clock and zeroed clock", {
    let clock1 = create 24 0
    let clock2 = create 0 0
  expect_equal(clock1 = clock2, TRUE)

