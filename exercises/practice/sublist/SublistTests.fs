source("./sublist.R")
library(testthat)

let ``Empty lists`` () =
    let listOne = []
    let listTwo = []
    sublist listOne listTwo |> should equal SublistType.Equal

let ``Empty list within non empty list`` () =
    let listOne = []
    let listTwo = [1; 2; 3]
    sublist listOne listTwo |> should equal SublistType.Sublist

let ``Non empty list contains empty list`` () =
    let listOne = [1; 2; 3]
    let listTwo = []
    sublist listOne listTwo |> should equal SublistType.Superlist

let ``List equals itself`` () =
    let listOne = [1; 2; 3]
    let listTwo = [1; 2; 3]
    sublist listOne listTwo |> should equal SublistType.Equal

let ``Different lists`` () =
    let listOne = [1; 2; 3]
    let listTwo = [2; 3; 4]
    sublist listOne listTwo |> should equal SublistType.Unequal

let ``False start`` () =
    let listOne = [1; 2; 5]
    let listTwo = [0; 1; 2; 3; 1; 2; 5; 6]
    sublist listOne listTwo |> should equal SublistType.Sublist

let ``Consecutive`` () =
    let listOne = [1; 1; 2]
    let listTwo = [0; 1; 1; 1; 2; 1; 2]
    sublist listOne listTwo |> should equal SublistType.Sublist

let ``Sublist at start`` () =
    let listOne = [0; 1; 2]
    let listTwo = [0; 1; 2; 3; 4; 5]
    sublist listOne listTwo |> should equal SublistType.Sublist

let ``Sublist in middle`` () =
    let listOne = [2; 3; 4]
    let listTwo = [0; 1; 2; 3; 4; 5]
    sublist listOne listTwo |> should equal SublistType.Sublist

let ``Sublist at end`` () =
    let listOne = [3; 4; 5]
    let listTwo = [0; 1; 2; 3; 4; 5]
    sublist listOne listTwo |> should equal SublistType.Sublist

let ``At start of superlist`` () =
    let listOne = [0; 1; 2; 3; 4; 5]
    let listTwo = [0; 1; 2]
    sublist listOne listTwo |> should equal SublistType.Superlist

let ``In middle of superlist`` () =
    let listOne = [0; 1; 2; 3; 4; 5]
    let listTwo = [2; 3]
    sublist listOne listTwo |> should equal SublistType.Superlist

let ``At end of superlist`` () =
    let listOne = [0; 1; 2; 3; 4; 5]
    let listTwo = [3; 4; 5]
    sublist listOne listTwo |> should equal SublistType.Superlist

let ``First list missing element from second list`` () =
    let listOne = [1; 3]
    let listTwo = [1; 2; 3]
    sublist listOne listTwo |> should equal SublistType.Unequal

let ``Second list missing element from first list`` () =
    let listOne = [1; 2; 3]
    let listTwo = [1; 3]
    sublist listOne listTwo |> should equal SublistType.Unequal

let ``First list missing additional digits from second list`` () =
    let listOne = [1; 2]
    let listTwo = [1; 22]
    sublist listOne listTwo |> should equal SublistType.Unequal

let ``Order matters to a list`` () =
    let listOne = [1; 2; 3]
    let listTwo = [3; 2; 1]
    sublist listOne listTwo |> should equal SublistType.Unequal

let ``Same digits but different numbers`` () =
    let listOne = [1; 0; 1]
    let listTwo = [10; 1]
    sublist listOne listTwo |> should equal SublistType.Unequal

