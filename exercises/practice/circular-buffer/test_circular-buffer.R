source("./circular-buffer.R")
library(testthat)

test_that("Reading empty buffer should fail", {
    let buffer1 = mkCircularBuffer 1
    (fun () -> read buffer1 |> ignore) |> should throw typeof<Exception>
})

test_that("Can read an item just written", {
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let (val3, _) = read buffer2
  expect_equal(val3, 1)
})

test_that("Each item may only be read once", {
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let (val3, buffer3) = read buffer2
  expect_equal(val3, 1)
    (fun () -> read buffer3 |> ignore) |> should throw typeof<Exception>
})

test_that("Items are read in the order they are written", {
    let buffer1 = mkCircularBuffer 2
    let buffer2 = write 1 buffer1
    let buffer3 = write 2 buffer2
    let (val4, buffer4) = read buffer3
  expect_equal(val4, 1)
    let (val5, _) = read buffer4
  expect_equal(val5, 2)
})

test_that("Full buffer can't be written to", {
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    (fun () -> write 2 buffer2 |> ignore) |> should throw typeof<Exception>
})

test_that("A read frees up capacity for another write", {
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let (val3, buffer3) = read buffer2
  expect_equal(val3, 1)
    let buffer4 = write 2 buffer3
    let (val5, _) = read buffer4
  expect_equal(val5, 2)
})

test_that("Read position is maintained even across multiple writes", {
    let buffer1 = mkCircularBuffer 3
    let buffer2 = write 1 buffer1
    let buffer3 = write 2 buffer2
    let (val4, buffer4) = read buffer3
  expect_equal(val4, 1)
    let buffer5 = write 3 buffer4
    let (val6, buffer6) = read buffer5
  expect_equal(val6, 2)
    let (val7, _) = read buffer6
  expect_equal(val7, 3)
})

test_that("Items cleared out of buffer can't be read", {
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let buffer3 = clear buffer2
    (fun () -> read buffer3 |> ignore) |> should throw typeof<Exception>
})

test_that("Clear frees up capacity for another write", {
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let buffer3 = clear buffer2
    let buffer4 = write 2 buffer3
    let (val5, _) = read buffer4
  expect_equal(val5, 2)
})

test_that("Clear does nothing on empty buffer", {
    let buffer1 = mkCircularBuffer 1
    let buffer2 = clear buffer1
    let buffer3 = write 1 buffer2
    let (val4, _) = read buffer3
  expect_equal(val4, 1)
})

test_that("Overwrite acts like write on non-full buffer", {
    let buffer1 = mkCircularBuffer 2
    let buffer2 = write 1 buffer1
    let buffer3 = forceWrite 2 buffer2
    let (val4, buffer4) = read buffer3
  expect_equal(val4, 1)
    let (val5, _) = read buffer4
  expect_equal(val5, 2)
})

test_that("Overwrite replaces the oldest item on full buffer", {
    let buffer1 = mkCircularBuffer 2
    let buffer2 = write 1 buffer1
    let buffer3 = write 2 buffer2
    let buffer4 = forceWrite 3 buffer3
    let (val5, buffer5) = read buffer4
  expect_equal(val5, 2)
    let (val6, _) = read buffer5
  expect_equal(val6, 3)
})

test_that("Overwrite replaces the oldest item remaining in buffer following a read", {
    let buffer1 = mkCircularBuffer 3
    let buffer2 = write 1 buffer1
    let buffer3 = write 2 buffer2
    let buffer4 = write 3 buffer3
    let (val5, buffer5) = read buffer4
  expect_equal(val5, 1)
    let buffer6 = write 4 buffer5
    let buffer7 = forceWrite 5 buffer6
    let (val8, buffer8) = read buffer7
  expect_equal(val8, 3)
    let (val9, buffer9) = read buffer8
  expect_equal(val9, 4)
    let (val10, _) = read buffer9
  expect_equal(val10, 5)
})

test_that("Initial clear does not affect wrapping around", {
    let buffer1 = mkCircularBuffer 2
    let buffer2 = clear buffer1
    let buffer3 = write 1 buffer2
    let buffer4 = write 2 buffer3
    let buffer5 = forceWrite 3 buffer4
    let buffer6 = forceWrite 4 buffer5
    let (val7, buffer7) = read buffer6
  expect_equal(val7, 3)
    let (val8, buffer8) = read buffer7
  expect_equal(val8, 4)
    (fun () -> read buffer8 |> ignore) |> should throw typeof<Exception>

