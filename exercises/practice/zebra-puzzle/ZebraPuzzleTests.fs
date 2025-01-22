source("./zebra-puzzle.R")
library(testthat)

let ``Resident who drinks water`` () =
    expect_equal(drinksWater, Norwegian)

let ``Resident who owns zebra`` () =
    expect_equal(ownsZebra, Japanese)

