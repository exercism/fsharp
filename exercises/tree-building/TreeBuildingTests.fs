// This file was created manually and its version is 2.0.0.

module TreeBuildingTest

open System

open FsUnit.Xunit
open Xunit

open TreeBuildingTypes
open TreeBuilding

[<Fact>]
let ``One node`` () =
    let input =
        [
            { RecordId = 0; ParentId = 0 }
        ]

    let tree = buildTree input

    isBranch tree |> should equal false
    recordId tree |> should equal 0
    children tree |> should be Empty

[<Fact>]
let ``Three nodes in order`` () =
    let input =
        [
            { RecordId = 0; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
        ]

    let tree = buildTree input

    isBranch tree |> should equal true
    recordId tree |> should equal 0
    children tree |> List.length |> should equal 2

    children tree |> List.item 0 |> isBranch |> should equal false
    children tree |> List.item 0 |> recordId |> should equal 1

    children tree |> List.item 1 |> isBranch |> should equal false
    children tree |> List.item 1 |> recordId |> should equal 2

[<Fact>]
let ``Three nodes in reverse order`` () =
    let input =
        [
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
        ]

    let tree = buildTree input

    isBranch tree |> should equal true
    recordId tree |> should equal 0
    children tree |> List.length |> should equal 2

    children tree |> List.item 0 |> isBranch |> should equal false
    children tree |> List.item 0 |> recordId |> should equal 1

    children tree |> List.item 1 |> isBranch |> should equal false
    children tree |> List.item 1 |> recordId |> should equal 2

[<Fact>]
let ``More than two children`` () =
    let input =
        [
            { RecordId = 3; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
        ]

    let tree = buildTree input

    isBranch tree |> should equal true
    recordId tree |> should equal 0
    children tree |> List.length |> should equal 3

    children tree |> List.item 0 |> isBranch |> should equal false
    children tree |> List.item 0 |> recordId |> should equal 1

    children tree |> List.item 1 |> isBranch |> should equal false
    children tree |> List.item 1 |> recordId |> should equal 2

    children tree |> List.item 2 |> isBranch |> should equal false
    children tree |> List.item 2 |> recordId |> should equal 3

[<Fact>]
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

    isBranch tree |> should equal true
    recordId tree |> should equal 0
    children tree |> List.length |> should equal 2

    children tree |> List.item 0 |> isBranch |> should equal true
    children tree |> List.item 0 |> recordId |> should equal 1
    children tree |> List.item 0 |> children |> List.length |> should equal 2

    children tree |> List.item 0 |> children |> List.item 0 |> isBranch |> should equal false
    children tree |> List.item 0 |> children |> List.item 0 |> recordId |> should equal 4

    children tree |> List.item 0 |> children |> List.item 1 |> isBranch |> should equal false
    children tree |> List.item 0 |> children |> List.item 1 |> recordId |> should equal 5

    children tree |> List.item 1 |> isBranch |> should equal true
    children tree |> List.item 1 |> recordId |> should equal 2
    children tree |> List.item 1 |> children |> List.length |> should equal 2

    children tree |> List.item 1 |> children |> List.item 0 |> isBranch |> should equal false
    children tree |> List.item 1 |> children |> List.item 0 |> recordId |> should equal 3

    children tree |> List.item 1 |> children |> List.item 1 |> isBranch |> should equal false
    children tree |> List.item 1 |> children |> List.item 1 |> recordId |> should equal 6

[<Fact>]
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

    isBranch tree |> should equal true
    recordId tree |> should equal 0
    children tree |> List.length |> should equal 2

    children tree |> List.item 0 |> isBranch |> should equal true
    children tree |> List.item 0 |> recordId |> should equal 1
    children tree |> List.item 0 |> children |> List.length |> should equal 1

    children tree |> List.item 0 |> children |> List.item 0 |> isBranch |> should equal false
    children tree |> List.item 0 |> children |> List.item 0 |> recordId |> should equal 4

    children tree |> List.item 1 |> isBranch |> should equal true
    children tree |> List.item 1 |> recordId |> should equal 2
    children tree |> List.item 1 |> children |> List.length |> should equal 3

    children tree |> List.item 1 |> children |> List.item 0 |> isBranch |> should equal false
    children tree |> List.item 1 |> children |> List.item 0 |> recordId |> should equal 3

    children tree |> List.item 1 |> children |> List.item 1 |> isBranch |> should equal false
    children tree |> List.item 1 |> children |> List.item 1 |> recordId |> should equal 5

    children tree |> List.item 1 |> children |> List.item 2 |> isBranch |> should equal false
    children tree |> List.item 1 |> children |> List.item 2 |> recordId |> should equal 6

[<Fact>]
let ``Empty input`` () =
    let input = []
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

[<Fact>]
let ``Root node has parent`` () =
    let input =
        [ { RecordId = 0; ParentId = 1 };
          { RecordId = 1; ParentId = 0 } ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

[<Fact>]
let ``No root node`` () =
    let input = [ { RecordId = 1; ParentId = 0 } ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

[<Fact>]
let ``Out of bounds record id`` () =
    let input =
        [
            { RecordId = 2; ParentId = 0 };
            { RecordId = 4; ParentId = 2 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

[<Fact>]
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
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

[<Fact>]
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
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

[<Fact>]
let ``Higher id parent of lower id`` () =
    let input =
        [
            { RecordId = 0; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 2 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>
