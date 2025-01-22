source("./hello-world.R")
library(testthat)

let ``Say Hi!`` () =
    expect_equal(hello, "Hello, World!")

