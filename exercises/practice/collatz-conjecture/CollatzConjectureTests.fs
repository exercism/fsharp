source("./collatz-conjecture.R")
library(testthat)

let ``Zero steps for one`` () =
    expect_equal(steps 1, (Some 0))

let ``Divide if even`` () =
    expect_equal(steps 16, (Some 4))

let ``Even and odd steps`` () =
    expect_equal(steps 12, (Some 9))

let ``Large number of even and odd steps`` () =
    expect_equal(steps 1000000, (Some 152))

let ``Zero is an error`` () =
    expect_equal(steps 0, None)

let ``Negative value is an error`` () =
    expect_equal(steps -15, None)

