source("./atbash-cipher.R")
library(testthat)

test_that("Encode yes", {
  expect_equal(encode("yes", "bvh"))
})

test_that("Encode no", {
  expect_equal(encode("no", "ml"))
})

test_that("Encode OMG", {
  expect_equal(encode("OMG", "lnt"))
})

test_that("Encode spaces", {
  expect_equal(encode "O M G", "lnt")
})

test_that("Encode mindblowingly", {
  expect_equal(encode "mindblowingly", "nrmwy oldrm tob")
})

test_that("Encode numbers", {
  expect_equal(encode "Testing,1 2 3, testing.", "gvhgr mt123 gvhgr mt")
})

test_that("Encode deep thought", {
  expect_equal(encode "Truth is fiction.", "gifgs rhurx grlm")
})

test_that("Encode all the letters", {
  expect_equal(encode "The quick brown fox jumps over the lazy dog.", "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt")
})

test_that("Decode exercism", {
  expect_equal(decode "vcvix rhn", "exercism")
})

test_that("Decode a sentence", {
  expect_equal(decode "zmlyh gzxov rhlug vmzhg vkkrm thglm v", "anobstacleisoftenasteppingstone")
})

test_that("Decode numbers", {
  expect_equal(decode "gvhgr mt123 gvhgr mt", "testing123testing")
})

test_that("Decode all the letters", {
  expect_equal(decode "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt", "thequickbrownfoxjumpsoverthelazydog")
})

test_that("Decode with too many spaces", {
  expect_equal(decode "vc vix    r hn", "exercism")
})

test_that("Decode with no spaces", {
  expect_equal(decode("zmlyhgzxovrhlugvmzhgvkkrmthglmv", "anobstacleisoftenasteppingstone"))
})
