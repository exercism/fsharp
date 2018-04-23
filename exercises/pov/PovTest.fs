// This file was auto-generated based on version 1.3.0 of the canonical data.

module PovTest

open FsUnit.Xunit
open Xunit

open Pov

let rec graphToList (graph: Graph<'a>) = 
    let right =
        graph.children
        |> List.sortBy (fun x -> x.value)
        |> List.collect graphToList
    [graph.value] @ right
let mapToList graph = match graph with | Some x -> graphToList x | None -> []

[<Fact>]
let ``Results in the same tree if the input tree is a singleton`` () =
    let tree = mkGraph "x" []
    let expected = mkGraph "x" []
    fromPOV "x" tree |> mapToList  |> should equal <| graphToList expected

[<Fact(Skip = "Remove to run test")>]
let ``Can reroot a tree with a parent and one sibling`` () =
    let tree = mkGraph "parent" [mkGraph "x" []; mkGraph "sibling" []]
    let expected = mkGraph "x" [mkGraph "parent" [mkGraph "sibling" []]]
    fromPOV "x" tree |> mapToList  |> should equal <| graphToList expected

[<Fact(Skip = "Remove to run test")>]
let ``Can reroot a tree with a parent and many siblings`` () =
    let tree = mkGraph "parent" [mkGraph "a" []; mkGraph "x" []; mkGraph "b" []; mkGraph "c" []]
    let expected = mkGraph "x" [mkGraph "parent" [mkGraph "a" []; mkGraph "b" []; mkGraph "c" []]]
    fromPOV "x" tree |> mapToList  |> should equal <| graphToList expected

[<Fact(Skip = "Remove to run test")>]
let ``Can reroot a tree with new root deeply nested in tree`` () =
    let tree = mkGraph "level-0" [mkGraph "level-1" [mkGraph "level-2" [mkGraph "level-3" [mkGraph "x" []]]]]
    let expected = mkGraph "x" [mkGraph "level-3" [mkGraph "level-2" [mkGraph "level-1" [mkGraph "level-0" []]]]]
    fromPOV "x" tree |> mapToList  |> should equal <| graphToList expected

[<Fact(Skip = "Remove to run test")>]
let ``Moves children of the new root to same level as former parent`` () =
    let tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]]
    let expected = mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []; mkGraph "parent" []]
    fromPOV "x" tree |> mapToList  |> should equal <| graphToList expected

[<Fact(Skip = "Remove to run test")>]
let ``Can reroot a complex tree with cousins`` () =
    let tree = mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]; mkGraph "uncle" [mkGraph "cousin-0" []; mkGraph "cousin-1" []]]
    let expected = mkGraph "x" [mkGraph "kid-1" []; mkGraph "kid-0" []; mkGraph "parent" [mkGraph "sibling-0" []; mkGraph "sibling-1" []; mkGraph "grandparent" [mkGraph "uncle" [mkGraph "cousin-0" []; mkGraph "cousin-1" []]]]]
    fromPOV "x" tree |> mapToList  |> should equal <| graphToList expected

[<Fact(Skip = "Remove to run test")>]
let ``Errors if target does not exist in a singleton tree`` () =
    let tree = mkGraph "x" []
    fromPOV "nonexistent" tree  |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Errors if target does not exist in a large tree`` () =
    let tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]
    fromPOV "nonexistent" tree  |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Can find path to parent`` () =
    let tree = mkGraph "parent" [mkGraph "x" []; mkGraph "sibling" []]
    tracePathBetween "x" "parent" tree |> should equal <| Some ["x"; "parent"]

[<Fact(Skip = "Remove to run test")>]
let ``Can find path to sibling`` () =
    let tree = mkGraph "parent" [mkGraph "a" []; mkGraph "x" []; mkGraph "b" []; mkGraph "c" []]
    tracePathBetween "x" "b" tree |> should equal <| Some ["x"; "parent"; "b"]

[<Fact(Skip = "Remove to run test")>]
let ``Can find path to cousin`` () =
    let tree = mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]; mkGraph "uncle" [mkGraph "cousin-0" []; mkGraph "cousin-1" []]]
    tracePathBetween "x" "cousin-1" tree |> should equal <| Some ["x"; "parent"; "grandparent"; "uncle"; "cousin-1"]

[<Fact(Skip = "Remove to run test")>]
let ``Can find path not involving root`` () =
    let tree = mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" []; mkGraph "sibling-0" []; mkGraph "sibling-1" []]]
    tracePathBetween "x" "sibling-1" tree |> should equal <| Some ["x"; "parent"; "sibling-1"]

[<Fact(Skip = "Remove to run test")>]
let ``Can find path from nodes other than x`` () =
    let tree = mkGraph "parent" [mkGraph "a" []; mkGraph "x" []; mkGraph "b" []; mkGraph "c" []]
    tracePathBetween "a" "c" tree |> should equal <| Some ["a"; "parent"; "c"]

[<Fact(Skip = "Remove to run test")>]
let ``Errors if destination does not exist`` () =
    let tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]
    tracePathBetween "x" "nonexistent" tree |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Errors if source does not exist`` () =
    let tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" []; mkGraph "kid-1" []]; mkGraph "sibling-0" []; mkGraph "sibling-1" []]
    tracePathBetween "nonexistent" "x" tree |> should equal None

