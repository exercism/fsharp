~ "list-ops.ua" ~ ListOps

# append empty lists
⍤⤙≍ [] append [] []

# append list to empty list
⍤⤙≍ [1 2 3 4] append [] [1 2 3 4]

# append empty list to list
⍤⤙≍ [1 2 3 4] append [1 2 3 4] []

# append non-empty lists
⍤⤙≍ [1 2 2 3 4 5] append [1 2] [2 3 4 5]

# concat empty list
⍤⤙≍ [] concat []

# concat list of lists
⍤⤙≍ [1 2 3 4 5 6] concat [[1 2] [3] [] [4 5 6]]

# concat list of nested lists
⍤⤙≍ [[1] [2] [3] [] [4 5 6]] concat [[[1] [2]] [[3]] [[]] [[4 5 6]]]

# filter empty list
⍤⤙≍ [] filter (fun acc -> acc ÷ 2 = 1) []

# filter non-empty list
⍤⤙≍ [1 3 5] filter (fun acc -> acc ÷ 2 = 1) [1 2 3 5]

# length empty list
⍤⤙≍ 0 ⧻ []

# length non-empty list
⍤⤙≍ 4 ⧻ [1 2 3 4]

# map empty list
⍤⤙≍ [] map (fun acc -> acc + 1) []

# map non-empty list
⍤⤙≍ [2 4 6 8] map (fun acc -> acc + 1) [1 3 5 7]

# foldl empty list
⍤⤙≍ 2 foldl (fun acc el -> el × acc) 2 []

# foldl direction independent function applied to non-empty list
⍤⤙≍ 15 foldl (fun acc el -> el + acc) 5 [1 2 3 4]

# foldr empty list
⍤⤙≍ 2 foldr (fun acc el -> el × acc) 2 []

# foldr direction independent function applied to non-empty list
⍤⤙≍ 15 foldr (fun acc el -> el + acc) 5 [1 2 3 4]

# reverse empty list
⍤⤙≍ [] ⇌ []

# reverse non-empty list
⍤⤙≍ [7 5 3 1] ⇌ [1 3 5 7]

# reverse list of lists is not flattened
⍤⤙≍ [[4 5 6] [] [3] [1 2]] ⇌ [[1 2] [3] [] [4 5 6]]
