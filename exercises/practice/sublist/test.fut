import "sublist"

let ``Empty lists`` () =
    let list_one = []
    let list_two = []
    sublist listOne listTwo |> should equal SublistType.Equal

let ``Empty list within non empty list`` () =
    let list_one = []
    let list_two = [1, 2, 3]
    sublist listOne listTwo |> should equal SublistType.Sublist

let ``Non empty list contains empty list`` () =
    let list_one = [1, 2, 3]
    let list_two = []
    sublist listOne listTwo |> should equal SublistType.Superlist

let ``List equals itself`` () =
    let list_one = [1, 2, 3]
    let list_two = [1, 2, 3]
    sublist listOne listTwo |> should equal SublistType.Equal

let ``Different lists`` () =
    let list_one = [1, 2, 3]
    let list_two = [2, 3, 4]
    sublist listOne listTwo |> should equal SublistType.Unequal

let ``False start`` () =
    let list_one = [1, 2, 5]
    let list_two = [0, 1, 2, 3, 1, 2, 5, 6]
    sublist listOne listTwo |> should equal SublistType.Sublist

let ``Consecutive`` () =
    let list_one = [1, 1, 2]
    let list_two = [0, 1, 1, 1, 2, 1, 2]
    sublist listOne listTwo |> should equal SublistType.Sublist

let ``Sublist at start`` () =
    let list_one = [0, 1, 2]
    let list_two = [0, 1, 2, 3, 4, 5]
    sublist listOne listTwo |> should equal SublistType.Sublist

let ``Sublist in middle`` () =
    let list_one = [2, 3, 4]
    let list_two = [0, 1, 2, 3, 4, 5]
    sublist listOne listTwo |> should equal SublistType.Sublist

let ``Sublist at end`` () =
    let list_one = [3, 4, 5]
    let list_two = [0, 1, 2, 3, 4, 5]
    sublist listOne listTwo |> should equal SublistType.Sublist

let ``At start of superlist`` () =
    let list_one = [0, 1, 2, 3, 4, 5]
    let list_two = [0, 1, 2]
    sublist listOne listTwo |> should equal SublistType.Superlist

let ``In middle of superlist`` () =
    let list_one = [0, 1, 2, 3, 4, 5]
    let list_two = [2, 3]
    sublist listOne listTwo |> should equal SublistType.Superlist

let ``At end of superlist`` () =
    let list_one = [0, 1, 2, 3, 4, 5]
    let list_two = [3, 4, 5]
    sublist listOne listTwo |> should equal SublistType.Superlist

let ``First list missing element from second list`` () =
    let list_one = [1, 3]
    let list_two = [1, 2, 3]
    sublist listOne listTwo |> should equal SublistType.Unequal

let ``Second list missing element from first list`` () =
    let list_one = [1, 2, 3]
    let list_two = [1, 3]
    sublist listOne listTwo |> should equal SublistType.Unequal

let ``First list missing additional digits from second list`` () =
    let list_one = [1, 2]
    let list_two = [1, 22]
    sublist listOne listTwo |> should equal SublistType.Unequal

let ``Order matters to a list`` () =
    let list_one = [1, 2, 3]
    let list_two = [3, 2, 1]
    sublist listOne listTwo |> should equal SublistType.Unequal

let ``Same digits but different numbers`` () =
    let list_one = [1, 0, 1]
    let list_two = [10, 1]
    sublist listOne listTwo |> should equal SublistType.Unequal

