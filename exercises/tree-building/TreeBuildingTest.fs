module TreeBuildingTest

open NUnit.Framework

open TreeBuilding

[<Test>]
let ``One node`` () =
    let input = 
        [ 
            { RecordId = 0; ParentId = -1 } 
        ]
    let expected = Leaf 0
    Assert.That(buildTree input, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Three nodes in order`` () =
    let input = 
        [
            { RecordId = 0; ParentId = -1 };
            { RecordId = 1; ParentId =  0 };
            { RecordId = 2; ParentId =  0 };
        ]
    let expected = Branch (0, [Leaf 1; Leaf 2])
    Assert.That(buildTree input, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Three nodes in reverse order`` () =
    let input = 
        [
            { RecordId = 2; ParentId =  0 };
            { RecordId = 1; ParentId =  0 };
            { RecordId = 0; ParentId = -1 };
        ]
    let expected = Branch (0, [Leaf 1; Leaf 2])
    Assert.That(buildTree input, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``More than two children`` () =
    let input = 
        [
            { RecordId = 3; ParentId =  0 };
            { RecordId = 2; ParentId =  0 };
            { RecordId = 1; ParentId =  0 };
            { RecordId = 0; ParentId = -1 };
        ]
    let expected = Branch (0, [Leaf 1; Leaf 2; Leaf 3])
    Assert.That(buildTree input, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Binary tree`` () =
    let input = 
        [
            { RecordId = 5; ParentId =  1 };
            { RecordId = 3; ParentId =  2 };
            { RecordId = 2; ParentId =  0 };
            { RecordId = 4; ParentId =  1 };
            { RecordId = 1; ParentId =  0 };
            { RecordId = 0; ParentId = -1 };
            { RecordId = 6; ParentId =  2 }
        ]
    let expected = Branch (0, [ Branch (1, [Leaf 4; Leaf 5]); 
                                Branch (2, [Leaf 3; Leaf 6]) ])
    Assert.That(buildTree input, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Unbalanced tree`` () =
    let input =
        [
            { RecordId = 5; ParentId =  2 };
            { RecordId = 3; ParentId =  2 };
            { RecordId = 2; ParentId =  0 };
            { RecordId = 4; ParentId =  1 };
            { RecordId = 1; ParentId =  0 };
            { RecordId = 0; ParentId = -1 };
            { RecordId = 6; ParentId =  2 }
        ]
    let expected = Branch (0, [ Branch (1, [Leaf 4]); 
                                Branch (2, [Leaf 3; Leaf 5; Leaf 6]) ])
    Assert.That(buildTree input, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Empty input`` () =
    let input = []
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Root node has parent`` () =
    let input = 
        [ { RecordId = 0; ParentId =  1 };
          { RecordId = 1; ParentId = -1 } ]
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)

[<Test>]
[<Ignore("Remove to run test")>]
let ``No root node`` () =
    let input = [ { RecordId = 1; ParentId = -1 } ]
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Non-continuous`` () =
    let input = 
        [
            { RecordId = 2; ParentId =  0 };
            { RecordId = 4; ParentId =  2 };
            { RecordId = 1; ParentId =  0 };
            { RecordId = 0; ParentId = -1 } 
        ]
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Cycle directly`` () =
    let input = 
        [
            { RecordId = 5; ParentId =  2 };
            { RecordId = 3; ParentId =  2 };
            { RecordId = 2; ParentId =  2 };
            { RecordId = 4; ParentId =  1 };
            { RecordId = 1; ParentId =  0 };
            { RecordId = 0; ParentId = -1 };
            { RecordId = 6; ParentId =  3 } 
        ]
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Cycle indirectly`` () =
    let input = 
        [ 
            { RecordId = 5; ParentId =  2 };
            { RecordId = 3; ParentId =  2 };
            { RecordId = 2; ParentId =  6 };
            { RecordId = 4; ParentId =  1 };
            { RecordId = 1; ParentId =  0 };
            { RecordId = 0; ParentId = -1 };
            { RecordId = 6; ParentId =  3 } 
        ]
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Higher id parent of lower id`` () =
    let input = 
        [ 
            { RecordId = 0; ParentId = -1 };
            { RecordId = 2; ParentId =  0 };
            { RecordId = 1; ParentId =  2 } 
        ]
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)