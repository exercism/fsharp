source("./satellite.R")
library(testthat)

let ``Empty tree`` () =
    let expected: Result<Tree,string> = Ok (
        Empty
    )
    expect_equal(treeFromTraversals [] [], expected)

let ``Tree with one item`` () =
    let expected: Result<Tree,string> = Ok (
        Node("a", Empty, Empty)
    )
    expect_equal(treeFromTraversals ["a"] ["a"], expected)

let ``Tree with many items`` () =
    let expected: Result<Tree,string> = Ok (
        Node(
            "a",
            Node("i", Empty, Empty),
            Node(
                "x",
                Node("f", Empty, Empty),
                Node("r", Empty, Empty)
            )
        )
    )
    expect_equal(treeFromTraversals ["i"; "a"; "f"; "x"; "r"] ["a"; "i"; "x"; "f"; "r"], expected)

let ``Reject traversals of different length`` () =
    let expected: Result<Tree,string> = Error "traversals must have the same length"
    expect_equal(treeFromTraversals ["b"; "a"; "r"] ["a"; "b"], expected)

let ``Reject inconsistent traversals of same length`` () =
    let expected: Result<Tree,string> = Error "traversals must have the same elements"
    expect_equal(treeFromTraversals ["a"; "b"; "c"] ["x"; "y"; "z"], expected)

let ``Reject traversals with repeated items`` () =
    let expected: Result<Tree,string> = Error "traversals must contain unique items"
    expect_equal(treeFromTraversals ["b"; "a"; "a"] ["a"; "b"; "a"], expected)

