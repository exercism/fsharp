source("./pov.R")
library(testthat)

let rec graphToList (graph: Graph<'a>) = 
    right <-
        graph.children
        |> List.sortBy (fun x -> x.value)
        |> List.collect graphToList
    [graph.value] @ right
let mapToList graph = match graph with | Some x -> graphToList x | None -> []

let ``Results in the same tree if the input tree is a singleton`` () =
    tree <- mkGraph "x" []
    expected <- mkGraph "x" []
    expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)

let ``Can reroot a tree with a parent and one sibling`` () =
    tree <- mkGraph "parent" [mkGraph "x" []; mkGraph "sibling" []]
    expected <- mkGraph "x" [mkGraph "parent" [mkGraph "sibling" []]]
    expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)

let ``Can reroot a tree with a parent and many siblings`` () =
    tree <- mkGraph "parent" [mkGraph "a" []; mkGraph "x" []; mkGraph "b" []; mkGraph "c" []]
    expected <- mkGraph "x" [mkGraph "parent" [mkGraph "a" []; mkGraph "b" []; mkGraph "c" []]]
    expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)

let ``Can reroot a tree with new root deeply nested in tree`` () =
    tree <- mkGraph "level-0" [mkGraph "level-1" [mkGraph "level-2" [mkGraph "level-3" [mkGraph "x" []]]]]
    expected <- mkGraph "x" [mkGraph "level-3" [mkGraph "level-2" [mkGraph "level-1" [mkGraph "level-0" []]]]]
    expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)

let ``Moves children of the new root to same level as former parent`` () =
    tree <- mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]]
    expected <- mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []; mkGraph "parent" []]
    expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)

let ``Can reroot a complex tree with cousins`` () =
    tree <- mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]; mkGraph "uncle" [mkGraph "cousin-0" []; mkGraph "cousin-1" []]]
    expected <- mkGraph "x" [mkGraph "kid-1" []; mkGraph "kid-0" []; mkGraph "parent" [mkGraph "sibling-0" []; mkGraph "sibling-1" []; mkGraph "grandparent" [mkGraph "uncle" [mkGraph "cousin-0" []; mkGraph "cousin-1" []]]]]
    expect_equal(fromPOV "x" tree |> mapToList , <| graphToList expected)

let ``Errors if target does not exist in a singleton tree`` () =
    tree <- mkGraph "x" []
    expect_equal(fromPOV "nonexistent" tree , None)

let ``Errors if target does not exist in a large tree`` () =
    tree <- mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]
    expect_equal(fromPOV "nonexistent" tree , None)

let ``Can find path to parent`` () =
    tree <- mkGraph "parent" [mkGraph "x" []; mkGraph "sibling" []]
    expect_equal(tracePathBetween "x" "parent" tree, <| Some ["x"; "parent"])

let ``Can find path to sibling`` () =
    tree <- mkGraph "parent" [mkGraph "a" []; mkGraph "x" []; mkGraph "b" []; mkGraph "c" []]
    expect_equal(tracePathBetween "x" "b" tree, <| Some ["x"; "parent"; "b"])

let ``Can find path to cousin`` () =
    tree <- mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]; mkGraph "uncle" [mkGraph "cousin-0" []; mkGraph "cousin-1" []]]
    expect_equal(tracePathBetween "x" "cousin-1" tree, <| Some ["x"; "parent"; "grandparent"; "uncle"; "cousin-1"])

let ``Can find path not involving root`` () =
    tree <- mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" []; mkGraph "sibling-0" []; mkGraph "sibling-1" []]]
    expect_equal(tracePathBetween "x" "sibling-1" tree, <| Some ["x"; "parent"; "sibling-1"])

let ``Can find path from nodes other than x`` () =
    tree <- mkGraph "parent" [mkGraph "a" []; mkGraph "x" []; mkGraph "b" []; mkGraph "c" []]
    expect_equal(tracePathBetween "a" "c" tree, <| Some ["a"; "parent"; "c"])

let ``Errors if destination does not exist`` () =
    tree <- mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]
    expect_equal(tracePathBetween "x" "nonexistent" tree, None)

let ``Errors if source does not exist`` () =
    tree <- mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]
    expect_equal(tracePathBetween "nonexistent" "x" tree, None)

