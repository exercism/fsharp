source("./resistor-color-duo.R")
library(testthat)

let ``Brown and black`` () =
    expect_equal(value ["brown"; "black"], 10)

let ``Blue and grey`` () =
    expect_equal(value ["blue"; "grey"], 68)

let ``Yellow and violet`` () =
    expect_equal(value ["yellow"; "violet"], 47)

let ``White and red`` () =
    expect_equal(value ["white"; "red"], 92)

let ``Orange and orange`` () =
    expect_equal(value ["orange"; "orange"], 33)

let ``Ignore additional colors`` () =
    expect_equal(value ["green"; "brown"; "orange"], 51)

let ``Black and brown, one-digit`` () =
    expect_equal(value ["black"; "brown"], 1)

