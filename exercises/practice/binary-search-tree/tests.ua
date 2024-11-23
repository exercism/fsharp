~ "binary-search-tree.ua" ~ BinarySearchTree

# Data is retained
treeData = create [4]
⍤⤙≍ 4 treeData |> data
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> left)
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> right)

# Smaller number at left node
treeData = create [4 2]
⍤⤙≍ 4 treeData |> data
⍤⤙≍ 2 treeData |> left |> Option.map data
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> left |> Option.bind left)
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> left |> Option.bind right)
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> right)

# Same number at left node
treeData = create [4 4]
⍤⤙≍ 4 treeData |> data
⍤⤙≍ 4 treeData |> left |> Option.map data
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> left |> Option.bind left)
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> left |> Option.bind right)
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> right)

# Greater number at right node
treeData = create [4 5]
⍤⤙≍ 4 treeData |> data
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> left)
⍤⤙≍ 5 treeData |> right |> Option.map data
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> right |> Option.bind left)
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> right |> Option.bind right)

# Can create complex tree
treeData = create [4 2 6 1 3 5 7]
⍤⤙≍ 4 treeData |> data
⍤⤙≍ 2 treeData |> left |> Option.map data
⍤⤙≍ 1 treeData |> left |> Option.bind left |> Option.map data
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> left |> Option.bind left |> Option.bind left)
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> left |> Option.bind left |> Option.bind right)
⍤⤙≍ 3 treeData |> left |> Option.bind right |> Option.map data
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> left |> Option.bind right |> Option.bind left)
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> left |> Option.bind right |> Option.bind right)
⍤⤙≍ 6 treeData |> right |> Option.map data
⍤⤙≍ 5 treeData |> right |> Option.bind left |> Option.map data
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> right |> Option.bind left |> Option.bind left)
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> right |> Option.bind left |> Option.bind right)
⍤⤙≍ 7 treeData |> right |> Option.bind right |> Option.map data
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> right |> Option.bind right |> Option.bind left)
⍤⤙≍ "TODO: insert error message" ⍣(treeData |> right |> Option.bind right |> Option.bind right)

# Can sort single number
treeData = create [2]
⍤⤙≍ [2] sortedData treeData

# Can sort if second number is smaller than first
treeData = create [2 1]
⍤⤙≍ [1 2] sortedData treeData

# Can sort if second number is same as first
treeData = create [2 2]
⍤⤙≍ [2 2] sortedData treeData

# Can sort if second number is greater than first
treeData = create [2 3]
⍤⤙≍ [2 3] sortedData treeData

# Can sort complex tree
treeData = create [2 1 3 6 7 5]
⍤⤙≍ [1 2 3 5 6 7] sortedData treeData

