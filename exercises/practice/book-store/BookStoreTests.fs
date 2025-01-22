source("./book-store.R")
library(testthat)

let ``Only a single book`` () =
    total [1] |> should equal 8.00m

let ``Two of the same book`` () =
    total [2; 2] |> should equal 16.00m

let ``Empty basket`` () =
    total [] |> should equal 0.00m

let ``Two different books`` () =
    total [1; 2] |> should equal 15.20m

let ``Three different books`` () =
    total [1; 2; 3] |> should equal 21.60m

let ``Four different books`` () =
    total [1; 2; 3; 4] |> should equal 25.60m

let ``Five different books`` () =
    total [1; 2; 3; 4; 5] |> should equal 30.00m

let ``Two groups of four is cheaper than group of five plus group of three`` () =
    total [1; 1; 2; 2; 3; 3; 4; 5] |> should equal 51.20m

let ``Two groups of four is cheaper than groups of five and three`` () =
    total [1; 1; 2; 3; 4; 4; 5; 5] |> should equal 51.20m

let ``Group of four plus group of two is cheaper than two groups of three`` () =
    total [1; 1; 2; 2; 3; 4] |> should equal 40.80m

let ``Two each of first four books and one copy each of rest`` () =
    total [1; 1; 2; 2; 3; 3; 4; 4; 5] |> should equal 55.60m

let ``Two copies of each book`` () =
    total [1; 1; 2; 2; 3; 3; 4; 4; 5; 5] |> should equal 60.00m

let ``Three copies of first book and two each of remaining`` () =
    total [1; 1; 2; 2; 3; 3; 4; 4; 5; 5; 1] |> should equal 68.00m

let ``Three each of first two books and two each of remaining books`` () =
    total [1; 1; 2; 2; 3; 3; 4; 4; 5; 5; 1; 2] |> should equal 75.20m

let ``Four groups of four are cheaper than two groups each of five and three`` () =
    total [1; 1; 2; 2; 3; 3; 4; 5; 1; 1; 2; 2; 3; 3; 4; 5] |> should equal 102.40m

let ``Check that groups of four are created properly even when there are more groups of three than groups of five`` () =
    total [1; 1; 1; 1; 1; 1; 2; 2; 2; 2; 2; 2; 3; 3; 3; 3; 3; 3; 4; 4; 5; 5] |> should equal 145.60m

let ``One group of one and four is cheaper than one group of two and three`` () =
    total [1; 1; 2; 3; 4] |> should equal 33.60m

let ``One group of one and two plus three groups of four is cheaper than one group of each size`` () =
    total [1; 2; 2; 3; 3; 3; 4; 4; 4; 4; 5; 5; 5; 5; 5] |> should equal 100.00m

