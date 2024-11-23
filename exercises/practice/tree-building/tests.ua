// This file was created manually and its version is 2.0.0.

module TreeBuildingTest




# One node
input =
        [
            { RecordId = 0 ParentId = 0 }
        ]

tree = buildTree input

⍤⤙≍ 0 isBranch tree
⍤⤙≍ 0 recordId tree
⍤⤙≍ [] children tree

# Three nodes in order
input =
        [
            { RecordId = 0 ParentId = 0 };
            { RecordId = 1 ParentId = 0 };
            { RecordId = 2 ParentId = 0 };
        ]

tree = buildTree input

⍤⤙≍ 1 isBranch tree
⍤⤙≍ 0 recordId tree
⍤⤙≍ 2 children tree |> List.length

⍤⤙≍ 0 children tree |> List.item 0 |> isBranch
⍤⤙≍ 1 children tree |> List.item 0 |> recordId

⍤⤙≍ 0 children tree |> List.item 1 |> isBranch
⍤⤙≍ 2 children tree |> List.item 1 |> recordId

# Three nodes in reverse order
input =
        [
            { RecordId = 2 ParentId = 0 };
            { RecordId = 1 ParentId = 0 };
            { RecordId = 0 ParentId = 0 };
        ]

tree = buildTree input

⍤⤙≍ 1 isBranch tree
⍤⤙≍ 0 recordId tree
⍤⤙≍ 2 children tree |> List.length

⍤⤙≍ 0 children tree |> List.item 0 |> isBranch
⍤⤙≍ 1 children tree |> List.item 0 |> recordId

⍤⤙≍ 0 children tree |> List.item 1 |> isBranch
⍤⤙≍ 2 children tree |> List.item 1 |> recordId

# More than two children
input =
        [
            { RecordId = 3 ParentId = 0 };
            { RecordId = 2 ParentId = 0 };
            { RecordId = 1 ParentId = 0 };
            { RecordId = 0 ParentId = 0 };
        ]

tree = buildTree input

⍤⤙≍ 1 isBranch tree
⍤⤙≍ 0 recordId tree
⍤⤙≍ 3 children tree |> List.length

⍤⤙≍ 0 children tree |> List.item 0 |> isBranch
⍤⤙≍ 1 children tree |> List.item 0 |> recordId

⍤⤙≍ 0 children tree |> List.item 1 |> isBranch
⍤⤙≍ 2 children tree |> List.item 1 |> recordId

⍤⤙≍ 0 children tree |> List.item 2 |> isBranch
⍤⤙≍ 3 children tree |> List.item 2 |> recordId

# Binary tree
input =
        [
            { RecordId = 5 ParentId = 1 };
            { RecordId = 3 ParentId = 2 };
            { RecordId = 2 ParentId = 0 };
            { RecordId = 4 ParentId = 1 };
            { RecordId = 1 ParentId = 0 };
            { RecordId = 0 ParentId = 0 };
            { RecordId = 6 ParentId = 2 }
        ]

tree = buildTree input

⍤⤙≍ 1 isBranch tree
⍤⤙≍ 0 recordId tree
⍤⤙≍ 2 children tree |> List.length

⍤⤙≍ 1 children tree |> List.item 0 |> isBranch
⍤⤙≍ 1 children tree |> List.item 0 |> recordId
⍤⤙≍ 2 children tree |> List.item 0 |> children |> List.length

⍤⤙≍ 0 children tree |> List.item 0 |> children |> List.item 0 |> isBranch
⍤⤙≍ 4 children tree |> List.item 0 |> children |> List.item 0 |> recordId

⍤⤙≍ 0 children tree |> List.item 0 |> children |> List.item 1 |> isBranch
⍤⤙≍ 5 children tree |> List.item 0 |> children |> List.item 1 |> recordId

⍤⤙≍ 1 children tree |> List.item 1 |> isBranch
⍤⤙≍ 2 children tree |> List.item 1 |> recordId
⍤⤙≍ 2 children tree |> List.item 1 |> children |> List.length

⍤⤙≍ 0 children tree |> List.item 1 |> children |> List.item 0 |> isBranch
⍤⤙≍ 3 children tree |> List.item 1 |> children |> List.item 0 |> recordId

⍤⤙≍ 0 children tree |> List.item 1 |> children |> List.item 1 |> isBranch
⍤⤙≍ 6 children tree |> List.item 1 |> children |> List.item 1 |> recordId

# Unbalanced tree
input =
        [
            { RecordId = 5 ParentId = 2 };
            { RecordId = 3 ParentId = 2 };
            { RecordId = 2 ParentId = 0 };
            { RecordId = 4 ParentId = 1 };
            { RecordId = 1 ParentId = 0 };
            { RecordId = 0 ParentId = 0 };
            { RecordId = 6 ParentId = 2 }
        ]

tree = buildTree input

⍤⤙≍ 1 isBranch tree
⍤⤙≍ 0 recordId tree
⍤⤙≍ 2 children tree |> List.length

⍤⤙≍ 1 children tree |> List.item 0 |> isBranch
⍤⤙≍ 1 children tree |> List.item 0 |> recordId
⍤⤙≍ 1 children tree |> List.item 0 |> children |> List.length

⍤⤙≍ 0 children tree |> List.item 0 |> children |> List.item 0 |> isBranch
⍤⤙≍ 4 children tree |> List.item 0 |> children |> List.item 0 |> recordId

⍤⤙≍ 1 children tree |> List.item 1 |> isBranch
⍤⤙≍ 2 children tree |> List.item 1 |> recordId
⍤⤙≍ 3 children tree |> List.item 1 |> children |> List.length

⍤⤙≍ 0 children tree |> List.item 1 |> children |> List.item 0 |> isBranch
⍤⤙≍ 3 children tree |> List.item 1 |> children |> List.item 0 |> recordId

⍤⤙≍ 0 children tree |> List.item 1 |> children |> List.item 1 |> isBranch
⍤⤙≍ 5 children tree |> List.item 1 |> children |> List.item 1 |> recordId

⍤⤙≍ 0 children tree |> List.item 1 |> children |> List.item 2 |> isBranch
⍤⤙≍ 6 children tree |> List.item 1 |> children |> List.item 2 |> recordId

# Empty input
input = []
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

# Root node has parent
input =
        [ { RecordId = 0 ParentId = 1 };
          { RecordId = 1 ParentId = 0 } ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

# No root node
input = [ { RecordId = 1 ParentId = 0 } ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

# Out of bounds record id
input =
        [
            { RecordId = 2 ParentId = 0 };
            { RecordId = 4 ParentId = 2 };
            { RecordId = 1 ParentId = 0 };
            { RecordId = 0 ParentId = 0 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

# Cycle directly
input =
        [
            { RecordId = 5 ParentId = 2 };
            { RecordId = 3 ParentId = 2 };
            { RecordId = 2 ParentId = 2 };
            { RecordId = 4 ParentId = 1 };
            { RecordId = 1 ParentId = 0 };
            { RecordId = 0 ParentId = 0 };
            { RecordId = 6 ParentId = 3 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

# Cycle indirectly
input =
        [
            { RecordId = 5 ParentId = 2 };
            { RecordId = 3 ParentId = 2 };
            { RecordId = 2 ParentId = 6 };
            { RecordId = 4 ParentId = 1 };
            { RecordId = 1 ParentId = 0 };
            { RecordId = 0 ParentId = 0 };
            { RecordId = 6 ParentId = 3 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>

# Higher id parent of lower id
input =
        [
            { RecordId = 0 ParentId = 0 };
            { RecordId = 2 ParentId = 0 };
            { RecordId = 1 ParentId = 2 }
        ]
    (fun () -> buildTree input |> ignore) |> should throw typeof<Exception>
