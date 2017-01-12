module TreeBuildingTest

open NUnit.Framework

open TreeBuilding

[<Test>]
let ``One node`` () =
    let input = 
        [ 
            { RecordId = 0; ParentId = 0 } 
        ]

    let tree = buildTree input

    Assert.That(isBranch tree, Is.False)
    Assert.That(recordId tree, Is.EqualTo(0))    
    Assert.That(children tree, Is.EqualTo([]))

[<Test>]
let ``Three nodes in order`` () =
    let input = 
        [
            { RecordId = 0; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
        ]

    let tree = buildTree input

    Assert.That(isBranch tree, Is.True)
    Assert.That(recordId tree, Is.EqualTo(0))
    Assert.That(children tree |> List.length, Is.EqualTo(2))

    Assert.That(children tree |> List.item 0 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 0 |> recordId, Is.EqualTo(1))

    Assert.That(children tree |> List.item 1 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 1 |> recordId, Is.EqualTo(2))

[<Test>]
let ``Three nodes in reverse order`` () =
    let input = 
        [
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
        ]

    let tree = buildTree input
    
    Assert.That(isBranch tree, Is.True)
    Assert.That(recordId tree, Is.EqualTo(0))
    Assert.That(children tree |> List.length, Is.EqualTo(2))

    Assert.That(children tree |> List.item 0 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 0 |> recordId, Is.EqualTo(1))

    Assert.That(children tree |> List.item 1 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 1 |> recordId, Is.EqualTo(2))

[<Test>]
let ``More than two children`` () =
    let input = 
        [
            { RecordId = 3; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
        ]

    let tree = buildTree input
    
    Assert.That(isBranch tree, Is.True)
    Assert.That(recordId tree, Is.EqualTo(0))
    Assert.That(children tree |> List.length, Is.EqualTo(3))

    Assert.That(children tree |> List.item 0 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 0 |> recordId, Is.EqualTo(1))

    Assert.That(children tree |> List.item 1 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 1 |> recordId, Is.EqualTo(2))

    Assert.That(children tree |> List.item 2 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 2 |> recordId, Is.EqualTo(3))

[<Test>]
let ``Binary tree`` () =
    let input = 
        [
            { RecordId = 5; ParentId = 1 };
            { RecordId = 3; ParentId = 2 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 4; ParentId = 1 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
            { RecordId = 6; ParentId = 2 }
        ]

    let tree = buildTree input
        
    Assert.That(isBranch tree, Is.True)
    Assert.That(recordId tree, Is.EqualTo(0))
    Assert.That(children tree |> List.length, Is.EqualTo(2))

    Assert.That(children tree |> List.item 0 |> isBranch, Is.True)
    Assert.That(children tree |> List.item 0 |> recordId, Is.EqualTo(1))    
    Assert.That(children tree |> List.item 0 |> children |> List.length, Is.EqualTo(2))

    Assert.That(children tree |> List.item 0 |> children |> List.item 0 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 0 |> children |> List.item 0 |> recordId, Is.EqualTo(4))

    Assert.That(children tree |> List.item 0 |> children |> List.item 1 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 0 |> children |> List.item 1 |> recordId, Is.EqualTo(5))
    
    Assert.That(children tree |> List.item 1 |> isBranch, Is.True)
    Assert.That(children tree |> List.item 1 |> recordId, Is.EqualTo(2))    
    Assert.That(children tree |> List.item 1 |> children |> List.length, Is.EqualTo(2))
    
    Assert.That(children tree |> List.item 1 |> children |> List.item 0 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 1 |> children |> List.item 0 |> recordId, Is.EqualTo(3))

    Assert.That(children tree |> List.item 1 |> children |> List.item 1 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 1 |> children |> List.item 1 |> recordId, Is.EqualTo(6))

[<Test>]
let ``Unbalanced tree`` () =
    let input =
        [
            { RecordId = 5; ParentId = 2 };
            { RecordId = 3; ParentId = 2 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 4; ParentId = 1 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
            { RecordId = 6; ParentId = 2 }
        ]

    let tree = buildTree input
        
    Assert.That(isBranch tree, Is.True)
    Assert.That(recordId tree, Is.EqualTo(0))
    Assert.That(children tree |> List.length, Is.EqualTo(2))

    Assert.That(children tree |> List.item 0 |> isBranch, Is.True)
    Assert.That(children tree |> List.item 0 |> recordId, Is.EqualTo(1))    
    Assert.That(children tree |> List.item 0 |> children |> List.length, Is.EqualTo(1))

    Assert.That(children tree |> List.item 0 |> children |> List.item 0 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 0 |> children |> List.item 0 |> recordId, Is.EqualTo(4))
    
    Assert.That(children tree |> List.item 1 |> isBranch, Is.True)
    Assert.That(children tree |> List.item 1 |> recordId, Is.EqualTo(2))
    Assert.That(children tree |> List.item 1 |> children |> List.length, Is.EqualTo(3))
    
    Assert.That(children tree |> List.item 1 |> children |> List.item 0 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 1 |> children |> List.item 0 |> recordId, Is.EqualTo(3))

    Assert.That(children tree |> List.item 1 |> children |> List.item 1 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 1 |> children |> List.item 1 |> recordId, Is.EqualTo(5))

    Assert.That(children tree |> List.item 1 |> children |> List.item 2 |> isBranch, Is.False)
    Assert.That(children tree |> List.item 1 |> children |> List.item 2 |> recordId, Is.EqualTo(6))

[<Test>]
let ``Empty input`` () =
    let input = []
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)

[<Test>]
let ``Root node has parent`` () =
    let input = 
        [ { RecordId = 0; ParentId = 1 };
          { RecordId = 1; ParentId = 0 } ]
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)

[<Test>]
let ``No root node`` () =
    let input = [ { RecordId = 1; ParentId = 0 } ]
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)
    
[<Test>]
let ``Non-continuous`` () =
    let input = 
        [
            { RecordId = 2; ParentId = 0 };
            { RecordId = 4; ParentId = 2 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 } 
        ]
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)

[<Test>]
let ``Cycle directly`` () =
    let input = 
        [
            { RecordId = 5; ParentId = 2 };
            { RecordId = 3; ParentId = 2 };
            { RecordId = 2; ParentId = 2 };
            { RecordId = 4; ParentId = 1 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
            { RecordId = 6; ParentId = 3 } 
        ]
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)

[<Test>]
let ``Cycle indirectly`` () =
    let input = 
        [ 
            { RecordId = 5; ParentId = 2 };
            { RecordId = 3; ParentId = 2 };
            { RecordId = 2; ParentId = 6 };
            { RecordId = 4; ParentId = 1 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
            { RecordId = 6; ParentId = 3 } 
        ]
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)

[<Test>]
let ``Higher id parent of lower id`` () =
    let input = 
        [ 
            { RecordId = 0; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 2 } 
        ]
    Assert.That((fun () -> buildTree input |> ignore), Throws.Exception)