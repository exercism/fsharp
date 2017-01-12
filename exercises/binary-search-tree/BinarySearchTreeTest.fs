module BinarySearchTreeTest

open NUnit.Framework
open BinarySearchTree

[<Test>]
let ``Data is retained`` () =
    let tree = singleton 4
    Assert.That(tree |> value, Is.EqualTo(Some 4))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Inserting less`` () =
    let tree = singleton 4 |> insert 2
    Assert.That(tree |> value, Is.EqualTo(Some 4))
    Assert.That(tree |> left |> Option.bind value, Is.EqualTo(Some 2))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Inserting same`` () =
    let tree = singleton 4 |> insert 4
    Assert.That(tree |> value, Is.EqualTo(Some 4))
    Assert.That(tree |> left |> Option.bind value, Is.EqualTo(Some 4))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Inserting greater`` () =
    let tree = singleton 4 |> insert 5
    Assert.That(tree |> value, Is.EqualTo(Some 4))
    Assert.That(tree |> right |> Option.bind value, Is.EqualTo(Some 5))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Complex tree`` () =
    let tree = fromList [4; 2; 6; 1; 3; 7; 5]
    Assert.That(tree |> value, Is.EqualTo(Some 4))
    Assert.That(tree |> left |> Option.bind value, Is.EqualTo(Some 2))
    Assert.That(tree |> left |> Option.bind (fun x -> x |> left) |> Option.bind value, Is.EqualTo(Some 1))
    Assert.That(tree |> left |> Option.bind (fun x -> x |> right) |> Option.bind value, Is.EqualTo(Some 3))
    Assert.That(tree |> right |> Option.bind value, Is.EqualTo(Some 6))
    Assert.That(tree |> right |> Option.bind (fun x -> x |> left) |> Option.bind value, Is.EqualTo(Some 5))
    Assert.That(tree |> right |> Option.bind (fun x -> x |> right) |> Option.bind value, Is.EqualTo(Some 7))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Iterating one element`` () =
    let elements = singleton 4 |> toList
    Assert.That(elements, Is.EqualTo([4]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Iterating over smaller element`` () =
    let elements = fromList [4; 2] |> toList
    Assert.That(elements, Is.EqualTo([2; 4]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Iterating over larger element`` () =
    let elements = fromList [4; 5] |> toList
    Assert.That(elements, Is.EqualTo([4; 5]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Iterating over complex element`` () =
    let elements = fromList [4; 2; 1; 3; 6; 7; 5] |> toList
    Assert.That(elements, Is.EqualTo([1; 2; 3; 4; 5; 6; 7])) 
