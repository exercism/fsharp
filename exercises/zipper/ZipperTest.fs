// This file was auto-generated based on version 1.1.0 of the canonical data.

module ZipperTest

open FsUnit.Xunit
open Xunit

open Zipper

let subTree value left right = Some (tree value left right)
let leaf value = subTree value None None

[<Fact>]
let ``Data is retained`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let sut = zipper |> toTree
    let expected = tree 1 (subTree 2 None (leaf 3)) (leaf 4)
    sut |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Left, right and value`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let sut = zipper |> left |> Option.get |> right |> Option.get |> value
    let expected = 3
    sut |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Dead end`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let sut = zipper |> left |> Option.get |> left
    let expected = None
    sut |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Tree from deep focus`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let sut = zipper |> left |> Option.get |> right |> Option.get |> toTree
    let expected = tree 1 (subTree 2 None (leaf 3)) (leaf 4)
    sut |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Traversing up from top`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let sut = zipper |> up
    let expected = None
    sut |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Left, right, and up`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let sut = zipper |> left |> Option.get |> up |> Option.get |> right |> Option.get |> up |> Option.get |> left |> Option.get |> right |> Option.get |> value
    let expected = 3
    sut |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Set value`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let sut = zipper |> left |> Option.get |> setValue 5 |> toTree
    let expected = tree 1 (subTree 5 None (leaf 3)) (leaf 4)
    sut |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Set value after traversing up`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let sut = zipper |> left |> Option.get |> right |> Option.get |> up |> Option.get |> setValue 5 |> toTree
    let expected = tree 1 (subTree 5 None (leaf 3)) (leaf 4)
    sut |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Set left with leaf`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let sut = zipper |> left |> Option.get |> setLeft (Some (tree 5 None None)) |> toTree
    let expected = tree 1 (subTree 2 (leaf 5) (leaf 3)) (leaf 4)
    sut |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Set right with null`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let sut = zipper |> left |> Option.get |> setRight None |> toTree
    let expected = tree 1 (leaf 2) (leaf 4)
    sut |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Set right with subtree`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let sut = zipper |> setRight (Some (tree 6 (leaf 7) (leaf 8))) |> toTree
    let expected = tree 1 (subTree 2 None (leaf 3)) (subTree 6 (leaf 7) (leaf 8))
    sut |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Set value on deep focus`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let sut = zipper |> left |> Option.get |> right |> Option.get |> setValue 5 |> toTree
    let expected = tree 1 (subTree 2 None (leaf 5)) (leaf 4)
    sut |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Different paths to same zipper`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let sut = zipper |> left |> Option.get |> up |> Option.get |> right
    let expected = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4)) |> right
    sut |> should equal expected

