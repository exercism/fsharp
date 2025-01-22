source("./resistor-color.R")
library(testthat)

let ``Black`` () =
    expect_equal(colorCode "black", 0)

let ``White`` () =
    expect_equal(colorCode "white", 9)

let ``Orange`` () =
    expect_equal(colorCode "orange", 3)

let ``Colors`` () =
    expect_equal(colors, ["black"; "brown"; "red"; "orange"; "yellow"; "green"; "blue"; "violet"; "grey"; "white"])

