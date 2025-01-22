// This file was created manually and its version is 2.0.0.

source("./tree-building-test.R")
library(testthat)

let ``One node`` () =
    input <-
        [
            { RecordId = 0; ParentId = 0 }
        ]

    tree <- buildTree input

    isBranch tree |> should equal false
    recordId tree |> should equal 0
    children tree |> should be Empty

let ``Three nodes in order`` () =
    input <-
        [
            { RecordId = 0; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
        ]

    tree <- buildTree input

    isBranch tree |> should equal true
    recordId tree |> should equal 0
    children tree |> List.length |> should equal 2

    children tree |> List.item 0 |> isBranch |> should equal false
    children tree |> List.item 0 |> recordId |> should equal 1

    children tree |> List.item 1 |> isBranch |> should equal false
    children tree |> List.item 1 |> recordId |> should equal 2

let ``Three nodes in reverse order`` () =
    input <-
        [
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
        ]

    tree <- buildTree input

    isBranch tree |> should equal true
    recordId tree |> should equal 0
    children tree |> List.length |> should equal 2

    children tree |> List.item 0 |> isBranch |> should equal false
    children tree |> List.item 0 |> recordId |> should equal 1

    children tree |> List.item 1 |> isBranch |> should equal false
    children tree |> List.item 1 |> recordId |> should equal 2

let ``More than two children`` () =
    input <-
        [
            { RecordId = 3; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
        ]

    tree <- buildTree input

    isBranch tree |> should equal true
    recordId tree |> should equal 0
    children tree |> List.length |> should equal 3

    children tree |> List.item 0 |> isBranch |> should equal false
    children tree |> List.item 0 |> recordId |> should equal 1

    children tree |> List.item 1 |> isBranch |> should equal false
    children tree |> List.item 1 |> recordId |> should equal 2

    children tree |> List.item 2 |> isBranch |> should equal false
    children tree |> List.item 2 |> recordId |> should equal 3

let ``Binary tree`` () =
    input <-
        [
            { RecordId = 5; ParentId = 1 };
            { RecordId = 3; ParentId = 2 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 4; ParentId = 1 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
            { RecordId = 6; ParentId = 2 }
        ]

    tree <- buildTree input

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

let ``Unbalanced tree`` () =
    input <-
        [
            { RecordId = 5; ParentId = 2 };
            { RecordId = 3; ParentId = 2 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 4; ParentId = 1 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
            { RecordId = 6; ParentId = 2 }
        ]

    tree <- buildTree input

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

let ``Empty input`` () =
    input <- []
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

let ``Root node has parent`` () =
    input <-
        [ { RecordId = 0; ParentId = 1 };
          { RecordId = 1; ParentId = 0 } ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

let ``No root node`` () =
    input <- [ { RecordId = 1; ParentId = 0 } ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

let ``Out of bounds record id`` () =
    input <-
        [
            { RecordId = 2; ParentId = 0 };
            { RecordId = 4; ParentId = 2 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

let ``Cycle directly`` () =
    input <-
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

let ``Cycle indirectly`` () =
    input <-
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

let ``Higher id parent of lower id`` () =
    input <-
        [
            { RecordId = 0; ParentId = 0 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 1; ParentId = 2 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>
