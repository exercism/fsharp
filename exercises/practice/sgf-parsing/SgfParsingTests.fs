source("./sgf-parsing.R")
library(testthat)

let ``Empty input`` () =
    expected <- None
    parse "" |> should equal expected

let ``Tree with no nodes`` () =
    expected <- None
    parse "()" |> should equal expected

let ``Node without tree`` () =
    expected <- None
    parse ";" |> should equal expected

let ``Node without properties`` () =
    expected <- Some (Node (Map.ofList [], []))
    parse "(;)" |> should equal expected

let ``Single node tree`` () =
    expected <- Some (Node (Map.ofList [("A", ["B"])], []))
    parse "(;A[B])" |> should equal expected

let ``Multiple properties`` () =
    expected <- Some (Node (Map.ofList [("A", ["b"]); ("C", ["d"])], []))
    parse "(;A[b]C[d])" |> should equal expected

let ``Properties without delimiter`` () =
    expected <- None
    parse "(;A)" |> should equal expected

let ``All lowercase property`` () =
    expected <- None
    parse "(;a[b])" |> should equal expected

let ``Upper and lowercase property`` () =
    expected <- None
    parse "(;Aa[b])" |> should equal expected

let ``Two nodes`` () =
    expected <- Some (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], [])]))
    parse "(;A[B];B[C])" |> should equal expected

let ``Two child trees`` () =
    expected <- Some (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], []); Node (Map.ofList [("C", ["D"])], [])]))
    parse "(;A[B](;B[C])(;C[D]))" |> should equal expected

let ``Multiple property values`` () =
    expected <- Some (Node (Map.ofList [("A", ["b"; "c"; "d"])], []))
    parse "(;A[b][c][d])" |> should equal expected

let ``Semicolon in property value doesn't need to be escaped`` () =
    expected <- Some (Node (Map.ofList [("A", ["a;b"; "foo"]); ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
    parse "(;A[a;b][foo]B[bar];C[baz])" |> should equal expected

let ``Parentheses in property value don't need to be escaped`` () =
    expected <- Some (Node (Map.ofList [("A", ["x(y)z"; "foo"]); ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
    parse "(;A[x(y)z][foo]B[bar];C[baz])" |> should equal expected

