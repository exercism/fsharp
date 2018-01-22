// This file was created manually and its version is 1.0.0.

module BinarySearchTreeTest

open Xunit
open FsUnit.Xunit
open BinarySearchTree

[<Fact>]
let ``Data is retained`` () =
    let tree = singleton 4
    tree |> value |> should equal <| Some 4

[<Fact(Skip = "Remove to run test")>]
let ``Inserting less`` () =
    let tree = singleton 4 |> insert 2
    tree |> value |> should equal <| Some 4
    tree |> left |> Option.bind value |> should equal <| Some 2

[<Fact(Skip = "Remove to run test")>]
let ``Inserting same`` () =
    let tree = singleton 4 |> insert 4
    tree |> value |> should equal <| Some 4
    tree |> left |> Option.bind value |> should equal <| Some 4

[<Fact(Skip = "Remove to run test")>]
let ``Inserting greater`` () =
    let tree = singleton 4 |> insert 5
    tree |> value |> should equal <| Some 4
    tree |> right |> Option.bind value |> should equal <| Some 5

[<Fact(Skip = "Remove to run test")>]
let ``Complex tree`` () =
    let tree = fromList [4; 2; 6; 1; 3; 7; 5]
    tree |> value |> should equal <| Some 4
    tree |> left |> Option.bind value |> should equal <| Some 2
    tree |> left |> Option.bind (fun x -> x |> left) |> Option.bind value |> should equal <| Some 1
    tree |> left |> Option.bind (fun x -> x |> right) |> Option.bind value |> should equal <| Some 3
    tree |> right |> Option.bind value |> should equal <| Some 6
    tree |> right |> Option.bind (fun x -> x |> left) |> Option.bind value |> should equal <| Some 5
    tree |> right |> Option.bind (fun x -> x |> right) |> Option.bind value |> should equal <| Some 7

[<Fact(Skip = "Remove to run test")>]
let ``Iterating one element`` () =
    let elements = singleton 4 |> toList
    elements |> should equal [4]

[<Fact(Skip = "Remove to run test")>]
let ``Iterating over smaller element`` () =
    let elements = fromList [4; 2] |> toList
    elements |> should equal [2; 4]

[<Fact(Skip = "Remove to run test")>]
let ``Iterating over larger element`` () =
    let elements = fromList [4; 5] |> toList
    elements |> should equal [4; 5]

[<Fact(Skip = "Remove to run test")>]
let ``Iterating over complex element`` () =
    let elements = fromList [4; 2; 1; 3; 6; 7; 5] |> toList
    elements |> should equal [1; 2; 3; 4; 5; 6; 7] 
