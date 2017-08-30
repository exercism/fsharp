module ZipperTest

open Xunit
open FsUnit

open Zipper

let empty = None
let bt v l r = tree v l r |> Some

let leaf v = bt v None None

let t1 = tree 1 (bt 2 empty    (leaf 3)) (leaf 4)
let t2 = tree 1 (bt 5 empty    (leaf 3)) (leaf 4)
let t3 = tree 1 (bt 2 (leaf 5) (leaf 3)) (leaf 4)
let t4 = tree 1 (leaf 2)                 (leaf 4)

[Fact]
let ``Data is retained``() =
    toTree (fromTree t1) |> should equal t1

[Fact(Skip = "Remove to run test")]
let ``left, right and value``() =
    t1 |> fromTree |> left |> Option.get |> right |> Option.get |> value |> should equal 3

[Fact(Skip = "Remove to run test")]
let ``Dead end``() =
    t1 |> fromTree |> left |> Option.get |> left |> should equal None

[Fact(Skip = "Remove to run test")]
let ``Tree from deep focus``() =
    t1 |> fromTree |> left |> Option.get |> right |> Option.get |> toTree |> should equal t1

[Fact(Skip = "Remove to run test")]
let ``setValue``() =
    t1 |> fromTree |> left |> Option.get |> setValue 5 |> toTree |> should equal t2

[Fact(Skip = "Remove to run test")]
let ``setLeft with Some``() =
    t1 |> fromTree |> left |> Option.get |> setLeft (tree 5 None None |> Some) |> toTree |> should equal t3

[Fact(Skip = "Remove to run test")]
let ``setRight with None``() =
    t1 |> fromTree |> left |> Option.get |> setRight None |> toTree |> should equal t4

[Fact(Skip = "Remove to run test")]
let ``Different paths to same zipper``() =
    t1 |> fromTree |> left |> Option.get |> up |> Option.get |> right |> should equal t1 |> fromTree |> right