source("./go-counting.R")
library(testthat)

let ``Black corner territory on 5x5 board`` () =
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (0, 1)
    expected <- Option.Some (Owner.Black, [(0, 0); (0, 1); (1, 0)])
    expect_equal(territory board position, expected)

let ``White center territory on 5x5 board`` () =
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (2, 3)
    expected <- Option.Some (Owner.White, [(2, 3)])
    expect_equal(territory board position, expected)

let ``Open corner territory on 5x5 board`` () =
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (1, 4)
    expected <- Option.Some (Owner.None, [(0, 3); (0, 4); (1, 4)])
    expect_equal(territory board position, expected)

let ``A stone and not a territory on 5x5 board`` () =
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (1, 1)
    let expected: (Owner * (int * int) list) option = Option.Some (Owner.None, [])
    expect_equal(territory board position, expected)

let ``Invalid because X is too low for 5x5 board`` () =
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (-1, 1)
    expected <- Option.None
    expect_equal(territory board position, expected)

let ``Invalid because X is too high for 5x5 board`` () =
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (5, 1)
    expected <- Option.None
    expect_equal(territory board position, expected)

let ``Invalid because Y is too low for 5x5 board`` () =
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (1, -1)
    expected <- Option.None
    expect_equal(territory board position, expected)

let ``Invalid because Y is too high for 5x5 board`` () =
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (1, 5)
    expected <- Option.None
    expect_equal(territory board position, expected)

let ``One territory is the whole board`` () =
    board <- [" "]
    expected <- 
        [ (Owner.Black, []);
          (Owner.White, []);
          (Owner.None, [(0, 0)]) ]
        |> Map.ofList
    expect_equal(territories board, expected)

let ``Two territory rectangular board`` () =
    board <- 
        [ " BW ";
          " BW " ]
    expected <- 
        [ (Owner.Black, [(0, 0); (0, 1)]);
          (Owner.White, [(3, 0); (3, 1)]);
          (Owner.None, []) ]
        |> Map.ofList
    expect_equal(territories board, expected)

let ``Two region rectangular board`` () =
    board <- [" B "]
    expected <- 
        [ (Owner.Black, [(0, 0); (2, 0)]);
          (Owner.White, []);
          (Owner.None, []) ]
        |> Map.ofList
    expect_equal(territories board, expected)

