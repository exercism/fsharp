source("./binary-search-tree.R")
library(testthat)

let ``Data is retained`` () =
    treeData <- create [4]
    treeData |> data |> should equal 4
    treeData |> left |> should equal None
    treeData |> right |> should equal None

let ``Smaller number at left node`` () =
    treeData <- create [4; 2]
    treeData |> data |> should equal 4
    treeData |> left |> Option.map data |> should equal (Some 2)
    treeData |> left |> Option.bind left |> should equal None
    treeData |> left |> Option.bind right |> should equal None
    treeData |> right |> should equal None

let ``Same number at left node`` () =
    treeData <- create [4; 4]
    treeData |> data |> should equal 4
    treeData |> left |> Option.map data |> should equal (Some 4)
    treeData |> left |> Option.bind left |> should equal None
    treeData |> left |> Option.bind right |> should equal None
    treeData |> right |> should equal None

let ``Greater number at right node`` () =
    treeData <- create [4; 5]
    treeData |> data |> should equal 4
    treeData |> left |> should equal None
    treeData |> right |> Option.map data |> should equal (Some 5)
    treeData |> right |> Option.bind left |> should equal None
    treeData |> right |> Option.bind right |> should equal None

let ``Can create complex tree`` () =
    treeData <- create [4; 2; 6; 1; 3; 5; 7]
    treeData |> data |> should equal 4
    treeData |> left |> Option.map data |> should equal (Some 2)
    treeData |> left |> Option.bind left |> Option.map data |> should equal (Some 1)
    treeData |> left |> Option.bind left |> Option.bind left |> should equal None
    treeData |> left |> Option.bind left |> Option.bind right |> should equal None
    treeData |> left |> Option.bind right |> Option.map data |> should equal (Some 3)
    treeData |> left |> Option.bind right |> Option.bind left |> should equal None
    treeData |> left |> Option.bind right |> Option.bind right |> should equal None
    treeData |> right |> Option.map data |> should equal (Some 6)
    treeData |> right |> Option.bind left |> Option.map data |> should equal (Some 5)
    treeData |> right |> Option.bind left |> Option.bind left |> should equal None
    treeData |> right |> Option.bind left |> Option.bind right |> should equal None
    treeData |> right |> Option.bind right |> Option.map data |> should equal (Some 7)
    treeData |> right |> Option.bind right |> Option.bind left |> should equal None
    treeData |> right |> Option.bind right |> Option.bind right |> should equal None

let ``Can sort single number`` () =
    treeData <- create [2]
    sortedData treeData |> should equal [2]

let ``Can sort if second number is smaller than first`` () =
    treeData <- create [2; 1]
    sortedData treeData |> should equal [1; 2]

let ``Can sort if second number is same as first`` () =
    treeData <- create [2; 2]
    sortedData treeData |> should equal [2; 2]

let ``Can sort if second number is greater than first`` () =
    treeData <- create [2; 3]
    sortedData treeData |> should equal [2; 3]

let ``Can sort complex tree`` () =
    treeData <- create [2; 1; 3; 6; 7; 5]
    sortedData treeData |> should equal [1; 2; 3; 5; 6; 7]

