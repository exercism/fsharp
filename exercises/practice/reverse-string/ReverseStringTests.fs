source("./reverse-string.R")
library(testthat)

let ``An empty string`` () =
    expect_equal(reverse "", "")

let ``A word`` () =
    expect_equal(reverse "robot", "tobor")

let ``A capitalized word`` () =
    expect_equal(reverse "Ramen", "nemaR")

let ``A sentence with punctuation`` () =
    expect_equal(reverse "I'm hungry!", "!yrgnuh m'I")

let ``A palindrome`` () =
    expect_equal(reverse "racecar", "racecar")

let ``An even-sized word`` () =
    expect_equal(reverse "drawer", "reward")

