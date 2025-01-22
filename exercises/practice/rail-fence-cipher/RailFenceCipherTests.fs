source("./rail-fence-cipher.R")
library(testthat)

test_that("Encode with two rails", {
    rails <- 2
    msg <- "XOXOXOXOXOXOXOXOXO"
    expected <- "XXXXXXXXXOOOOOOOOO"
    expect_equal(encode rails msg, expected)

test_that("Encode with three rails", {
    rails <- 3
    msg <- "WEAREDISCOVEREDFLEEATONCE"
    expected <- "WECRLTEERDSOEEFEAOCAIVDEN"
    expect_equal(encode rails msg, expected)

test_that("Encode with ending in the middle", {
    rails <- 4
    msg <- "EXERCISES"
    expected <- "ESXIEECSR"
    expect_equal(encode rails msg, expected)

test_that("Decode with three rails", {
    rails <- 3
    msg <- "TEITELHDVLSNHDTISEIIEA"
    expected <- "THEDEVILISINTHEDETAILS"
    expect_equal(decode rails msg, expected)

test_that("Decode with five rails", {
    rails <- 5
    msg <- "EIEXMSMESAORIWSCE"
    expected <- "EXERCISMISAWESOME"
    expect_equal(decode rails msg, expected)

test_that("Decode with six rails", {
    rails <- 6
    msg <- "133714114238148966225439541018335470986172518171757571896261"
    expected <- "112358132134558914423337761098715972584418167651094617711286"
    expect_equal(decode rails msg, expected)

