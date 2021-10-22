module ZipperTests

open FsUnit.Xunit
open Xunit

open Zipper

let subTree value left right = Some (tree value left right)
let leaf value = subTree value None None

[<Fact>]
let ``Data is retained`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 2 None (leaf 3)) (leaf 4)
    let actual = zipper |> toTree
    actual |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Left, right and value`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = 3
    let actual = zipper |> left |> Option.get |> right |> Option.get |> value
    actual |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Dead end`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = None
    let actual = zipper |> left |> Option.get |> left
    actual |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Tree from deep focus`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 2 None (leaf 3)) (leaf 4)
    let actual = zipper |> left |> Option.get |> right |> Option.get |> toTree
    actual |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Traversing up from top`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = None
    let actual = zipper |> up
    actual |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Left, right, and up`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = 3
    let actual = zipper |> left |> Option.get |> up |> Option.get |> right |> Option.get |> up |> Option.get |> left |> Option.get |> right |> Option.get |> value
    actual |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Set value`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 5 None (leaf 3)) (leaf 4)
    let actual = zipper |> left |> Option.get |> setValue 5 |> toTree
    actual |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Set value after traversing up`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 5 None (leaf 3)) (leaf 4)
    let actual = zipper |> left |> Option.get |> right |> Option.get |> up |> Option.get |> setValue 5 |> toTree
    actual |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Set left with leaf`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 2 (leaf 5) (leaf 3)) (leaf 4)
    let actual = zipper |> left |> Option.get |> setLeft (Some (tree 5 None None)) |> toTree
    actual |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Set right with null`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (leaf 2) (leaf 4)
    let actual = zipper |> left |> Option.get |> setRight None |> toTree
    actual |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Set right with subtree`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 2 None (leaf 3)) (subTree 6 (leaf 7) (leaf 8))
    let actual = zipper |> setRight (Some (tree 6 (leaf 7) (leaf 8))) |> toTree
    actual |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Set value on deep focus`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 2 None (leaf 5)) (leaf 4)
    let actual = zipper |> left |> Option.get |> right |> Option.get |> setValue 5 |> toTree
    actual |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Different paths to same zipper`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4)) |> right
    let actual = zipper |> left |> Option.get |> up |> Option.get |> right
    actual |> should equal expected

