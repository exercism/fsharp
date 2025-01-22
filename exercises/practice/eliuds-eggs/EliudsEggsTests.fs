source("./eliuds-eggs.R")
library(testthat)

let ``0 eggs`` () =
    expect_equal(eggCount 0, 0)

let ``1 egg`` () =
    expect_equal(eggCount 16, 1)

let ``4 eggs`` () =
    expect_equal(eggCount 89, 4)

let ``13 eggs`` () =
    expect_equal(eggCount 2000000000, 13)

