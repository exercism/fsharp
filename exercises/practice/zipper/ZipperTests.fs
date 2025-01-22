source("./zipper.R")
library(testthat)

let subTree value left right = Some (tree value left right)
let leaf value = subTree value None None

let ``Data is retained`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- tree 1 (subTree 2 None (leaf 3)) (leaf 4)
    actual <- zipper |> toTree
    expect_equal(actual, expected)

let ``Left, right and value`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- 3
    actual <- zipper |> left |> Option.get |> right |> Option.get |> value
    expect_equal(actual, expected)

let ``Dead end`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- None
    actual <- zipper |> left |> Option.get |> left
    expect_equal(actual, expected)

let ``Tree from deep focus`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- tree 1 (subTree 2 None (leaf 3)) (leaf 4)
    actual <- zipper |> left |> Option.get |> right |> Option.get |> toTree
    expect_equal(actual, expected)

let ``Traversing up from top`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- None
    actual <- zipper |> up
    expect_equal(actual, expected)

let ``Left, right, and up`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- 3
    actual <- zipper |> left |> Option.get |> up |> Option.get |> right |> Option.get |> up |> Option.get |> left |> Option.get |> right |> Option.get |> value
    expect_equal(actual, expected)

let ``Test ability to descend multiple levels and return`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- 1
    actual <- zipper |> left |> Option.get |> right |> Option.get |> up |> Option.get |> up |> Option.get |> value
    expect_equal(actual, expected)

let ``Set value`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- tree 1 (subTree 5 None (leaf 3)) (leaf 4)
    actual <- zipper |> left |> Option.get |> setValue 5 |> toTree
    expect_equal(actual, expected)

let ``Set value after traversing up`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- tree 1 (subTree 5 None (leaf 3)) (leaf 4)
    actual <- zipper |> left |> Option.get |> right |> Option.get |> up |> Option.get |> setValue 5 |> toTree
    expect_equal(actual, expected)

let ``Set left with leaf`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- tree 1 (subTree 2 (leaf 5) (leaf 3)) (leaf 4)
    actual <- zipper |> left |> Option.get |> setLeft (Some (tree 5 None None)) |> toTree
    expect_equal(actual, expected)

let ``Set right with null`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- tree 1 (leaf 2) (leaf 4)
    actual <- zipper |> left |> Option.get |> setRight None |> toTree
    expect_equal(actual, expected)

let ``Set right with subtree`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- tree 1 (subTree 2 None (leaf 3)) (subTree 6 (leaf 7) (leaf 8))
    actual <- zipper |> setRight (Some (tree 6 (leaf 7) (leaf 8))) |> toTree
    expect_equal(actual, expected)

let ``Set value on deep focus`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- tree 1 (subTree 2 None (leaf 5)) (leaf 4)
    actual <- zipper |> left |> Option.get |> right |> Option.get |> setValue 5 |> toTree
    expect_equal(actual, expected)

let ``Different paths to same zipper`` () =
    zipper <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    expected <- fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4)) |> right
    actual <- zipper |> left |> Option.get |> up |> Option.get |> right
    expect_equal(actual, expected)

