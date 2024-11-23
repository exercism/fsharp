~ "binary-search-tree.ua" ~ BinarySearchTree

# Data is retained
    let treeData = create [4]
⍤⤙≍ 4 treeData |> data
⍤⤙≍ None treeData |> left
⍤⤙≍ None treeData |> right

# Smaller number at left node
    let treeData = create [4 2]
⍤⤙≍ 4 treeData |> data
⍤⤙≍ (Some 2) treeData |> left |> Option.map data
⍤⤙≍ None treeData |> left |> Option.bind left
⍤⤙≍ None treeData |> left |> Option.bind right
⍤⤙≍ None treeData |> right

# Same number at left node
    let treeData = create [4 4]
⍤⤙≍ 4 treeData |> data
⍤⤙≍ (Some 4) treeData |> left |> Option.map data
⍤⤙≍ None treeData |> left |> Option.bind left
⍤⤙≍ None treeData |> left |> Option.bind right
⍤⤙≍ None treeData |> right

# Greater number at right node
    let treeData = create [4 5]
⍤⤙≍ 4 treeData |> data
⍤⤙≍ None treeData |> left
⍤⤙≍ (Some 5) treeData |> right |> Option.map data
⍤⤙≍ None treeData |> right |> Option.bind left
⍤⤙≍ None treeData |> right |> Option.bind right

# Can create complex tree
    let treeData = create [4 2 6 1 3 5 7]
⍤⤙≍ 4 treeData |> data
⍤⤙≍ (Some 2) treeData |> left |> Option.map data
⍤⤙≍ (Some 1) treeData |> left |> Option.bind left |> Option.map data
⍤⤙≍ None treeData |> left |> Option.bind left |> Option.bind left
⍤⤙≍ None treeData |> left |> Option.bind left |> Option.bind right
⍤⤙≍ (Some 3) treeData |> left |> Option.bind right |> Option.map data
⍤⤙≍ None treeData |> left |> Option.bind right |> Option.bind left
⍤⤙≍ None treeData |> left |> Option.bind right |> Option.bind right
⍤⤙≍ (Some 6) treeData |> right |> Option.map data
⍤⤙≍ (Some 5) treeData |> right |> Option.bind left |> Option.map data
⍤⤙≍ None treeData |> right |> Option.bind left |> Option.bind left
⍤⤙≍ None treeData |> right |> Option.bind left |> Option.bind right
⍤⤙≍ (Some 7) treeData |> right |> Option.bind right |> Option.map data
⍤⤙≍ None treeData |> right |> Option.bind right |> Option.bind left
⍤⤙≍ None treeData |> right |> Option.bind right |> Option.bind right

# Can sort single number
    let treeData = create [2]
⍤⤙≍ [2] sortedData treeData

# Can sort if second number is smaller than first
    let treeData = create [2 1]
⍤⤙≍ [1 2] sortedData treeData

# Can sort if second number is same as first
    let treeData = create [2 2]
⍤⤙≍ [2 2] sortedData treeData

# Can sort if second number is greater than first
    let treeData = create [2 3]
⍤⤙≍ [2 3] sortedData treeData

# Can sort complex tree
    let treeData = create [2 1 3 6 7 5]
⍤⤙≍ [1 2 3 5 6 7] sortedData treeData

