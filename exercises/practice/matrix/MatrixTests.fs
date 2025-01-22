source("./matrix.R")
library(testthat)

let ``Extract row from one number matrix`` () =
    row 1 "1" |> should equal [1]

let ``Can extract row`` () =
    row 2 "1 2\n3 4" |> should equal [3; 4]

let ``Extract row where numbers have different widths`` () =
    row 2 "1 2\n10 20" |> should equal [10; 20]

let ``Can extract row from non-square matrix with no corresponding column`` () =
    row 4 "1 2 3\n4 5 6\n7 8 9\n8 7 6" |> should equal [8; 7; 6]

let ``Extract column from one number matrix`` () =
    column 1 "1" |> should equal [1]

let ``Can extract column`` () =
    column 3 "1 2 3\n4 5 6\n7 8 9" |> should equal [3; 6; 9]

let ``Can extract column from non-square matrix with no corresponding row`` () =
    column 4 "1 2 3 4\n5 6 7 8\n9 8 7 6" |> should equal [4; 8; 6]

let ``Extract column where numbers have different widths`` () =
    column 2 "89 1903 3\n18 3 1\n9 4 800" |> should equal [1903; 3; 4]

