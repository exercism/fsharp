source("./sublist.R")
library(testthat)

let ``Empty lists`` () =
    listOne <- []
    listTwo <- []
    expect_equal(sublist listOne listTwo, SublistType.Equal)

let ``Empty list within non empty list`` () =
    listOne <- []
    listTwo <- [1; 2; 3]
    expect_equal(sublist listOne listTwo, SublistType.Sublist)

let ``Non empty list contains empty list`` () =
    listOne <- [1; 2; 3]
    listTwo <- []
    expect_equal(sublist listOne listTwo, SublistType.Superlist)

let ``List equals itself`` () =
    listOne <- [1; 2; 3]
    listTwo <- [1; 2; 3]
    expect_equal(sublist listOne listTwo, SublistType.Equal)

let ``Different lists`` () =
    listOne <- [1; 2; 3]
    listTwo <- [2; 3; 4]
    expect_equal(sublist listOne listTwo, SublistType.Unequal)

let ``False start`` () =
    listOne <- [1; 2; 5]
    listTwo <- [0; 1; 2; 3; 1; 2; 5; 6]
    expect_equal(sublist listOne listTwo, SublistType.Sublist)

let ``Consecutive`` () =
    listOne <- [1; 1; 2]
    listTwo <- [0; 1; 1; 1; 2; 1; 2]
    expect_equal(sublist listOne listTwo, SublistType.Sublist)

let ``Sublist at start`` () =
    listOne <- [0; 1; 2]
    listTwo <- [0; 1; 2; 3; 4; 5]
    expect_equal(sublist listOne listTwo, SublistType.Sublist)

let ``Sublist in middle`` () =
    listOne <- [2; 3; 4]
    listTwo <- [0; 1; 2; 3; 4; 5]
    expect_equal(sublist listOne listTwo, SublistType.Sublist)

let ``Sublist at end`` () =
    listOne <- [3; 4; 5]
    listTwo <- [0; 1; 2; 3; 4; 5]
    expect_equal(sublist listOne listTwo, SublistType.Sublist)

let ``At start of superlist`` () =
    listOne <- [0; 1; 2; 3; 4; 5]
    listTwo <- [0; 1; 2]
    expect_equal(sublist listOne listTwo, SublistType.Superlist)

let ``In middle of superlist`` () =
    listOne <- [0; 1; 2; 3; 4; 5]
    listTwo <- [2; 3]
    expect_equal(sublist listOne listTwo, SublistType.Superlist)

let ``At end of superlist`` () =
    listOne <- [0; 1; 2; 3; 4; 5]
    listTwo <- [3; 4; 5]
    expect_equal(sublist listOne listTwo, SublistType.Superlist)

let ``First list missing element from second list`` () =
    listOne <- [1; 3]
    listTwo <- [1; 2; 3]
    expect_equal(sublist listOne listTwo, SublistType.Unequal)

let ``Second list missing element from first list`` () =
    listOne <- [1; 2; 3]
    listTwo <- [1; 3]
    expect_equal(sublist listOne listTwo, SublistType.Unequal)

let ``First list missing additional digits from second list`` () =
    listOne <- [1; 2]
    listTwo <- [1; 22]
    expect_equal(sublist listOne listTwo, SublistType.Unequal)

let ``Order matters to a list`` () =
    listOne <- [1; 2; 3]
    listTwo <- [3; 2; 1]
    expect_equal(sublist listOne listTwo, SublistType.Unequal)

let ``Same digits but different numbers`` () =
    listOne <- [1; 0; 1]
    listTwo <- [10; 1]
    expect_equal(sublist listOne listTwo, SublistType.Unequal)

