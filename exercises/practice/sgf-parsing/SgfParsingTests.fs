source("./sgf-parsing.R")
library(testthat)

let ``Empty input`` () =
    expected <- None
    expect_equal(parse "", expected)

let ``Tree with no nodes`` () =
    expected <- None
    expect_equal(parse "()", expected)

let ``Node without tree`` () =
    expected <- None
    expect_equal(parse ";", expected)

let ``Node without properties`` () =
    expected <- Some (Node (Map.ofList [], []))
    expect_equal(parse "(;)", expected)

let ``Single node tree`` () =
    expected <- Some (Node (Map.ofList [("A", ["B"])], []))
    expect_equal(parse "(;A[B])", expected)

let ``Multiple properties`` () =
    expected <- Some (Node (Map.ofList [("A", ["b"]); ("C", ["d"])], []))
    expect_equal(parse "(;A[b]C[d])", expected)

let ``Properties without delimiter`` () =
    expected <- None
    expect_equal(parse "(;A)", expected)

let ``All lowercase property`` () =
    expected <- None
    expect_equal(parse "(;a[b])", expected)

let ``Upper and lowercase property`` () =
    expected <- None
    expect_equal(parse "(;Aa[b])", expected)

let ``Two nodes`` () =
    expected <- Some (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], [])]))
    expect_equal(parse "(;A[B];B[C])", expected)

let ``Two child trees`` () =
    expected <- Some (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], []); Node (Map.ofList [("C", ["D"])], [])]))
    expect_equal(parse "(;A[B](;B[C])(;C[D]))", expected)

let ``Multiple property values`` () =
    expected <- Some (Node (Map.ofList [("A", ["b"; "c"; "d"])], []))
    expect_equal(parse "(;A[b][c][d])", expected)

let ``Semicolon in property value doesn't need to be escaped`` () =
    expected <- Some (Node (Map.ofList [("A", ["a;b"; "foo"]); ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
    expect_equal(parse "(;A[a;b][foo]B[bar];C[baz])", expected)

let ``Parentheses in property value don't need to be escaped`` () =
    expected <- Some (Node (Map.ofList [("A", ["x(y)z"; "foo"]); ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
    expect_equal(parse "(;A[x(y)z][foo]B[bar];C[baz])", expected)

