module SatelliteTests

open FsUnit.Xunit
open Xunit

open Satellite

[<Fact>]
let ``Empty tree`` () =
    let expected: Result<Tree,string> = Ok (
        Empty
    )
    treeFromTraversals [] [] |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Tree with one item`` () =
    let expected: Result<Tree,string> = Ok (
        Node("a", Empty, Empty)
    )
    treeFromTraversals ["a"] ["a"] |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
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
    treeFromTraversals ["i"; "a"; "f"; "x"; "r"] ["a"; "i"; "x"; "f"; "r"] |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Reject traversals of different length`` () =
    let expected: Result<Tree,string> = Error "traversals must have the same length"
    treeFromTraversals ["b"; "a"; "r"] ["a"; "b"] |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Reject inconsistent traversals of same length`` () =
    let expected: Result<Tree,string> = Error "traversals must have the same elements"
    treeFromTraversals ["a"; "b"; "c"] ["x"; "y"; "z"] |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Reject traversals with repeated items`` () =
    let expected: Result<Tree,string> = Error "traversals must contain unique items"
    treeFromTraversals ["b"; "a"; "a"] ["a"; "b"; "a"] |> should equal expected

