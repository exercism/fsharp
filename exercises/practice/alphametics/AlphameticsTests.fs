source("./alphametics.R")
library(testthat)

let ``Puzzle with three letters`` () =
    puzzle <- "I + BB == ILL"
    expected <- 
        [ ('I', 1);
          ('B', 9);
          ('L', 0) ]
        |> Map.ofList
        |> Some
    expect_equal(solve puzzle, expected)

let ``Solution must have unique value for each letter`` () =
    puzzle <- "A == B"
    expected <- None
    expect_equal(solve puzzle, expected)

let ``Leading zero solution is invalid`` () =
    puzzle <- "ACA + DD == BD"
    expected <- None
    expect_equal(solve puzzle, expected)

let ``Puzzle with two digits final carry`` () =
    puzzle <- "A + A + A + A + A + A + A + A + A + A + A + B == BCC"
    expected <- 
        [ ('A', 9);
          ('B', 1);
          ('C', 0) ]
        |> Map.ofList
        |> Some
    expect_equal(solve puzzle, expected)

let ``Puzzle with four letters`` () =
    puzzle <- "AS + A == MOM"
    expected <- 
        [ ('A', 9);
          ('S', 2);
          ('M', 1);
          ('O', 0) ]
        |> Map.ofList
        |> Some
    expect_equal(solve puzzle, expected)

let ``Puzzle with six letters`` () =
    puzzle <- "NO + NO + TOO == LATE"
    expected <- 
        [ ('N', 7);
          ('O', 4);
          ('T', 9);
          ('L', 1);
          ('A', 0);
          ('E', 2) ]
        |> Map.ofList
        |> Some
    expect_equal(solve puzzle, expected)

let ``Puzzle with seven letters`` () =
    puzzle <- "HE + SEES + THE == LIGHT"
    expected <- 
        [ ('E', 4);
          ('G', 2);
          ('H', 5);
          ('I', 0);
          ('L', 1);
          ('S', 9);
          ('T', 7) ]
        |> Map.ofList
        |> Some
    expect_equal(solve puzzle, expected)

let ``Puzzle with eight letters`` () =
    puzzle <- "SEND + MORE == MONEY"
    expected <- 
        [ ('S', 9);
          ('E', 5);
          ('N', 6);
          ('D', 7);
          ('M', 1);
          ('O', 0);
          ('R', 8);
          ('Y', 2) ]
        |> Map.ofList
        |> Some
    expect_equal(solve puzzle, expected)

let ``Puzzle with ten letters`` () =
    puzzle <- "AND + A + STRONG + OFFENSE + AS + A + GOOD == DEFENSE"
    expected <- 
        [ ('A', 5);
          ('D', 3);
          ('E', 4);
          ('F', 7);
          ('G', 8);
          ('N', 0);
          ('O', 2);
          ('R', 1);
          ('S', 6);
          ('T', 9) ]
        |> Map.ofList
        |> Some
    expect_equal(solve puzzle, expected)

let ``Puzzle with ten letters and 199 addends`` () =
    puzzle <- "THIS + A + FIRE + THEREFORE + FOR + ALL + HISTORIES + I + TELL + A + TALE + THAT + FALSIFIES + ITS + TITLE + TIS + A + LIE + THE + TALE + OF + THE + LAST + FIRE + HORSES + LATE + AFTER + THE + FIRST + FATHERS + FORESEE + THE + HORRORS + THE + LAST + FREE + TROLL + TERRIFIES + THE + HORSES + OF + FIRE + THE + TROLL + RESTS + AT + THE + HOLE + OF + LOSSES + IT + IS + THERE + THAT + SHE + STORES + ROLES + OF + LEATHERS + AFTER + SHE + SATISFIES + HER + HATE + OFF + THOSE + FEARS + A + TASTE + RISES + AS + SHE + HEARS + THE + LEAST + FAR + HORSE + THOSE + FAST + HORSES + THAT + FIRST + HEAR + THE + TROLL + FLEE + OFF + TO + THE + FOREST + THE + HORSES + THAT + ALERTS + RAISE + THE + STARES + OF + THE + OTHERS + AS + THE + TROLL + ASSAILS + AT + THE + TOTAL + SHIFT + HER + TEETH + TEAR + HOOF + OFF + TORSO + AS + THE + LAST + HORSE + FORFEITS + ITS + LIFE + THE + FIRST + FATHERS + HEAR + OF + THE + HORRORS + THEIR + FEARS + THAT + THE + FIRES + FOR + THEIR + FEASTS + ARREST + AS + THE + FIRST + FATHERS + RESETTLE + THE + LAST + OF + THE + FIRE + HORSES + THE + LAST + TROLL + HARASSES + THE + FOREST + HEART + FREE + AT + LAST + OF + THE + LAST + TROLL + ALL + OFFER + THEIR + FIRE + HEAT + TO + THE + ASSISTERS + FAR + OFF + THE + TROLL + FASTS + ITS + LIFE + SHORTER + AS + STARS + RISE + THE + HORSES + REST + SAFE + AFTER + ALL + SHARE + HOT + FISH + AS + THEIR + AFFILIATES + TAILOR + A + ROOFS + FOR + THEIR + SAFE == FORTRESSES"
    expected <- 
        [ ('A', 1);
          ('E', 0);
          ('F', 5);
          ('H', 8);
          ('I', 7);
          ('L', 2);
          ('O', 6);
          ('R', 3);
          ('S', 4);
          ('T', 9) ]
        |> Map.ofList
        |> Some
    expect_equal(solve puzzle, expected)

