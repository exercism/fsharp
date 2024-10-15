source("./rail-fence-cipher.R")
library(testthat)

test_that("Encode with two rails", {
    let rails = 2
    let msg = "XOXOXOXOXOXOXOXOXO"
    expected <-"XXXXXXXXXOOOOOOOOO"
  expect_equal(encode rails msg, expected)
})

test_that("Encode with three rails", {
    let rails = 3
    let msg = "WEAREDISCOVEREDFLEEATONCE"
    expected <-"WECRLTEERDSOEEFEAOCAIVDEN"
  expect_equal(encode rails msg, expected)
})

test_that("Encode with ending in the middle", {
    let rails = 4
    let msg = "EXERCISES"
    expected <-"ESXIEECSR"
  expect_equal(encode rails msg, expected)
})

test_that("Decode with three rails", {
    let rails = 3
    let msg = "TEITELHDVLSNHDTISEIIEA"
    expected <-"THEDEVILISINTHEDETAILS"
  expect_equal(decode rails msg, expected)
})

test_that("Decode with five rails", {
    let rails = 5
    let msg = "EIEXMSMESAORIWSCE"
    expected <-"EXERCISMISAWESOME"
  expect_equal(decode rails msg, expected)
})

test_that("Decode with six rails", {
    let rails = 6
    let msg = "133714114238148966225439541018335470986172518171757571896261"
    expected <-"112358132134558914423337761098715972584418167651094617711286"
  expect_equal(decode rails msg, expected)

