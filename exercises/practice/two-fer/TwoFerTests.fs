source("./two-fer.R")
library(testthat)

let ``No name given`` () =
    expect_equal(twoFer None, "One for you, one for me.")

let ``A name given`` () =
    expect_equal(twoFer (Some "Alice"), "One for Alice, one for me.")

let ``Another name given`` () =
    expect_equal(twoFer (Some "Bob"), "One for Bob, one for me.")

