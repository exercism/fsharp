source("./resistor-color-duo.R")
library(testthat)

let ``Brown and black`` () =
    value ["brown"; "black"] |> should equal 10

let ``Blue and grey`` () =
    value ["blue"; "grey"] |> should equal 68

let ``Yellow and violet`` () =
    value ["yellow"; "violet"] |> should equal 47

let ``White and red`` () =
    value ["white"; "red"] |> should equal 92

let ``Orange and orange`` () =
    value ["orange"; "orange"] |> should equal 33

let ``Ignore additional colors`` () =
    value ["green"; "brown"; "orange"] |> should equal 51

let ``Black and brown, one-digit`` () =
    value ["black"; "brown"] |> should equal 1

