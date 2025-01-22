source("./resistor-color-trio.R")
library(testthat)

let ``Orange and orange and black`` () =
    expect_equal(label ["orange"; "orange"; "black"], "33 ohms")

let ``Blue and grey and brown`` () =
    expect_equal(label ["blue"; "grey"; "brown"], "680 ohms")

let ``Red and black and red`` () =
    expect_equal(label ["red"; "black"; "red"], "2 kiloohms")

let ``Green and brown and orange`` () =
    expect_equal(label ["green"; "brown"; "orange"], "51 kiloohms")

let ``Yellow and violet and yellow`` () =
    expect_equal(label ["yellow"; "violet"; "yellow"], "470 kiloohms")

let ``Blue and violet and blue`` () =
    expect_equal(label ["blue"; "violet"; "blue"], "67 megaohms")

let ``Minimum possible value`` () =
    expect_equal(label ["black"; "black"; "black"], "0 ohms")

let ``Maximum possible value`` () =
    expect_equal(label ["white"; "white"; "white"], "99 gigaohms")

let ``First two colors make an invalid octal number`` () =
    expect_equal(label ["black"; "grey"; "black"], "8 ohms")

let ``Ignore extra colors`` () =
    expect_equal(label ["blue"; "green"; "yellow"; "orange"], "650 kiloohms")

